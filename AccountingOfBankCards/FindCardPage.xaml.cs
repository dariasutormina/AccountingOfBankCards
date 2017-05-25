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
    /// Interaction logic for FindCardPage.xaml
    /// </summary>
    public partial class FindCardPage : Page
    {
        public FindCardPage()
        {
            InitializeComponent();
            
           
        }
        List<Card> cards = new List<Card>();

        private void buttonFindCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBoxCards.Items.Clear();
                string[] str = File.ReadAllLines("Cards.txt", Encoding.GetEncoding(1251));
                for (int i = 0; i < str.Length; i++)
                {
                    string[] str1 = str[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                    if (comboBoxFindCard.Text == "Number" && str1[0] == textBoxNumber.Text)
                    {
                        Card card = new Card(double.Parse(str1[0]), int.Parse(str1[1]), int.Parse(str1[2]), int.Parse(str1[3]), str1[4], str1[5], str1[6]);
                        cards.Add(card);
                        textBoxNumber.Text = "";
                        comboBoxFindCard.Text = "";
                    }

                    else if (comboBoxFindCard.Text == "CVC" && str1[1] == textBoxCVC.Text)
                    {
                        Card card = new Card(double.Parse(str1[0]), int.Parse(str1[1]), int.Parse(str1[2]), int.Parse(str1[3]), str1[4], str1[5], str1[6]);
                        cards.Add(card);
                        textBoxCVC.Text = "";
                        comboBoxFindCard.Text = "";
                    }


                    else if (comboBoxFindCard.Text == "Date" && str1[2] == comboBoxMonth.Text && str1[3] == comboBoxYear.Text)
                    {
                        Card card = new Card(double.Parse(str1[0]), int.Parse(str1[1]), int.Parse(str1[2]), int.Parse(str1[3]), str1[4], str1[5], str1[6]);
                        cards.Add(card);
                        comboBoxMonth.Text = "";
                        comboBoxYear.Text = "";
                        comboBoxFindCard.Text = "";
                    }



                    else if (comboBoxFindCard.Text == "Surname and Name" && str1[5].ToLower() == textBoxSurname.Text.ToLower() && str1[6].ToLower() == textBoxName.Text.ToLower())
                    {
                        Card card = new Card(double.Parse(str1[0]), int.Parse(str1[1]), int.Parse(str1[2]), int.Parse(str1[3]), str1[4], str1[5], str1[6]);
                        cards.Add(card);
                        textBoxSurname.Text = "";
                        textBoxName.Text = "";
                        comboBoxFindCard.Text = "";
                    }


                    else if (comboBoxFindCard.Text == "Type" && str1[4] == comboBoxType.Text)
                    {
                        Card card = new Card(double.Parse(str1[0]), int.Parse(str1[1]), int.Parse(str1[2]), int.Parse(str1[3]), str1[4], str1[5], str1[6]);
                        cards.Add(card);
                        comboBoxType.Text = "";
                        comboBoxFindCard.Text = "";
                    }
                }



                foreach (Card card in cards)
                {
                    listBoxCards.Items.Clear();
                    listBoxCards.Items.Add(card.ShowCard(card));
                }

            }
            catch
            {

            }
        }
            
        

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            listBoxCards.Items.Clear();
            textBoxName.Text = "";
            textBoxNumber.Text = "";
            textBoxSurname.Text = "";
            comboBoxFindCard.Text = "";
            comboBoxMonth.Text = "";
            comboBoxYear.Text = "";
            textBoxCVC.Text = "";
            comboBoxType.Text = "";
            NavigationService.GoBack();
           
        }
       
    }
}
