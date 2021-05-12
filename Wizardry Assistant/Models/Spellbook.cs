using System;
using System.Collections.Generic;
using System.Text;

namespace Wizardry_Assistant.Models
{
    public class Spellbook
    {
        public List<Spell> Spells { get; }

        public void AddSpell(Spell spell)
        {
            Spells.Add(spell);
        }

        public List<CharmSpell> Charms
        {
            get
            {
                var charmSpells = new List<CharmSpell>();
                foreach (var spell in Spells)
                {
                    if (spell is CharmSpell charmSpell)
                    {
                        charmSpells.Add(charmSpell);
                    }
                }

                return charmSpells;
            }
        }

        public List<AttackSpell> Attacks
        {
            get
            {
                var attackSpells = new List<AttackSpell>();
                foreach (var spell in Spells)
                {
                    if (spell is AttackSpell attackSpell)
                    {
                        attackSpells.Add(attackSpell);
                    }
                }

                return attackSpells;
            }
        }

        public Spellbook()
        {
            Spells = new List<Spell>();
        }
    }
}
