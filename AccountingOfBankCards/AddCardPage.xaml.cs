using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddCardPage.xaml
    /// </summary>
    public partial class AddCardPage : Page
    {
        public AddCardPage()
        {
            InitializeComponent();
        }
        List<Card> _cards = new List<Card>();
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

       
        private void buttonAddCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                using (FileStream fs = new FileStream("Cards.txt", FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        Card card = new Card(double.Parse(textBoxNumber.Text), int.Parse(textBoxCVC.Text), int.Parse(comboBoxMonth.Text), int.Parse(comboBoxYear.Text), comboBoxType.Text, textBoxSurname.Text, textBoxName.Text);
                        _cards.Add(card);
                        for (int i = 0; i < _cards.Count; i++)
                        {
                            sw.WriteLine(_cards[i].SHOWTXT(_cards[i])); 
                            Pages.HomePage.NewCardAdded(_cards[i]);
                        }
                        
                      
                    }
                }
                   
                textBoxNumber.Text = "";
                textBoxCVC.Text = "";
                comboBoxMonth.Text = "";
                comboBoxYear.Text = "";
                comboBoxType.Text = "";
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Data is not entered or entered incorrectly");
            }
        }
    }
}
