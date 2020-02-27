using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Control_
    {
        //Основание системы сч. исходного числа. 
        const int pin = 10;
        //Основание системы сч. результата. 
        const int pout = 16;
        //Число разрядов в дробной части результата. 
        const int accuracy = 10;
        public History his = new History();
        public enum State { Editing, Converted }
        //Свойство для чтения и записи состояние Конвертера.
        public State St { get; set; }
        //Конструктор.
        public Control_()
        {
            St = State.Editing;
            Pin = pin;
            Pout = pout;
        }
            //объект редактор
            public Editor ed = new Editor();
            //Свойство для чтения и записи основание системы сч. р1.
            public int Pin { get; set; }
            //Свойство для чтения и записи основание системы сч. р2.
            public int Pout { get; set; }
            //Выполнить команду конвертера.
            public string DoCmnd(int j)
            {
                if (j == 19)
                {
                    double r = Conver_P_10.dval(ed.number, (Int16)Pin);
                    string res = Conver_10_P.Do(r, (Int32)Pout, acc());
                    St = State.Converted;
                    his.AddRecord(Pin, Pout, ed.number, res);
                    return res;
                }
                else
                {
                    St = State.Editing;
                    return ed.DoEdit(j);
                }

            }
            //Точность представления результата.
            private int acc()
            {
                return (int)Math.Round(ed.Acc() * Math.Log(Pin) / Math.Log(Pout) + 0.5);
            }
    }
}
