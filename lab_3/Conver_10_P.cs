using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class Conver_10_P
    {

        //Преобразовать целое в символ.
        public static char int_to_Char(int n)
        {
            const string numbers = "0123456789ABCDEF"; // цифры для систем счислений в диапазоне от 2 до 16
            char s = numbers[n];
            return s;
        }
        //Преобразовать десятичное целое в с.сч. с основанием р.
        public static string int_to_P(int n, int p)
        {
            int x = Math.Abs(n); // целая часть запишется в x

            string sx = "";
            do
            {
                int rem = x % p; // остаток от деления
                int quot = x / p; // целая часть от деления
                sx = int_to_Char(rem) + sx;
                x = quot;
            } while (x != 0);

            return sx;
        }
        //Преобразовать десятичную дробь в с.сч. с основанием р.
        public static string flt_to_P(double n, int p, int c)
        {
            string sy = "";
            // если дробная часть = 0 или точность = 0, то перевод закончен
            if ((n != 0) && (c != 0)) {
                double y = Math.Abs(n); // дробная - в y
                //переводим дробную часть заданной точности
                for (int i = 1; i <= c; i++)
                {
                    double value = y * p;
                    int vx = (int) Math.Truncate(value); // целая часть запишется в vx
                    double vy = value - vx; // дробная - в vy
                    sy = sy + int_to_Char(vx);
                    y = vy;
                    // eсли дробная часть = 0, то перевод закончен.
                    if (y == 0)
                    {
                        break;
                    }
                }
            }

            return sy;
        }
        //Преобразовать десятичное действительное число в с.сч. с осн. р.
        public static string Do(double n, int p, int c)
        {
            int x = (int) Math.Abs(Math.Truncate(n)); // целая часть запишется в x
            double y = Math.Abs(n) - x; // дробная - в y
           
            //переводим целую часть
            string sx = int_to_P(x, p);
            //переводим дробную часть заданной точности
            string sy = flt_to_P(y, p, c);

            string s = sx;

            if ((y != 0) && (c != 0))
            {
                s = s + "." + sy;
            }

            if (n < 0)
            {
                s = "-" + s;
            }

            return s;
        }



    }
}
