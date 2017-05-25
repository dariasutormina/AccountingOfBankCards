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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingOfBankCards
{
    /// <summary>
    /// Interaction logic for ChangeCardPage.xaml
    /// </summary>
    public partial class ChangeCardPage : Page
    {
        public ChangeCardPage()
        {
            InitializeComponent();
        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
