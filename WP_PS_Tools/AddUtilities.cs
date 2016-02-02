using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NumbersToText;
using FakeCompany;




namespace WP_PS_Tools

{
    public static class AddUtilities
    {

        /// <summary>
        /// This is an example of marking text for deletion by changing the selected text's attributes
        /// to include strikeout and surrounding the selected text with brackets.
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="endSpace"></param>
        public static void MarkTextforDeletion(WP_Window wp, bool endSpace = false)
        {
            wp.initPerfectScript();
            string deleteText = wp.PS.envSelectedText();

            if (!string.IsNullOrEmpty(deleteText))
            {
                wp.PS.BookmarkCreate("selectedText", 1); //   WordPerfect._BookmarkCreate_Selected_enum.Yes_BookmarkCreate_Selected); 
                wp.PS.BookmarkBlock("selectedText");
                wp.PS.AttributeAppearanceOn(13);
                wp.PS.PosBlockTop();
                wp.PS.SelectOff();
                wp.PS.AttributeAppearanceOff(13);
                wp.PS.KeyType("[");
                wp.PS.BookmarkBlock("selectedText");
                wp.PS.PosBlockBottom();
                wp.PS.SelectMode(0);                  //(WordPerfect._SelectMode_State_enum.Off_SelectMode_State);
                wp.PS.AttributeAppearanceOff(13);
                wp.PS.KeyType("]");
                if (endSpace)
                {
                    wp.PS.KeyType(" ");
                }
                wp.PS.BookmarkDelete("selectedText");
            }
            wp.releaseScript();
        }


        /// <summary>
        /// This underlines selected text or if no text is selected, turns on underlining at the insertion point
        /// Yes, it's essentially the same function as Ctrl-U, but is used in combination with other method calls.
        /// </summary>
        /// <param name="wp"></param>
        public static void UnderlineText(WP_Window wp)
        {
            wp.initPerfectScript();
            string insertText = wp.PS.envSelectedText();
            wp.PS.AttributeAppearanceOn(14); // this is one of the missing enumerations of WP in .NET, so just use the integer equivalent
            wp.PS.SelectOff();
            wp.releaseScript();

        }

        /// <summary>
        /// places insertion point and cursor at specified search string.
        ///  If text is not found, does nothing.
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="text"></param>
        /// <param name="before"></param>
        /// <param name="forward"></param>
        /// <param name="caseSensitive"></param>
        public static void PlaceCursor(WP_Window wp, string text, bool before = false, bool forward = false, bool caseSensitive = true)
        {
            try
            {
                wp.PS.SearchString(text);
                if (caseSensitive)
                {
                    wp.PS.SearchCaseSensitive(1);   // (WordPerfect._SearchCaseSensitive_State_enum.Yes_SearchCaseSensitive_State);
                }
                else
                {
                    wp.PS.SearchCaseSensitive(0);   // (WordPerfect._SearchCaseSensitive_State_enum.No_SearchCaseSensitive_State);
                }

                wp.PS.MatchSelection();
                if (before)
                {
                    wp.PS.MatchPositionBefore();
                }
                else
                {
                    wp.PS.MatchPositionAfter();
                }
                if (forward)
                {
                    wp.PS.SearchNext();
                }
                else
                {
                    wp.PS.SearchPrevious();
                }                
            }
            catch
            {
                // WP throws an exception if search string is not found
                // so just do nothing
            }

        }


        /// <summary>
        /// calls NumToText.ConvertToLegalDollarText to convert number into 
        /// text dollars followed by the currency amount
        /// Then inserts that text into WP document
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="number"></param>
        /// <param name="decimalLength"></param>
        /// <param name="decimalFraction"></param>
        public static void ConvertNumberToMoney(WP_Window wp, Decimal number, int decimalLength =2, bool decimalFraction = true)
        {
            wp.initPerfectScript();
            string text = NumToText.ConvertToLegalDollarText(number, decimalLength, decimalFraction);
            if (!String.IsNullOrEmpty(text))
            {
                wp.PS.KeyType(text);
            }
            wp.releaseScript();
        }


