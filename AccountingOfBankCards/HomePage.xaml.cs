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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }
        List<Person> _people = new List<Person>();
        List<Card> _cards = new List<Card>();


        public void NewCardAdded(Card card)
        {
            _cards.Add(card);
            listBoxCards.ItemsSource = null;
            listBoxCards.Items.Add(card.ShowCard(card));
        }

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddCardPage);

        }

        private void ButtonDeleteCard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.DeleteCardPage);
        }

        private void ButtonFindCard_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(Pages.FindCardPage);
        }

        private void ButtonChangeCard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ChangeCardPage);
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LoginPage);
        }

        private void buttonReadFile_Click(object sender, RoutedEventArgs e)
        {
            listBoxCards.Items.Clear();
            string[] str = File.ReadAllLines("Cards.txt", Encoding.GetEncoding(1251));
            for (int i = 0; i < str.Length; i++)
            {
                string[] str1 = str[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//StringSplitOptions.RemoveEmptyEntries делит файл на строки по пробелу даже если пробелов между словами несколько
                Card card = new Card(double.Parse(str1[0]), int.Parse(str1[1]), int.Parse(str1[2]), int.Parse(str1[3]), str1[4], str1[5], str1[6]);
                _cards.Add(card);
            }
            foreach (Card card in _cards)
                listBoxCards.Items.Add(card.ShowCard(card));
            MessageBox.Show("File written","OK",MessageBoxButton.OK);
        }

        private void buttonReadFile_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonReadFile.Width = 135;
            buttonReadFile.Height = 50;
            buttonReadFile.FontSize = 22;
        }

        private void buttonReadFile_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonReadFile.Width = 124;
            buttonReadFile.Height = 40;
            buttonReadFile.FontSize = 18;
        }

        private void buttonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("BankBase.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    foreach (Card card in _cards)
                        sw.WriteLine(card.ShowCard(card));
                }
                MessageBox.Show("File created", "OK", MessageBoxButton.OK);
            }

        }
    }
}
