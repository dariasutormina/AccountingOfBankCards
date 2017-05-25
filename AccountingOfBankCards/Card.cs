using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfBankCards
{
    public class Card
    {
        private double number;

        public double Number
        {
            get { return number; }
            set { number = value; }
        }
        private int cvc;

        public int Cvc
        {
            get { return cvc; }
            set { cvc = value; }
        }
        private int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string holder_surname;

        public string Holder_surname
        {
            get { return holder_surname; }
            set { holder_surname = value; }
        }
        private string holder_name;

        public string Holder_name
        {
            get { return holder_name; }
            set { holder_name = value; }
        }


        public Card(double _number,int _cvc,int _month,int _year,string _type,string _holder_surname,string _holder_name)
        {
            number = _number;
            cvc = _cvc;
            month = _month;
            year = _year;
            type = _type;
            holder_surname = _holder_surname;
            holder_name = _holder_name;
        }
        public string ShowCard(Card card)
        {
            return string.Format("{0}   {1}   {2}/{3}   {4}   {5}   {6}", number, cvc, month, year, type, holder_surname, holder_name);
        }
        public string SHOWTXT(Card card)
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", number, cvc, month, year, type, holder_surname, holder_name);
        }
    }
}
