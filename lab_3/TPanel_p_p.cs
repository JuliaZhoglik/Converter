using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3
{
    public partial class TPanel_p_p : Form
    {
        //Объект класса Управление.
        Control_ ctl = new Control_();

        public TPanel_p_p()
        {
            InitializeComponent();
        }

        private void TPanel_p_p_Load(object sender, EventArgs e)
        {
            label1.Text = ctl.ed.number;
            //Основание с.сч. исходного числа р1.
            trackBar1.Value = ctl.Pin;
            numericUpDown1.Value = ctl.Pin;
            //Основание с.сч. результата р2.
            trackBar2.Value = ctl.Pout;
            numericUpDown2.Value = ctl.Pout;
            label3.Text = "Основание с. сч. исходного числа " + trackBar1.Value;
            label4.Text = "Основание с. сч. результата " + trackBar2.Value;
            label2.Text = "0";
            //Обновить состояние командных кнопок.
            this.UpdateButtons();

        }

        //Обработчик события нажатия командной кнопки.
        private void button1_Click(object sender, EventArgs e)
        {
            //ссылка на компонент, на котором кликнули мышью
            Button but = (Button)sender;
            //номервыбраннойкоманды
            int j = Convert.ToInt16(but.Tag.ToString());
            DoCmnd(j);
        }
        //Выполнитькоманду.
        private void DoCmnd(int j)
        {
            if (j == 19) { label2.Text = ctl.DoCmnd(j); }
            else
            {
                if (ctl.St == Control_.State.Converted)
                {
                    //очистить содержимое редактора 
                    label1.Text = ctl.DoCmnd(18);
                }
                //выполнить команду редактирования
                label1.Text = ctl.DoCmnd(j);
                label2.Text = "0";
            }

        }

        //Обновляет состояние командных кнопок по основанию с. сч. исходного числа.
        private void UpdateButtons()
        {
            //просмотреть все компоненты формы
            foreach (Control i in this.Controls)
            {
                if (i is Button)//текущий компонент - командная кнопка 
                {
                    int j = Convert.ToInt16(i.Tag.ToString());
                    if (j < trackBar1.Value)
                    {
                        //сделать кнопку доступной
                        i.Enabled = true;
                    }
                    if ((j >= trackBar1.Value) && (j <= 15))
                    {
                        //сделать кнопку недоступной
                        i.Enabled = false;
                    }
                }
            }
        }

        //Изменяет значение основания с.сч. исходного числа.
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            //Обновить состояние командных кнопок.
            //this.UpdateP1();

        }
        //Изменяет значение основания с.сч. исходного числа.
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Обновитьсостояние.
            trackBar1.Value = Convert.ToByte(numericUpDown1.Value);
            //Обновить состояние командных кнопок.
            this.UpdateP1();

        }

        //Выполняет необходимые обновления при смене ос. с.сч. р1.
        private void UpdateP1()
        {
            label3.Text = "Основание с. сч. исходного числа " + trackBar1.Value;
            //Сохранить р1 в объекте управление.
            ctl.Pin = trackBar1.Value;
            //Обновить состояние командных кнопок.
            this.UpdateButtons();
            label1.Text = ctl.DoCmnd(18);
            label2.Text = "0";
        }

        //Изменяет значение основания с.сч. результата.
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //Обновить состояние. 
            numericUpDown2.Value = trackBar2.Value;
            //this.UpdateP2();

        }

        //Изменяет значение основания с.сч. результата.
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToByte(numericUpDown2.Value);
            this.UpdateP2();

        }

        //Выполняет необходимые обновления при смене ос. с.сч. р2.
        private void UpdateP2()
        {
            //Копировать основание результата.
            ctl.Pout = trackBar2.Value;
            //Пересчитать результат. 
            label2.Text = ctl.DoCmnd(19);
            label4.Text = "Основание с. сч. результата " + trackBar2.Value;
        }

        //Пункт меню Выход.
        private void ExittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Пункт меню Справка.
        private void InfotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();

        }

        //Пункт меню История.
        private void HistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.Show();
            if (ctl.his.Count() == 0)
            {
                history.textBox1.AppendText("История пуста");
                return;
            }
            //Ообразить историю. 
            for (int i = 0; i < ctl.his.Count(); i++)
            {
                history.textBox1.AppendText(ctl.his[i].ToString() + Environment.NewLine);
            }

        }

        //Обработкаалфавитно-цифровыхклавиш.
        private void TPanel_p_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("key press");
            int i = -1;
            if (e.KeyChar >= 'A' && e.KeyChar <= 'F') i = (int)e.KeyChar - 'A' + 10;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'f') i = (int)e.KeyChar - 'a' + 10;
            if (e.KeyChar >= '0' && e.KeyChar <= '9') i = (int)e.KeyChar - '0';
            if (e.KeyChar == '.') i = 16;
            if ((int)e.KeyChar == 8) i = 17;
            if ((int)e.KeyChar == 13) i = 19;
            if ((i < ctl.Pin) || (i >= 16)) DoCmnd(i);

        }

        //Обработка клавиш управления.
        private void TPanel_p_p_KeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("key down");
            if (e.KeyCode == Keys.Delete)
                //Клавиша Delete.
                DoCmnd(18);
            if (e.KeyCode == Keys.Execute)
                //Клавиша Execute Separator.
                DoCmnd(19);
            if (e.KeyCode == Keys.Decimal)
                //Клавиша Decimal.
                DoCmnd(16);

        }
    }
}
