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
            string cents;
        public NumberModel ConvertNumberToString(string startingNumber)
        {   
            char[] array = startingNumber.Split(".")[0].ToCharArray();
            
            if(startingNumber.Contains("."))
            {
                cents = startingNumber.Split(".")[1];
            }
            
            var numberModel = new NumberModel();
            
                if(array.Length == 4)
                {
                    var number = int.Parse(array[0].ToString()); 
                    if (number != 0)
                    {
                        numberModel.NumberString = $"{digits[number - 1]} {columns[0]} ";
                    }

                    number = int.Parse(array[1].ToString()); 
                    if (number != 0)
                    numberModel.NumberString += digits[number - 1] + " " + columns[1] + " ";

                    number = int.Parse(array[2].ToString()); 
                    if (number == 1 && number != 0) //teens
                    {
                        number = 10 + int.Parse(array[3].ToString());
                        numberModel.NumberString += digits[number - 1];
                    }
                    else if (number !=0)
                    {   
                        numberModel.NumberString += tens[number - 2] + "-";
                        number = int.Parse(array[3].ToString());
                        numberModel.NumberString += digits[number - 1];
                    }
                    else
                    {
                        number = int.Parse(array[3].ToString());
                        if (number !=0)
                        numberModel.NumberString += digits[number - 1];
                    }

                }

                if(array.Length == 3)
                {
                    var number = int.Parse(array[0].ToString()); 
                    if (number != 0)
                    numberModel.NumberString = digits[number - 1] + " " + columns[1] + " ";

                    number = int.Parse(array[1].ToString()); 
                    if (number == 1 && number != 0) //teens
                    {
                        number = 10 + int.Parse(array[2].ToString());
                        numberModel.NumberString += digits[number - 1];
                    }
                    else if(number != 0)
                    {
                        numberModel.NumberString += tens[number - 2] + "-";
                        number = int.Parse(array[2].ToString());
                        numberModel.NumberString += digits[number - 1];
                    }
                    else
                    {   
                        number = int.Parse(array[2].ToString());
                        if (number !=0)
                        numberModel.NumberString += digits[number - 1];
                    }
                   
                }

                if(array.Length == 2)
                {
                    var number = int.Parse(array[0].ToString()); 
                    if (number == 1 && number != 0) //teens
                    {
                        number = 10 + int.Parse(array[1].ToString());
                        numberModel.NumberString = digits[number - 1];
                    }
                    else if(number != 0)
                    {
                        numberModel.NumberString = tens[number - 2] + "-";
                        number = int.Parse(array[0].ToString());
                        numberModel.NumberString += digits[number - 1];
                    }
                    else
                    {   
                        number = int.Parse(array[0].ToString());
                        if (number != 0)
                        {
                            numberModel.NumberString += digits[number - 1];
                        }
                        else 
                        {
                            number = int.Parse(array[1].ToString());
                            numberModel.NumberString += digits[number - 1];
                        }

                    }
                    
                }

                if(array.Length == 1)
                {
                    var number = int.Parse(array[0].ToString());
                    if (number == 0)
                    {
                        numberModel.NumberString = "zero";
                    }
                    else
                    {
                        numberModel.NumberString = digits[number - 1]; 
                    }
                               
                }
            if (cents == "")
            {
                cents = "00";
            }
            numberModel.NumberString += $" and {cents}/100 dollars";
            return numberModel;
        }
    }
}