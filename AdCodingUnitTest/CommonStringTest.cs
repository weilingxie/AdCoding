using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdCodingApp;
using System.Collections.Generic;

namespace AdCodingUnitTest
{
    [TestClass]
    public class CommonstringTest
    {
        private String s1;
        private String s2;
        private List<String> sList;
        private String overlap;
        private String result;
        private String expected;
        private List<String> expectedList;


        /*
             Test Method FindLongestSubstring
         */

        [TestMethod]
        public void ShouldReturnSubstring_WhenTwoStringsHasOverlap()
        {
            s1 = "abcd";
            s2 = "cdef";
            expected = "cd";
            result = CommonString.FindLongestSubstring(s1, s2);
            Assert.Equals(expected, result);
        }

        [TestMethod]
        public void ShouldReturnNull_WhenTwoStringsHasNoOverlap()
        {
            s1 = "abcd";
            s2 = "efgh";
            expected = null;
            result = CommonString.FindLongestSubstring(s1, s2);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ShouldReturnEitherString_WhenTwoStringsHasTwoOverlap()
        {
            s1 = "abcd";
            s2 = "cdeab";
            expectedList.Clear();
            expectedList.Add("ab");
            expectedList.Add("cd");
            result = CommonString.FindLongestSubstring(s1, s2);            
            Assert.IsNotNull(expectedList.Find(expect => expect == result));
        }

        [TestMethod]
        public void ShouldReturnChildString_WhenOneStringsContainsAnother()
        {
            s1 = "abcd";
            s2 = "bc";
            expected = "bc";
            result = CommonString.FindLongestSubstring(s1, s2);
            Assert.Equals(expected, result);
            result = CommonString.FindLongestSubstring(s2, s1);
            Assert.Equals(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "String shouldn't be null")]
        public void ShouldThrowException_WhenOneOrTwoStringsAreNull()
        {
            s1 = "abcd";
            s2 = null;
            result = CommonString.FindLongestSubstring(s1, s2);            
            result = CommonString.FindLongestSubstring(s2, s1);
            result = CommonString.FindLongestSubstring(s2, s2);
        }

        /*
             Test Method ConcatTwoString
         */

        [TestMethod]
        public void ShouldReturnConcatstring_WhenTwoStringsHasOverlap()
        {
            s1 = "abcd";
            s2 = "cdef";
            overlap = "cd";
            expected = "abcdef";
            result = CommonString.ConcatTwoString(s1, s2, overlap);
            Assert.Equals(expected, result);
        }

        [TestMethod]
        public void ShouldReturnConcatString_WhenTwoStringsHasNoOverlap()
        {
            s1 = "abcd";
            s2 = "efgh";
            overlap = null;
            expectedList.Clear();
            expectedList.Add("abcdefgh");
            expectedList.Add("efghabcd");
            result = CommonString.ConcatTwoString(s1, s2, overlap);
            Assert.IsNotNull(expectedList.Find(expect => expect == result));
        }

        [TestMethod]
        public void ShouldReturnParentString_WhenOneStringsContainsAnother()
        {
            s1 = "abcd";
            s2 = "bc";
            overlap = s2;
            expected = "abcd";
            result = CommonString.ConcatTwoString(s1, s2, overlap);
            Assert.Equals(expected, result);
            result = CommonString.ConcatTwoString(s2, s1, overlap);
            Assert.Equals(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "String shouldn't be null")]
        public void ShouldThrowException_WhenOneOrTwoOrThreeStringsAreNull()
        {
            s1 = "abcd";
            s2 = null;
            overlap = null;
            result = CommonString.ConcatTwoString(s1, s2, overlap);
            result = CommonString.ConcatTwoString(s2, s1, overlap);
            result = CommonString.ConcatTwoString(s2, s2, overlap);
        }


        /*
             Test Method FindCommonString
         */

        [TestMethod]
        public void ShouldReturnCommonstring_WhenStringListHasOverlap()
        {
            sList.Clear();
            sList.Add("abc");
            sList.Add("bcd");
            sList.Add("cde");                        
            expected = "abcde";
            result = CommonString.FindCommonString(sList);
            Assert.Equals(expected, result);
        }

        [TestMethod]
        public void ShouldReturnCommonString_WhenStringListHasNoOverlap()
        {
            sList.Clear();
            sList.Add("abc");
            sList.Add("def");
            sList.Add("ghi");

            expectedList.Clear();
            //for(int i=0; i < 3; i++)
            //{
            //    expectedList.Add(sList[i]+sList[(i+1)%3] + sList[(i + 2) % 3]);
            //    expectedList.Add(sList[i] + sList[(i + 2) % 3] + sList[(i + 1) % 3]);
            //}
            expectedList.Add("abcdefghi");
            expectedList.Add("abcghidef");
            expectedList.Add("defabcghi");
            expectedList.Add("defghiabc");
            expectedList.Add("ghiabcdef");
            expectedList.Add("ghidefabc");
            result = CommonString.FindCommonString(sList);
            Assert.IsNotNull(expectedList.Find(expect => expect == result));
        }
    }

}