        /// <summary>
        /// calls NumToText.ConvertToText to convert number to text, including decimal options
        /// Then inserts that text into WP document
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="number"></param>
        /// <param name="ignoreDecimal"></param>
        /// <param name="decimalLength"></param>
        /// <param name="decimalFraction"></param>
        public static void ConvertNumberToText(WP_Window wp, Decimal number,
            bool ignoreDecimal = true, int decimalLength = 2, bool decimalFraction = true)
        {
            wp.initPerfectScript();
            string text = NumToText.ConvertToText(number, ignoreDecimal, decimalLength, decimalFraction);
            if (!String.IsNullOrEmpty(text))
            {
                wp.PS.KeyType(text);
            }
            wp.releaseScript();
        }


        /// <summary>
        /// calls NumToText.ConvertToCurrency to convert number to text, including decimal options
        /// Then inserts that text into WP document
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="number"></param>
        public static void ConvertNumberToCurrency(WP_Window wp, Decimal number)
        {
            wp.initPerfectScript();
            string text = NumToText.ConvertToCurrency(number);
            if (!String.IsNullOrEmpty(text))
            {
                wp.PS.KeyType(text);
            }
            wp.releaseScript();

        }


        /// <summary>
        /// create table that fills the page, and set the column widths based on a relative "weighting"
        /// passed as a variable
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="text"></param>
        /// <param name="weight"></param>
        /// <param name="header"></param>
        public static void InsertTable(WP_Window wp, List<string[]> text, int[] weight, bool header = false)
        {
            wp.initPerfectScript();

            int numRows = text.Count;   // set number of rows based on number of entries in the List "text"
            int numColumns = text[0].Length;    // set number of columns based on the first array in text
            int totalWeight = weight.Sum();     

            int leftMargin = wp.PS.envMarginLeft();    // get left margin.  These are returned as WPUs, or 1/1200th inch         
            int rightMargin = wp.PS.envMarginRight();
            int paperWidth = wp.PS.envPaperWidth();
            int usableWidth = paperWidth - rightMargin - leftMargin;

            wp.PS.KeyType("\n");    // could be optional, depending on where you are in document

            wp.PS.TableCreate((short)numColumns, (short)numRows);

            foreach (int i in weight)       // set column widths according to document width and relative weights passed as parameter
            {
                wp.PS.TableSelectOn(3);     // (WordPerfect._TableSelectOn_SelectionMode_enum.Column_TableSelectOn_SelectionMode);      // 3
                int columnWidth = (int)((double)i / (double)totalWeight * (double)usableWidth);
                wp.PS.TableColumnWidth((short)columnWidth); // WP wants this value to be a short-- you may need to experiment with commands until you get the right data type!
                wp.PS.TableColumnJustification(2);      // (WordPerfect._TableColumnJustification_Mode_enum.Center_TableColumnJustification_Mode);        // 2
                wp.PS.PosColNext();
            }
            wp.PS.PosTableBegin();      // move insertion point to table beginning
            int index = 0;
            if (header)
            {    // if there is a header, underscore first row in table
                foreach (string t in text[0])
                {
                    wp.PS.AttributeAppearanceOn(14);
                    wp.PS.KeyType(t);
                    wp.PS.PosColNext();
                }
                index = 1;

            }
            wp.PS.PosColFirst();
            for (int i = index; i < text.Count; i++)    // populate table starting at first empty row
            {
                foreach (string t in text[i])
                {
                    if (!string.IsNullOrEmpty(t))
                    {
                        wp.PS.KeyType(t.Trim());
                    }
                    wp.PS.PosColNext();
                }
            }
            wp.PS.PosLineDown();
            wp.releaseScript();
        }

        /// <summary>
        /// inserts a sentence into the document and then places the cursor at a specified point
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="text"></param>
        public static void InsertRandomText(WP_Window wp, string text)
        {
            wp.initPerfectScript();
            wp.PS.KeyType(string.Format("Item .  {0}.", text));
            PlaceCursor(wp, "Item ", false, false, true);
            wp.releaseScript();
        }



