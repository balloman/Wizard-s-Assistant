using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wizardry_Assistant.Pages
{
    /// <summary>
    /// Interaction logic for SpellCalculationPage.xaml
    /// </summary>
    public partial class SpellCalculationPage : Page
    {
        private BindingList<float> debuffs = new BindingList<float>();
        
        public SpellCalculationPage()
        {
            InitializeComponent();
            PipsLabel.Text = WizardController.Instance.CurrentSpell.XCost ? "Pips to cast with" : "Pips Required";
        }

        private async void HealthBlock_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            BoostListView.Items.Clear();
            int.TryParse(((TextBox) sender).Text, out var enemyHealth);
            var result = await Task.Run(() => WizardController.Instance.CalculateDamage(enemyHealth, debuffs.ToList()));
            BaseDamageBlock.Text =
                $"{WizardController.Instance.CurrentSpell.MinDamage} - {WizardController.Instance.CurrentSpell.MaxDamage}";
            foreach (var charmSpell in result.CharmsRequired) {
                BoostListView.Items.Add(charmSpell);
            }

            FinalDamageBlock.Text = result.Damage.ToString(CultureInfo.InvariantCulture);
            PipsRequiredBlock.Text = result.PipsRequired.ToString(CultureInfo.InvariantCulture);
            CritDamageBlock.Text = (result.Damage * 2).ToString(CultureInfo.InvariantCulture);
        }

        private void AddDebuff(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DebuffBox.Text)) {
                return;
            }

            int.TryParse(DebuffBox.Text, out var debuffAmount);
            debuffs.Add(debuffAmount);
        }
    }
}
