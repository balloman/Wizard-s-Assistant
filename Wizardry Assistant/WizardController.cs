using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Wizardry_Assistant.Models;

namespace Wizardry_Assistant
{
    public class WizardController
    {

        private const string WIZARD_FILE = "Wizard.wz";
        public static WizardController Instance { get; } = new WizardController();

        private Wizard Wizard { get; set; }

        public List<AttackSpell> AttackSpells => Wizard.Spellbook.Attacks;
        public List<CharmSpell> CharmSpells => Wizard.Spellbook.Charms;
        
        public AttackSpell CurrentSpell { get; set; }

        private WizardController()
        {
            Wizard = new Wizard {Spellbook = new Spellbook()};
            LoadWizard();
        }

        public void AddSpell(Spell spell)
        {
            Wizard.Spellbook.AddSpell(spell);
            Task.Run(SaveData);
        }

        public void AddAttack(uint cost, uint min, uint max, bool xCost, string school, string name)
        {
            var spell = new AttackSpell() {
                Cost = cost,
                MaxDamage = max,
                MinDamage = min,
                XCost = xCost,
                Name = name,
            };
            spell.SetSchool(school);
            AddSpell(spell);
        }

        public void AddCharm(uint cost, float amount, string school, string name)
        {
            var spell = new CharmSpell {
                Amount = amount,
                Cost = cost,
                Name = name,
            };
            spell.SetSchool(school);
            AddSpell(spell);
        }

        public void DeleteSpell(Spell spell)
        {
            
        }

        private void SaveData()
        {
            var writer = new StreamWriter(WIZARD_FILE);
            var output = JsonConvert.SerializeObject(Wizard, Formatting.Indented, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto
            });
            writer.Write(output);
            writer.Close();
        }

        private void LoadWizard()
        {
            if (!File.Exists(WIZARD_FILE)) {
                return;
            }
            var fs = new StreamReader(WIZARD_FILE);
            Wizard = JsonConvert.DeserializeObject<Wizard>(fs.ReadToEnd(), new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto
            });
            fs.Close();
        }

        public float BaseDamage
        {
            get => Wizard.BaseDamage;
            set
            {
                Wizard.BaseDamage = value;
                Task.Run(SaveData);
            }
        }
        
        public void UpdateListBox<T>(ListBox box, IEnumerable<T> items)
        {
            box.Items.Clear();
            foreach (var item in items) {
                box.Items.Add(item);
            }
        }
    }
}