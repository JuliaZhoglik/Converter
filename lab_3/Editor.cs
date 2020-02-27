using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class Editor
    {

        //Разделитель целой и дробной частей.
        const char delim = '.';
        //Ноль.
        const char zero = '0';
        // все цифры
        const string all_numbers = "0123456789ABCDEF";

        // конструктор
        public Editor()
        {
            number = "" + zero;
        }

        //Свойство для чтения и записи редактируемого числа.
        public string number
        { get; set; }

        //Добавить ноль.
        public string AddZero() // 0
        {
            string s = "";

            if ((number == "0") || (number == "-0"))
            {
                s = number;
            }
            else
            {
                s = number + zero;
            }
            return s;
        }

        //Добавить цифру.
        public string AddDigit(int n) // 1..15
        {
            string s = "";
            if (number == "0")
            {
                s = "" + all_numbers[n];
            } else if (number == "-0")
            {
                s = "-" + all_numbers[n];
            } else
            {
             s = number + all_numbers[n];
            }
            return s;
        }

        //Точность представления результата.
        public int Acc() // возвращает текущую точность
        {
            int n = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == delim)
                {
                    n = number.Length - 1 - i;
                    break;
                }
            }

            return n;
        }

        //Знак
        public string Sign()
        {
            string s = "";
            
            if (number[0] == '-')
            {
                for (int i = 1; i < number.Length; i++)
                {
                    s = s + number[i];
                }
            }
            else
            {
                s = "-" + number;
            }

            return s;
        }

        //Добавить разделитель.
        public string AddDelim()
        {
            string s = number;

            bool can_add_delim = true;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == delim)
                {
                    can_add_delim = false;
                    break;
                }
            }
            if (can_add_delim == true)
            {
                s = number + delim;
            }

            return s;
        }

        //Удалить символ справа.
        public string Bs()
        {
            string s = "";

            if ((number.Length <= 1) || ((number.Length == 2) && (number[0] == '-')))
            {
                s = "" + zero;
            } else
            {
                for (int i = 0; i < number.Length - 1; i++)
                {
                    s = s + number[i];
                }
            }

            return s;
        }

        //Очистить редактируемое число.
        public string Clear()
        {
            string s = "" + zero;
            return s;
        }

        //Выполнить команду редактирования.
        public string DoEdit(int j)
        {
            if (j == 0) { number = AddZero(); }
            if ((j >= 1) && (j <= 15)) { number = AddDigit(j); }
         //   if (j == 16) { number = Sign(); }
            if (j == 16) { number = AddDelim(); }
            if (j == 17) { number = Bs(); }
            if (j == 18) { number = Clear(); }

            return number;
        }



    }
}
