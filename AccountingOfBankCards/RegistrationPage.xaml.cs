using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        List<Person> _people = new List<Person>();
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void buttonAddPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("Staff.txt", FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        Person person = new Person(textBoxSurname.Text, textBoxName.Text, textBoxLogin.Text,CalculateHash(passwordBox.Password));
                        _people.Add(person);
                        for (int i = 0; i < _people.Count; i++)
                        {
                            sw.WriteLine(_people[i].ShowPerson(_people[i]));
                        }
                        
                    }
                }
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxLogin.Text = "";
                passwordBox.Password = "";
                NavigationService.Navigate(Pages.HomePage);
            }
            catch
            {
                MessageBox.Show("Data is not entered or entered incorrectly");
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
