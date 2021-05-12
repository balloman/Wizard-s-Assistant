using System;
using System.Collections.Generic;
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
using Wizardry_Assistant.Models;

namespace Wizardry_Assistant.Pages
{
    /// <summary>
    /// Interaction logic for Spellbook.xaml
    /// </summary>
    public partial class SpellbookPage : Page
    {
        private readonly WizardController instance;
        
        public SpellbookPage()
        {
            InitializeComponent();
            instance = WizardController.Instance;
            instance.UpdateListBox(SpellListBox, instance.AttackSpells);
            instance.UpdateListBox(CharmListBox, instance.CharmSpells);
        }

        

        private void AddSpellButton_OnClick(object sender, RoutedEventArgs e)
        {
            var spellWindow = new AddSpellWindow {Owner = Application.Current.MainWindow};
            spellWindow.ShowDialog();
            instance.UpdateListBox(SpellListBox, instance.AttackSpells);
        }

        private void AddCharmButton_OnClick(object sender, RoutedEventArgs e)
        {
            var buffWindow = new AddCharmWindow {Owner = Application.Current.MainWindow};
            buffWindow.ShowDialog();
            instance.UpdateListBox(CharmListBox, instance.CharmSpells);
        }

        private void SpellListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = SpellListBox.SelectedIndex;
            var spell = instance.AttackSpells[item];
            instance.CurrentSpell = spell;
            NavigationService.Navigate(new SpellCalculationPage());
        }

        private void WizardButton_OnClick(object sender, RoutedEventArgs e)
        {
            var wizardWindow = new WizardInformation {Owner = Application.Current.MainWindow};
            wizardWindow.ShowDialog();
        }
    }
}