        /// <summary>
        /// Opens a sample template letter that has several named bookmarks and then
        /// creates  "merged" documents from sample lists of companies sending the letter
        /// and customers receiving it.
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="companyList"></param>
        /// <param name="customerList"></param>
        public static void InsertMergeLetters(WP_Window wp, List<Company> companyList, 
            List<Customer> customerList)
        {
            wp.initPerfectScript();
            wp.PS.FileOpen("SampleMergeLetter.wpt");    //open the template letter (for pedagogical purposes; no need to open it twice in the real world);
            wp.PS.PosDocTop();
            wp.PS.KeyType("This is an example of how you can use bookmarks to create a \"Merge\" letter using modern .NET tools. ");

            foreach (Customer customer in customerList) // main loop to create a letter for each customer
            {
                // select company by examining customer product
                Company company = companyList.FirstOrDefault(p => p.product == customer.product);

                wp.PS.FileOpen("SampleMergeLetter.wpt");


                wp.PS.BookmarkBlock("CompanyMasthead"); // First, find the "CompanyMasthead" bookmark and then select it
                wp.PS.KeyType("");  //not sure why this is needed in order to turn on an attribute
                wp.PS.AttributeAppearanceOn(12);    // bold
                //get the correct data from the current company object.  This has the effect of replacing the selected text.
                wp.PS.KeyType(string.Format("{0} Corporation\n{1}", company.name, company.address.ToString()));                       
                wp.PS.AttributeAppearanceOff(12); // turn off bold
                wp.PS.BookmarkDelete("CompanyMasthead");  // getting rid of extraneous codes--optional

                wp.PS.BookmarkBlock("Date");
                //use native DateTime class with specified format (out of hundreds of options and unlimited custom formats)
                wp.PS.KeyType(DateTime.Now.ToString("MMMM d, yyyy"));
                wp.PS.BookmarkDelete("Date");

                wp.PS.BookmarkBlock("Name");
                wp.PS.KeyType(string.Format("{0} {1}", customer.firstName, customer.lastName));
                wp.PS.BookmarkDelete("Date");

                wp.PS.BookmarkBlock("Address");
                wp.PS.KeyType(customer.address.ToString());
                wp.PS.BookmarkDelete("Address");

                wp.PS.BookmarkBlock("Salutation");
                // extract the correct salutation from the dictionary "salutation" in the CreateDataSets class based on the gender of the customer.
                wp.PS.KeyType(string.Format("{0} {1}", CreateDataSets.salutation[customer.gender], customer.lastName));
                wp.PS.BookmarkDelete("Salutation");

                wp.PS.BookmarkBlock("Company");
                wp.PS.KeyType(string.Format("{0} Corporation", company.name));
                wp.PS.BookmarkDelete("Company");

                wp.PS.BookmarkBlock("Product");
                wp.PS.KeyType(string.Format("{0} {1}", company.name, company.product));
                wp.PS.BookmarkDelete("Product");

                // calculate when the last customer purcahse was
                DateTime now = DateTime.Now;
                int daysSincePurchase = (now - customer.dateOfPurchase).Days;

                wp.PS.BookmarkBlock("TimeSpan");
                wp.PS.KeyType(string.Format("{0} days", daysSincePurchase.ToString()));
                wp.PS.BookmarkDelete("TimeSpan");

                wp.PS.BookmarkBlock("Product1");
                wp.PS.KeyType(string.Format("{0} {1}", company.name, company.product));
                wp.PS.BookmarkDelete("Product1");

                // give different purcahse ultimatum based on daysSincePurchase
                DateTime deadline;
                if (daysSincePurchase > 365)
                {
                    deadline = now.AddDays(30);
                }
                else
                {
                    deadline = now.AddDays(60);
                }
                wp.PS.BookmarkBlock("Deadline");
                wp.PS.KeyType(deadline.ToString("MMMM d, yyyy"));
                wp.PS.BookmarkDelete("Deadline");

                wp.PS.BookmarkBlock("infestation");
                wp.PS.KeyType(company.motivationalTool);
                wp.PS.BookmarkDelete("infestation");

                wp.PS.BookmarkBlock("SenderInfo");
                wp.PS.KeyType(string.Format("{0} Enforcement Team", company.name));
                wp.PS.BookmarkDelete("SenderInfo");
            }


            wp.releaseScript();
        }


        public static void insertHelloWorld(WP_Window wp)
        {
            wp.initPerfectScript();
            wp.PS.KeyType("Hello WordPerfect World!\n");
            wp.releaseScript();
        }

        /// <summary>
        /// returns a string containing the selected text in WP
        /// </summary>
        /// <param name="wp"></param>
        /// <returns></returns>
        public static string getSelectedText(WP_Window wp)
        {
            wp.initPerfectScript();
            string selectedtext = wp.PS.envSelectedText();
            wp.releaseScript();
            return selectedtext;
        }


    }
}
