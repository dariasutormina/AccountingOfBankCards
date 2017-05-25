using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfBankCards
{
     static class Pages
    {
        private static LoginPage _loginpage = new LoginPage();
        private static RegistrationPage _registrationpage = new RegistrationPage();

        public static LoginPage LoginPage
        {
            get
            {
                return _loginpage;
            }
        }
        private static HomePage _homepage = new HomePage();

        public static HomePage HomePage
        {
            get
            {
                return _homepage;
            }
        }

        public static RegistrationPage RegistrationPage
        {
            get
            {
                return _registrationpage;
            }
        }
        private static AddCardPage _addcardpage = new AddCardPage();

        public static AddCardPage AddCardPage
        {
            get
            {
                return _addcardpage;
            }
        }
        private static DeleteCardPage _deletecardpage = new DeleteCardPage();

        public static DeleteCardPage DeleteCardPage
        {
            get
            {
                return _deletecardpage;
            }
        }
        private static FindCardPage _findcardpage = new FindCardPage();

        public static FindCardPage FindCardPage
        {
            get
            {
                return _findcardpage;
            }
        }
        private static ChangeCardPage _changecardpage = new ChangeCardPage();

        public static ChangeCardPage ChangeCardPage
        {
            get
            {
                return _changecardpage;
            }
        }
    }
}
