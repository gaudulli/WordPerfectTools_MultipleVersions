using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumbersToText
{
    public static class NumToText
    {
        /// <summary>
        /// converts number to text and currency in legal style
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertToLegalDollarText(decimal number, int decimalLength = 2, bool decimalFraction = true)
        {
            if (number > 0 && number <= long.MaxValue)
            {               
                bool ignoreCents = (number >= 100);
                //convert dollars and cents to the designated decimal place
                long dollars = ConvertToInt(number);
                int cents = GetDecimalFraction(number, decimalLength);
                int centsFraction = 0;  //used if portion of cent is needed
                string centsFractionText = "";

                //convert back to decimal number with correct number of decimal places
                number = dollars + (decimal)(cents / Math.Pow(10, decimalLength));
                string currency = "(" + ConvertToCurrencyText(number, ignoreCents, decimalLength) + ")";


                string dollarsText = ConvertNumberToText(dollars);
                switch (dollars)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            dollarsText += " dollar ";
                            break;
                        }
                    default: 
                        {
                            dollarsText += " dollars ";
                            break;
                         }
                }
                string centsText = "";
                if (ignoreCents)
                {
                    return dollarsText + currency;
                }
                else
                { 
                    if (decimalLength > 2)  //convert to fractions of a cent
                    {
                        //need to remove integer cents from fractions of a cent
                        int exp = (int)Math.Pow(10, decimalLength - 2);
                        centsFraction = cents - (((int)(cents / exp)) * exp);
                        cents = (int)(cents / Math.Pow(10, decimalLength - 2));
                        centsFractionText = GetFractionalString(centsFraction, decimalLength - 2, decimalFraction);
                        if (number > 1 && centsFraction > 0 && cents >0)
                        {
                            centsFractionText = " and " + centsFractionText;
                        }

                    }
                        centsText = ConvertNumberToText(cents);
                        centsText += centsFractionText;
                        if (cents + ((decimal)centsFraction/100) > 0
                            && cents + ((decimal)centsFraction / 100) <= 1)
                        {
                            centsText += " cent ";
                        }
                        else if (cents + ((decimal)centsFraction / 100) > 1)
                        {
                            centsText += " cents ";
                        }

                    return dollarsText + centsText + currency;
                }

            }
            else return "";
        }



        /// <summary>
        /// converts number to integer value plus decimal value if indicated
        /// </summary>
        /// <param name="number"></param>
        /// <param name="ignoreDecimal"></param>
        /// <returns></returns>
        public static string ConvertToText(decimal number, bool ignoreDecimal = true, int decimalLength = 2, bool decimalFraction = true)
        {
            if (number > 0 && number <= long.MaxValue)
            {
                long integerNumber = ConvertToInt(number);
                int fractionalNumber = GetDecimalFraction(number, decimalLength);

                string integerNumberText = ConvertNumberToText(integerNumber);
                if (ignoreDecimal)
                {
                    return integerNumberText;
                }
                else //include decimal fraction portion of number to the designated number of places
                {
                    string decimalNumbertext = GetFractionalString(fractionalNumber, decimalLength, decimalFraction);
                    if (number >1 && fractionalNumber > 0)
                    {
                        decimalNumbertext = " and " + decimalNumbertext;
                    }
                    return integerNumberText  + decimalNumbertext;
                }
                
            }
            else return "";
        }


        /// <summary>
        /// converts number to US currency
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertToCurrency(decimal number, bool ignoreCents = false, int decimalLength =2)
        {

            if (number > 0 && number <= long.MaxValue)
            {
                //convert dollars and cents to the designated decimal place
                long dollars = ConvertToInt(number);
                int cents = GetDecimalFraction(number, decimalLength);

                //convert back to decimal number with correct number of decimal places
                number = dollars + (decimal)(cents / Math.Pow(10, decimalLength));
                string currency = ConvertToCurrencyText(number, ignoreCents, decimalLength);

                return currency;
            }
            else
            { 
                return "";
            }
        }



        /// <summary>
        /// returns integer portion of number (truncates; no rounding)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static long ConvertToInt(decimal number)
        {
            return (long)number;
        }

        /// <summary>
        /// returns decimal portion of number as integer to the designated number of decimal places 
        /// No rounding
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numDecimalPoints"></param>
        /// <returns></returns>
        private static int GetDecimalFraction(decimal number, int numDecimalPoints)
        {
            decimal num = number - ConvertToInt(number);


            return  (int)(num * (int)Math.Pow(10, numDecimalPoints));

        }



        /// <summary>
        /// returns currency displayed as text
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="ignoreCents"></param> indicates whether the cents portion should be ignored
        /// <returns></returns>
        private static string ConvertToCurrencyText(decimal number, bool ignoreCents = true, int decimalLength = 2)
        {
            if (ignoreCents)
            {
                long dollars = (long)number;  //casting this way just truncates the number with no rounding           
                string dollarText = dollars.ToString("C0");
                return dollarText;
            }
            else
            {
                return number.ToString(String.Format("C{0}",decimalLength));
            }
        }


        /// <summary>
        /// returns the text representation of an integer.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string ConvertNumberToText(long number)
        {
            string strNumber = number.ToString();
            string numberTextBuilder = "";
            if (number > 999)
            {
                List<string> thousandMultiple = Split(number.ToString(), 3).ToList();
                thousandMultiple.Reverse();
                for (int i = 0; i < thousandMultiple.Count; i++)
                {
                    if (Convert.ToInt16( thousandMultiple[i]) > 0)
                    {
                        numberTextBuilder = getHundredsText(thousandMultiple[i]) + " " + TextNumbers.multiples[i] + " " + numberTextBuilder;
                    }
                    
                    numberTextBuilder = numberTextBuilder.Trim();
                }
            }
            else
            {
                numberTextBuilder = getHundredsText(strNumber);
            }
            return numberTextBuilder;



        }


        /// <summary>
        /// returns the text representation
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string getHundredsText(string str)
        {

            string hundredsText = "";
            int num = Int32.Parse(str);

            if (num > 0)    /// if num = 0, return empty string
            {
                str = str.Trim();   // trim extra spaces in string (happens if number is < 100)
                if (str.Count().Equals(3))
                {
                    int hundreds = Int32.Parse(str[0].ToString());
                    if (hundreds > 0)
                    {
                        hundredsText += TextNumbers.firstHundred[hundreds] + " hundred ";
                    }
                    str = str.Remove(0, 1);
                }
                hundredsText += TextNumbers.firstHundred[Int32.Parse(str)];
            }
            return hundredsText.Trim();
        }



        private static IEnumerable<string> Split(string str, int chunkSize)
        {
            int mod = str.Length % chunkSize;
            bool hasMod = mod >= 1;
            int multiples = (str.Length / chunkSize) + Convert.ToInt32(hasMod);
            if (hasMod)
            {
                for (int i = mod; i < 3; i++)
                {
                    str = " " + str;
                }
            }            
            return Enumerable.Range(0, multiples)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }


        /// <summary>
        /// convert integer into text representation of a fraction
        /// </summary>
        /// <param name="number"></param>needs to be already shortened to the desired length
        /// <param name="decimalFraction"></param>either use decimal fractions or convert to
        ///                                         LCD and use integral fraction
        /// <returns></returns>
        private static string GetFractionalString(int number, int decimalLength, bool decimalFraction)
        {
            string text;
            if (number > 0)
            {
                if (!decimalFraction)
                {
                    text = getIntegerFractionalString(number, decimalLength);
                    return text;
                }
                else
                {
                    if (number >= Math.Pow(10, 4))   //reduce number to no greater than 10,000
                    {
                        number = (int)(number / Math.Pow(10, decimalLength - 4));
                        decimalLength = 4;
                    }

                    string denominator = TextNumbers.decimalFractions[decimalLength - 1];
                    if (number > 1)
                    {
                        denominator += "s";
                    }
                    text = ConvertNumberToText(number) + " " + denominator;
                    if (decimalLength == 1)
                    {
                        text = text.Replace(' ', '-');  // depending on your style, may need to change this...
                    }

                    return text;
                }
            }
            else 
            { 
                return "";
            }
        }


        private static string getIntegerFractionalString(int number, int decimalLength)
        {
            string text;
            int tempDecimalLength = 4;
            if (number >= Math.Pow(10, 4))   //reduce number to no greater than 10,000
            {
                number = (int)(number / Math.Pow(10, 4));
                tempDecimalLength = 4;
            }
            BigInteger numerator, denominator, GCD = new BigInteger();

            int test = (int)Math.Log10(number);
            Console.WriteLine(test);


            numerator = (int)(number * Math.Pow(10, tempDecimalLength-decimalLength));
            //numerator = (int)(number * Math.Pow(10, (int)Math.Log10(number)));
            denominator = (int)Math.Pow(10, tempDecimalLength);

            GCD = BigInteger.GreatestCommonDivisor(numerator, denominator);
            numerator = numerator / GCD;
            denominator = denominator / GCD;

            string s = "";
            if (numerator > 1)
            {
                s = "s";
            }
            // If denominator is outside range of list of "useful" integer fractions
            if (denominator > TextNumbers.integralFractions.Count()-1)                
            {
                //find correct multiple of 10 to display fraction
                if ( numerator == 10 || numerator == 100 || numerator ==1000
                    || numerator == 10000)
                {
                    int numeratorLog = (int)Math.Log10((int)denominator);
                     
                    text = ConvertNumberToText((int)numerator) + " " + TextNumbers.decimalFractions[numeratorLog - 1] + s;
                }
                else
                {
                    return GetFractionalString(number, decimalLength, true);
                }
            }
            else
            {
                text = ConvertNumberToText((int)numerator) + "-" + TextNumbers.integralFractions[(int)denominator] + s;
            }

            return text;
        }




    }
}
