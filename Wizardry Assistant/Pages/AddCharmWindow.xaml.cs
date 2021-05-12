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
    /// Interaction logic for AddCharmWindow.xaml
    /// </summary>
    public partial class AddCharmWindow : Window
    {
        public AddCharmWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text)) {
                Close();
                return;
            }
            uint.TryParse(PipCostBox.Text, out var cost);
            uint.TryParse(AmountBox.Text, out var amount);
            WizardController.Instance.AddCharm(cost, (float) amount / 100 + 1, SchoolBox.Text, NameBox.Text);
            Close();
        }
    }
}
