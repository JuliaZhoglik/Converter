using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{

    public struct Record
    {
        int base1; // основание исходного числа
        int base2; // основание результата преобразования
        string number1; // исходное число
        string number2; // результат преобразования
        public Record(int p1, int p2, string n1, string n2)
        {
            base1 = p1;
            base2 = p2;
            number1 = n1;
            number2 = n2;
        }


        public override string ToString()
        {
            string s = "";
            s = s + "Число " + number1 + " (осн. " + Convert.ToString(base1);
            s = s + ") преобразовано в " + number2 + " (осн. " + Convert.ToString(base2) + ')';
            return s;
        }
    }
    public class History
    {
        List<Record> L; // Список записей в истории

        // Получить запись
        public Record this[int i]
        {
            get
            {
                return L[i];
            }
        }

        // Добавить запись
        public void AddRecord(int p1, int p2, string n1, string n2) {
            Record r = new Record(p1, p2, n1, n2);
            L.Add(r);
        }

        // Очистить историю
        public void Clear() {
            L.Clear();
        }

        // получить текущий размер списка
        public int Count()
        {
            return L.Count;
        }

        // конструктор
        public History()
        {
            L = new List<Record>();
        }
    }


}
