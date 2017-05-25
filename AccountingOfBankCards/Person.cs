using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfBankCards
{
    public class Person
    {
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Person(string _surname,string _name, string _login,string _password)
        {
            surname = _surname;
            name = _name;
            login = _login;
            password = _password;
        }

        public string[] SHOWperson(Person person)
        {
            string[] mstr = new string[3];
            mstr[0] = surname;
            mstr[1] = name;
            mstr[2] = login;

            return mstr;
        }
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        public string ShowPerson(Person person)
        {
            return string.Format("{0} {1} {2} {3}", surname, name, login,password);
        }



    }
}
