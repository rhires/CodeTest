using System.Collections.Generic;
using codeTest.Models;

namespace codeTest.Services
{
    public class NumberToStringService : INumberToStringService
    {
        string[] columns = {
                "thousand", "hundred" 
            };

            string[] digits = {
                "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" ,
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"               
            };

            string[] tens = {
                "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };

            string[] other = {
                "and", "-"
            };
        public NumberModel ConvertNumberToString(string startingNumber)
        {   
            char[] array = startingNumber.ToCharArray();
            string model;
            var numberModel = new  NumberModel();
            foreach(var num in array)
            {
                if(array.Length == 4)
                {
                    if(num == '0')
                    {
                        break;
                    }
                    var number = int.Parse(array[0].ToString()); 
                    model = digits[number - 1] + " " + columns[0] + " ";

                    number = int.Parse(array[1].ToString()); 
                    if (num != '0')
                    model += digits[number - 1] + " " + columns[1] + " ";

                    number = int.Parse(array[2].ToString()); 
                    if (number == 1) //teens
                    {
                        number = 10 + int.Parse(array[3].ToString());
                        model += digits[number - 1];
                    }
                    else
                    {   
                        model += tens[number - 2] + " ";
                        number = int.Parse(array[3].ToString());
                        model += digits[number - 1];
                    }
                   numberModel.NumberString = model;
                }

                if(array.Length == 3)
                {
                    var number = int.Parse(array[1].ToString()); 
                    model = digits[number - 1] + " " + columns[1] + " ";

                    number = int.Parse(array[1].ToString()); 
                    if (number == 1) //teens
                    {
                        number = 10 + int.Parse(array[2].ToString());
                        model += digits[number - 1];
                    }
                    else
                    {   
                        model += tens[number - 2] + " ";
                        number = int.Parse(array[2].ToString());
                        model += digits[number - 1];
                    }
                    numberModel.NumberString = model;
                }

                if(array.Length == 2)
                {
                    var number = int.Parse(array[0].ToString()); 
                    if (number == 1) //teens
                    {
                        number = 10 + int.Parse(array[1].ToString());
                        model = digits[number - 1];
                    }
                    else
                    {   
                        model = tens[number - 2] + " ";
                        number = int.Parse(array[0].ToString());
                        model += digits[number - 1];
                    }
                    numberModel.NumberString = model;
                }

                if(array.Length == 1)
                {
                    var number = int.Parse(array[0].ToString());
                    model = digits[number - 1];
                    numberModel.NumberString = model;                    
                }
            }
            
            return numberModel;
        }
    }
}