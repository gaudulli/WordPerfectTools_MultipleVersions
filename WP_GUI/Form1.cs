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



using FakeCompany;
using WP_PS_Tools;
using NumbersToText;



namespace WP_GUI
{
    public partial class Form1 : Form
    {

        WP_Window wp;    // WP_Window is the class that starts WordPerfect or captures an instance 
                         // of WP already running.  It then embeds itself into the main form.
                         //  WP_Window is also the tool used to access a PerefectScript object to interact
                         // with WordPerfect documents.

        public Form1()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)       // This is a standard method call when a form is loaded
        {
            this.WindowState = FormWindowState.Maximized;
            try
            {
                wp = new WP_Window(panel2.Handle);          

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load WordPerfect");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            wp.exit(false);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {

            if (wp != null && wp.wpHandle != null)
            {
                Win32API.SetWindowPos(wp.wpHandle, (IntPtr)0, 0, 0, panel2.Width, panel2.Height, 16384);    //ascynchronous window position
            }
        }

        //Starts a new WP_Window and either starts or captures WP instance
        private void CaptureWPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wp = new WP_Window(panel2.Handle);
        }

        private void moneyLegalStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string selectedtext = AddUtilities.getSelectedText(wp);
            if (String.IsNullOrEmpty(selectedtext))     // if there is no text selected, open up NumberToTextForm
            {
                NumberToTextForm convertNumberForm = new NumberToTextForm(wp, 1);
                convertNumberForm.ShowDialog();
            }

            else
            {
                Decimal result;
                // try to parse the number.  If it is no good, it gets ignored
                if (Decimal.TryParse(selectedtext, NumberStyles.Currency, CultureInfo.CurrentCulture, out result))
                {
                    AddUtilities.ConvertNumberToMoney(wp, result);
                }
            }
        }

        private void numberToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedtext = AddUtilities.getSelectedText(wp);

            if (String.IsNullOrEmpty(selectedtext))
            {

                NumberToTextForm convertNumberForm = new NumberToTextForm(wp, 2);
                convertNumberForm.Show();
            }
            else
            {
                Decimal result;
                if (Decimal.TryParse(selectedtext, NumberStyles.Number, CultureInfo.CurrentCulture, out result))
                {
                    AddUtilities.ConvertNumberToText(wp, result);
                }
            }
;
        }

        private void numberToCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedtext = AddUtilities.getSelectedText(wp);
            if (String.IsNullOrEmpty(selectedtext))
            {
                NumberToTextForm convertNumberForm = new NumberToTextForm(wp, 3);
                convertNumberForm.ShowDialog();
            }
            else
            {
                Decimal result;
                if (Decimal.TryParse(selectedtext, NumberStyles.Currency, CultureInfo.CurrentCulture, out result))
                {
                    AddUtilities.ConvertNumberToCurrency(wp, result);
                }
            }
        }

        private void asTextAlwaysIncludeDecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedtext = AddUtilities.getSelectedText(wp);
            if (String.IsNullOrEmpty(selectedtext))
            {
                NumberToTextForm convertNumberForm = new NumberToTextForm(wp, 4);
                convertNumberForm.ShowDialog();
            }
            else
            {
                Decimal result;
                if (Decimal.TryParse(selectedtext, NumberStyles.Number, CultureInfo.CurrentCulture, out result))
                {
                    AddUtilities.ConvertNumberToText(wp, result, false);
                }
            }
        }

        private void sampleTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create sample dataset to populate table
            List<string[]> widgets = new List<string[]>();
            string[] row = new string[3] { "Widget", "Market Share", "Cost" };
            widgets.Add(row);
            row = new  string[3] {"blumbers", "80", "$125"};
            widgets.Add(row);
            row = new  string[3] {"clumbers", "12", "$95" };
            widgets.Add(row);
            row = new string[3] { "trumbers", "8", "$36" };
            widgets.Add(row);

            int[] weight = new int[3]{10, 3, 2};    // proportionate widths of each column

            AddUtilities.InsertTable(wp, widgets, weight, true);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUtilities.MarkTextforDeletion(wp, true);
            AddUtilities.UnderlineText(wp);
            
        }

        private void randomTextAndPlaceCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "This feature inserts text and then places the cursor for the user to insert a number";
            AddUtilities.InsertRandomText(wp, text);
        }

        private void sampleMergeLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create 2 companies and 2 customers
            List<Company> companyList = CreateDataSets.createCompanies();
            List<Customer> customerList = CreateDataSets.createCustomers();
            //create merge letters

            AddUtilities.InsertMergeLetters(wp, companyList, customerList);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AddUtilities.insertHelloWorld(wp);
        }



    }
}
