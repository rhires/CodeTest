using System;
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
            var numberModel = new NumberModel();

            var number = Convert.ToInt32(startingNumber.Split(".")[0]);

            if(number >= 1000)
            {
                var result = (number - (number % 1000)) / 1000;
                numberModel.NumberString = $"{digits[result - 1]} {columns[0]} ";  
                number = number % 1000;
            }

            if(number >= 100)
            {
                var result = (number - (number % 100)) / 100;
                numberModel.NumberString += $"{digits[result - 1]} {columns[1]} "; 
                number = number % 100;
            } 

            if(number >= 20)
            {
                var result = (number - (number % 10)) / 10;
                numberModel.NumberString += $"{tens[result - 2]}"; 
                number = number % 10;
                if(number != 0)
                numberModel.NumberString += $"-{digits[number - 1]} "; 
            }
            else 
            {
                var result = (number - (number % 10)) / 10;
                numberModel.NumberString += $"{digits[number - 1]} "; 
            }

            if(startingNumber.Contains("."))
            {
                cents = startingNumber.Split(".")[1];
            }
            
            if (cents == "" || cents == null)
            {
                cents = "00";
            }

            char[] cap = numberModel.NumberString.ToCharArray();
            cap[0] = char.ToUpper(cap[0]);
            numberModel.NumberString = new string(cap);
            numberModel.NumberString += $" and {cents}/100 dollars";
            
            return numberModel;
        }
    }
}