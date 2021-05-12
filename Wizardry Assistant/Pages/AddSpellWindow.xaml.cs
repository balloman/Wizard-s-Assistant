using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for AddSpellWindow.xaml
    /// </summary>
    public partial class AddSpellWindow : Window
    {
        private bool isChecked;
        public AddSpellWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isChecked = (bool) ((CheckBox) sender).IsChecked;
            PipCostBox.IsEnabled = !isChecked;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            uint.TryParse(PipCostBox.Text, out var cost);
            uint.TryParse(DamageMaxBox.Text, out var max);
            uint.TryParse(DamageMinBox.Text, out var min);
            if (string.IsNullOrWhiteSpace(NameBox.Text)) {
                Close();
                return;
            }
            WizardController.Instance.AddAttack(cost, min, max, isChecked, SchoolComboBox.Text, NameBox.Text);
            Close();
        }
    }
}
