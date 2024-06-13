using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Expander_WPF
{
    /// <summary>
    /// Interaction logic for AdditionalTask2.xaml
    /// </summary>
    public partial class AdditionalTask2 : Window
    {
        private string preferences = "";
        public AdditionalTask2()
        {
            InitializeComponent();
        }
        private void showPreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (StackPanel stackPanel in preferencesGrid.Children.OfType<StackPanel>())
            {
                foreach (RadioButton radio in stackPanel.Children.OfType<RadioButton>().Where(rb => rb.IsChecked == true))
                {
                    preferences += stackPanel.Children.OfType<Label>().First().Content;
                    preferences += radio.Content + "\n";
                }
            }
            MessageBox.Show(preferences);
            preferences = "";
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (StackPanel stackPanel in preferencesGrid.Children.OfType<StackPanel>())
            {
                foreach (RadioButton radio in stackPanel.Children.OfType<RadioButton>())
                {
                    radio.IsChecked = false;
                }
            }
        }
    }
}
