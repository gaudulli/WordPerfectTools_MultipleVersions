using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

using WP_PS_Tools;

namespace WP_GUI
{
    public partial class NumberToTextForm : Form
    {
        private WP_Window wp;

        private bool ignoreDecimal = true;
        private int decimalLength = 4;
        private bool decimalFraction = false;




        public NumberToTextForm(WP_Window wp, int RB)
        {
            InitializeComponent();
            CenterToScreen();

            this.wp = wp;
            switch (RB) // pre-select radio button, based on user selection
            {
                case 1:
                    {
                        radioButton1.Select();
                        break;
                    }
                case 2:
                    {
                        radioButton2.Select();
                        break;
                    }
                case 3:
                    {
                        radioButton3.Select();
                        break;
                    }

            }
            groupBox2.Visible = false;
            groupBox2.Enabled = false;
            radioButton5.Select();

            listBox1.SelectedIndex = 0;
            label2.Visible = false;
            listBox1.Visible = false;
            Win32API.ForceWindowIntoForeground(this.Handle);    // switch cursor from WP to new form
            this.ActiveControl = textBox1;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            Decimal result;
            if (Decimal.TryParse(inputText, NumberStyles.Currency, CultureInfo.CurrentCulture, out result))
            {
                int decimalCount = BitConverter.GetBytes(decimal.GetBits(result)[3])[2];
                if (radioButton1.Checked)       //legal currency style
                {
                    AddUtilities.ConvertNumberToMoney(wp, result, 2, decimalFraction);
                    this.Close();
                }
                else if (radioButton2.Checked)  // simple number
                {
                    if (!decimalFraction)   //set decimalLength at number of decimal places in number in case
                    // fraction cannot be reduced.
                    {
                        decimalLength = decimalCount;
                    }
                    AddUtilities.ConvertNumberToText(wp, result, ignoreDecimal, decimalLength, decimalFraction);
                    this.Close();
                }
                else if (radioButton3.Checked)  //simple currency
                {
                    AddUtilities.ConvertNumberToCurrency(wp, result);
                    this.Close();
                }

            }
            else
            {
                label1.Text = "Please Input a Valid Number";
                label1.ForeColor = Color.Red;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // releases PerfectScript in case it is still active
            wp.initPerfectScript();
            wp.releaseScript();
            base.OnFormClosing(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox2.Visible = true;
                groupBox2.Enabled = true;
                ignoreDecimal = false;


            }
            else
            {
                groupBox2.Visible = false;
                groupBox2.Enabled = false;
                ignoreDecimal = true;

            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                label2.Visible = true;
                listBox1.Visible = true;
                label2.Enabled = true;
                listBox1.Enabled = true;

                decimalFraction = true;
            }
            else
            {
                label2.Enabled = false;
                listBox1.Enabled = false;
                label2.Visible = false;
                listBox1.Visible = false;

                decimalFraction = false;
                decimalLength = 4;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimalLength = listBox1.SelectedIndex + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
