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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            textBoxLogin.Focus();
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Using keyboard handling on the page level
            if (e.Key == Key.Enter)
                buttonSignIn_Click(null, null);
        }

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                using (StreamReader sr = new StreamReader("Staff.txt"))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        string[] mas = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (textBoxLogin.Text == mas[2] && CalculateHash(passwordBox.Password) == mas[3])
                        {

                            NavigationService.Navigate(Pages.HomePage);
                        }

                        textBoxLogin.Text = "";
                        passwordBox.Password = "";
                    }

                    textBoxLogin.Text = "";
                    passwordBox.Password = "";
                }
            }
            catch
            {

            }

            }
        
           
        

        private void buttonSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.RegistrationPage);
        }

        private void buttonSignIn_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonSignIn.Width = 100;
            buttonSignIn.Height = 36;
            buttonSignIn.FontSize = 18;
        }

        private void buttonSignIn_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonSignIn.Width = 95;
            buttonSignIn.Height = 33;
            buttonSignIn.FontSize = 16;
        }

        private void buttonSignUp_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonSignUp.Width = 100;
            buttonSignUp.Height = 36;
            buttonSignUp.FontSize = 18;
        }

        private void buttonSignUp_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonSignUp.Width = 95;
            buttonSignUp.Height = 33;
            buttonSignUp.FontSize = 16;
        }
    }
}
