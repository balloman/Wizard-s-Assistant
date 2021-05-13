using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wizardry_Assistant.Pages
{
    /// <summary>
    /// Interaction logic for SpellCalculationPage.xaml
    /// </summary>
    public partial class SpellCalculationPage : Page
    {
        private List<float> debuffs = new List<float>();
        private readonly WizardController w;
        
        public SpellCalculationPage()
        {
            InitializeComponent();
            w = WizardController.Instance;
            PipsLabel.Text = WizardController.Instance.CurrentSpell.XCost ? "Pips to cast with" : "Pips Required";
        }

        private void HealthBlock_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void AddDebuff(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DebuffBox.Text)) {
                return;
            }

            int.TryParse(DebuffBox.Text, out var debuffAmount);
            debuffs.Add(1 - (float) debuffAmount / 100);
            DebuffsListView.Items.Add($"-{debuffAmount}%");
            Calculate();
        }

        private async void Calculate()
        {
            BoostListView.Items.Clear();
            int.TryParse(HealthBlock.Text, out var enemyHealth);
            var result = await Task.Run(() => w.CurrentSpell.CalculateDamage(enemyHealth,
                w.BaseDamage,
                debuffs.ToList(),
                w.CharmSpells));
            BaseDamageBlock.Text =
                $"{w.CurrentSpell.MinDamage} - {w.CurrentSpell.MaxDamage}";
            foreach (var charmSpell in result.CharmsRequired) {
                BoostListView.Items.Add(charmSpell);
            }
            BoostListView.Items.Refresh();
            FinalDamageBlock.Text = result.Damage.ToString(CultureInfo.InvariantCulture);
            PipsRequiredBlock.Text = result.PipsRequired.ToString(CultureInfo.InvariantCulture);
            CritDamageBlock.Text = (result.Damage * 2).ToString(CultureInfo.InvariantCulture);
        }
    }
}
