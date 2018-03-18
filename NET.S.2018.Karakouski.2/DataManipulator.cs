﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.S._2018.Karakouski._2
{
    /// <summary>
    /// Class impliments InsertNumber, FindNextBiggerNumber and FilterDigit methods in order to solve day 2 .NET lab tasks
    /// </summary>
    public static class DataManipulator
    {
        /// <summary>
        /// Inset bits of one number into another within given location
        /// </summary>
        /// <param name="numberSource"></param>
        /// <param name="numberIn"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j)
                throw new ArgumentException();
            if (i < 0  || i > 31)
                throw new ArgumentException(nameof(i));
            if (j < 0 || j > 31)
                throw new ArgumentException(nameof(j));

            int count = i;
            BitArray bitArrSource = new BitArray(new int[] { numberSource });
            BitArray bitArrIn = new BitArray(new int[] { numberIn });
            
            for(int iterator=0; count <= j; iterator++, count++)
            {
                bitArrSource.Set(count, bitArrIn.Get(iterator));
            }

            int[] temp = new int[1];
            bitArrSource.CopyTo(temp, 0);
            return temp[0];
        }

        /// <summary>
        /// Finds, if any, the next bigger number consisting of the same digits as given
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int? FindNextBiggerNumber(int number)
        {
            string stringNumber = number.ToString();
            char? firstSmallerDigit = null;
            int firstSmallerDigitPosition = -1;

            for(int i= stringNumber.Length-1; i>0; i--)
            {
                if (stringNumber[i-1] < stringNumber[i])
                {
                    firstSmallerDigit = stringNumber[i];
                    firstSmallerDigitPosition = i;
                }
            }

            if (firstSmallerDigit == null)
                return null;

            int smallestToTheRighOfFoundPosition = firstSmallerDigitPosition + 1;
            char smallestToTheRighOfFound = stringNumber[smallestToTheRighOfFoundPosition];

            for (int i = firstSmallerDigitPosition + 2; i < stringNumber.Length; i++)
            {
                if (stringNumber[i] > firstSmallerDigit && stringNumber[i] < smallestToTheRighOfFound)
                {
                    smallestToTheRighOfFound = stringNumber[i];
                    smallestToTheRighOfFoundPosition = i;
                }
            }

            return null;
        }

        /// <summary>
        /// Filters a sequence of input number in the way that it contatins only numbers with given digits using String.Contains and ArrayLists
        /// </summary>
        /// <param name="listInts"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static ArrayList FilterDigit3(int[] listInts, int number)
        {
            if (listInts.Length == 0)
            {
                throw new ArgumentException();
            }
            ArrayList listFilter = new ArrayList();
            for (int i = 0; i < listInts.Length; i++)
            {
                string supportString = listInts[i].ToString();
                string numberString = number.ToString();
                if (supportString.Contains(numberString))
                {
                    listFilter.Add(listInts[i]);
                }
            }
            return listFilter;
        }

        /// <summary>
        /// Filters a sequence of input number in the way that it contatins only numbers with given digits using String.Contains and Arrays
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static int[] FilterDigit2(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));

            if (numbers == null)
                throw new ArgumentException(nameof(numbers));

            if (numbers.Length == 0)
                return null;

            int[] result = new int[0];
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = numbers[i];
                }
            }

            return result;
        }

        /// <summary>
        /// Filters a sequence of input number in the way that it contatins only numbers with given digits using String.Contains and Lists
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static int[] FilterDigit1(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));

            if (numbers == null)
                throw new ArgumentException(nameof(numbers));

            if (numbers.Length == 0)
                return null;

            List<int> result = new List<int>();
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    result.Add(numbers[i]);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Filters a sequence of input number in the way that it contatins only numbers with given digits using devision
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static int[] FilterDigit(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));

            if (numbers == null)
                throw new ArgumentException(nameof(numbers));

            if (numbers.Length == 0)
                throw new ArgumentException(nameof(numbers));

            List<int> result = new List<int>();
            foreach (var element in numbers)
            {
                if (IsContainsDigit(element, digit))
                    result.Add(element);
            }
            return result.ToArray();
        }

        private static bool IsContainsDigit(int number, int digit)
        {
            while (number != 0)
            {
                if (number % 10 == digit) return true;
                number = number / 10;
            }
            return false;
        }
        
    }

     
 
}

