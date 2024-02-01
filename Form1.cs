using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;
using static System.Net.Mime.MediaTypeNames;

namespace числа_которые_корень_отрицательный_хехе_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Imaginary num1 = new Imaginary();
        public Imaginary num2 = new Imaginary();

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void debug_Click(object sender, EventArgs e)
        {
            try
            {
                num1.Value = textBox1.Text;
                num2.Value = textBox2.Text;
                Imaginary complexNumber = null;
                switch (comboBox1.Text)
                {
                    case "+":
                        {
                            complexNumber = num1 + num2;
                        }break;
                    case "-":
                        {
                            complexNumber = num1 - num2;
                        }
                        break;
                    case "*":
                        {
                            complexNumber = num1 * num2;
                        }
                        break;
                    case "/":
                        {
                            complexNumber = num1 / num2;
                        }
                        break;
                }

                string result = "Результат: ";

                if (checkBox1.Checked)
                {
                    result += "Алгебраическая форма: " + complexNumber.ToString() + Environment.NewLine;
                }

                if (checkBox2.Checked)
                {
                    result += "Тригонометрическая форма: " + complexNumber.ToPolarForm() + Environment.NewLine;
                }

                if (checkBox3.Checked)
                {
                    result += "Экспоненциальная форма: " + complexNumber.ToExponentialForm() + Environment.NewLine;
                }

                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
                {
                    MessageBox.Show(result.Trim(), "Результат");
                }
                else
                {
                    throw new Exception("Выберите хотя бы одну форму представления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
