using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class Conver_P_10
    {

        //Преобразовать цифру в число.
        public static double char_To_num(char ch)
        {
            const string numbers = "0123456789ABCDEF"; // цифры для систем счислений в диапазоне от 2 до 16
            double n = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (ch == numbers[i]) {
                    break;
                } else {
                    n++;
                }
            }

            return n;
        }
        //Преобразовать строку в число
        public static double convert(string P_num, int P, double weight)
        {
            double n = 0;
            double w = weight;

            for (int i = 0; i < P_num.Length; i++)
            {
                n = n + char_To_num(P_num[i]) * w;
                w = w / P;
            }

            return n;

        }
        //Преобразовать из с.сч. с основанием р в с.сч. с основанием 10.
        public static double dval(string P_num, int P)
        {
            double w = 0;
            string s = "";
            bool minus = false;
            bool frac = false;
            string new_p = P_num;
            if (P_num[0] == '-')
            {
                new_p = P_num.TrimStart('-');
                minus = true;
            }

            for (int i = 0; i < new_p.Length; i++)
            {
                if (new_p[i] == '.')
                {
                    frac = true;
                    w = Math.Pow(P, (i-1));
                } else
                {
                    s = s + new_p[i];
                }
            }

            if (frac == false)
            {
                w = Math.Pow(P, (new_p.Length - 1));
            }

            double n = convert(s, P, w);
            if (minus == true)
            {
                n = -n;
            }

            return n;
        }
    }


}

