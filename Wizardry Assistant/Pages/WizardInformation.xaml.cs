using System.Globalization;
using System.Windows;

namespace Wizardry_Assistant.Pages
{
    public partial class WizardInformation : Window
    {
        public WizardInformation()
        {
            InitializeComponent();
            BaseDamageBox.Text = ((int) ((WizardController.Instance.BaseDamage - 1) * 100)).ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BaseDamageBox.Text)) {
                Close();
                return;
            }
            float.TryParse(BaseDamageBox.Text, out var damage);
            WizardController.Instance.BaseDamage = damage / 100 + 1;
            Close();
        }
    }
}