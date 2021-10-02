namespace StringCalculator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StringCalculator
    {
        #region Fields

        private const string customDelimiter = "//";
        private List<string> delimiters = new List<string>() { ",", "\n" };

        #endregion Fields

        #region Methods

        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers))
                return 0;

            if (numbers.StartsWith(customDelimiter))
            {
                numbers = AddCustomDelimiters(numbers);
            }

            var cleanedNumbers = numberForAddition(numbers);

            return cleanedNumbers.Sum();
        }

        #endregion Methods

        #region Private Methods

        private string AddCustomDelimiters(string numbers)
        {
            string[] customSeperators = { customDelimiter, "[", "]" };
            var customSeperator = numbers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            numbers = numbers.Substring(customSeperator.Length, numbers.Length - customSeperator.Length);
            var allCustomSeperators = customSeperator.Split(customSeperators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sep in allCustomSeperators)
            {
                delimiters.Add(sep);
            }
            return numbers;
        }

        private IList<int> numberForAddition(string numbers)
        {
            var nums = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var cleaned = new List<int>();
            bool isNegative = false;
            List<string> negativeNumbers = new List<string>();
            foreach (var num in nums)
            {
                var cleanedNumber = int.Parse(num);
                if (cleanedNumber < 0)
                {
                    isNegative = true;
                    negativeNumbers.Add(num);
                }
                else
                {
                    cleaned.Add(cleanedNumber);
                }
            }

            if (isNegative)
            {
                if (negativeNumbers.Count > 1)
                {
                    throw new Exception($"Negatives not allowed: {String.Join(",", negativeNumbers)}");
                }
                else
                {

                    throw new Exception("Negatives not allowed");
                }
            }

            return cleaned;

        }

        #endregion Private Methods
    }
}
