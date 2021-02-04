﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdCodingApp;
using System.Collections.Generic;
using System.Linq;

namespace AdCodingUnitTest
{
    [TestClass]
    public class CommonstringTest
    {
        private String s1;
        private String s2;        
        private String overlap;
        private String result;
        private String expected;        


        /*
             Test Method FindLongestSubstring
         */

        //[TestMethod]
        //public void ShouldReturnSubstring_WhenTwoStringsHasOverlap()
        //{
        //    s1 = "abcd";
        //    s2 = "cdef";
        //    expected = "cd";
        //    result = CommonString.FindLongestSubstring(s1, s2);
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void ShouldReturnNull_WhenTwoStringsHasNoOverlap()
        //{
        //    s1 = "abcd";
        //    s2 = "efgh";
        //    expected = null;
        //    result = CommonString.FindLongestSubstring(s1, s2);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ShouldReturnEitherString_WhenTwoStringsHasTwoOverlap()
        //{
        //    s1 = "abcd";
        //    s2 = "cdeab";
        //    List<String> expectedList = new List<string>() { "ab","cd"};
        //    result = CommonString.FindLongestSubstring(s1, s2);            
        //    Assert.IsNotNull(expectedList.Find(expect => expect == result));
        //}

        //[TestMethod]
        //public void ShouldReturnSubstring_WhenOneStringsHasTwoOverlap()
        //{
        //    s1 = "abcdab";
        //    s2 = "cdeab";
        //    expected = "ab";
        //    result = CommonString.FindLongestSubstring(s1, s2);
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void ShouldReturnChildString_WhenOneStringsContainsAnother()
        //{
        //    s1 = "abcd";
        //    s2 = "bc";
        //    expected = "bc";
        //    result = CommonString.FindLongestSubstring(s1, s2);
        //    Assert.AreEqual(expected, result);
        //    result = CommonString.FindLongestSubstring(s2, s1);
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "String shouldn't be null")]
        //public void ShouldThrowException_WhenOneOrTwoStringsAreNull()
        //{
        //    s1 = "abcd";
        //    s2 = null;
        //    result = CommonString.FindLongestSubstring(s1, s2);            
        //    result = CommonString.FindLongestSubstring(s2, s1);
        //    result = CommonString.FindLongestSubstring(s2, s2);
        //}

        ///*
        //     Test Method ConcatTwoString
        // */

        //[TestMethod]
        //public void ShouldReturnConcatstring_WhenTwoStringsHasOverlap()
        //{
        //    s1 = "abcd";
        //    s2 = "cdef";
        //    overlap = "cd";
        //    expected = "abcdef";
        //    result = CommonString.ConcatTwoString(s1, s2, overlap);
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void ShouldReturnConcatString_WhenTwoStringsHasNoOverlap()
        //{
        //    s1 = "abcd";
        //    s2 = "efgh";
        //    overlap = null;
        //    List<String> expectedList = new List<string>() { "abcdefgh", "efghabcd" };
        //    result = CommonString.ConcatTwoString(s1, s2, overlap);
        //    Assert.IsNotNull(expectedList.Find(expect => expect == result));
        //}

        //[TestMethod]
        //public void ShouldReturnParentString_WhenOneStringsContainsAnother()
        //{
        //    s1 = "abcd";
        //    s2 = "bc";
        //    overlap = s2;
        //    expected = "abcd";
        //    result = CommonString.ConcatTwoString(s1, s2, overlap);
        //    Assert.AreEqual(expected, result);
        //    result = CommonString.ConcatTwoString(s2, s1, overlap);
        //    Assert.AreEqual(expected, result);
        //}

        ////[TestMethod]
        ////public void ShouldConcatByFirstOverlap_WhenOneStringsHasTwoOverlap()
        ////{
        ////    s1 = "abcdgcd";
        ////    s2 = "cdef";
        ////    overlap = "cd";
        ////    expected = "abcdef";
        ////    result = CommonString.ConcatTwoString(s1, s2, overlap);
        ////    Assert.AreEqual(expected, result);
        ////}

        //[TestMethod]
        //public void ShouldReturnLongString_WhenTwoStringsHasPrefixSuffix()
        //{
        //    s1 = "abcdefg";
        //    s2 = "xcdy";
        //    overlap = "cd";
        //    expected = "abcdefg";
        //    result = CommonString.ConcatTwoString(s1, s2, overlap);
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "String shouldn't be null")]
        //public void ShouldThrowException_WhenOneOrTwoOrThreeStringsAreNull()
        //{
        //    s1 = "abcd";
        //    s2 = null;
        //    overlap = null;
        //    result = CommonString.ConcatTwoString(s1, s2, overlap);
        //    result = CommonString.ConcatTwoString(s2, s1, overlap);
        //    result = CommonString.ConcatTwoString(s2, s2, overlap);
        //}


        ///*
        //     Test Method FindCommonString
        // */

        //[TestMethod]
        //public void ShouldReturnCommonstring_WhenStringListHasOverlap()
        //{
        //    List<String> sList = new List<string> { "abc", "bcd", "cde"};
        //    expected = "abcde";
        //    result = CommonString.FindCommonString(sList);
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void ShouldReturnAnyCommonString_WhenStringListHasNoOverlap()
        //{
        //    List<String> sList = new List<string>() { "abc", "def", "ghi" };            
        //    result = CommonString.FindCommonString(sList);
        //    Assert.IsTrue(result.Contains("abc"));
        //    Assert.IsTrue(result.Contains("def"));
        //    Assert.IsTrue(result.Contains("ghi"));
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "String List shouldn't be null or empty")]
        //public void ShouldThrowException_WhenStringListIsNull()
        //{
        //    List<String> sList = null;
        //    result = CommonString.FindCommonString(sList);
        //    sList = new List<string>();
        //    result = CommonString.FindCommonString(sList);
        //}


        //New Test cases
        [TestMethod]
        public void BasicCaseLongOnLeft()
        {

            List<string> fragments = new List<string> { "1234567", "56789" };

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result == "123456789");

        }

        [TestMethod]

        public void NonOverlappingAreConcatenated()
        {

            List<string> fragments = new List<string> { "1234", "56789" };

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result == "123456789");

        }

        [TestMethod]

        public void BasicCaseLongOnRight()
        {

            List<string> fragments = new List<string> { "1234", "23456789" };

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result == "123456789");

        }

        [TestMethod]

        public void SubstringIsIgnored()
        {

            List<string> fragments = new List<string> { "1234", "23456789", "456" };

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result == "123456789");

        }

        [TestMethod]

        public void UseBestStringMatchNotFirstMatch()
        {

            List<string> fragments = new List<string> { "abcde", "efghi", "cdewooe" };

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result == "abcdewooefghi");

        }

        [TestMethod]

        public void TestProblemExample()
        {

            List<string> fragments = new List<string> { "all is well", "ell that en", "hat end", "t ends well" };

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result == "all is well that ends well");

        }

        [TestMethod]

        public void TestGitHubSample1()
        {

            var fragments = "O draconia;conian devil! Oh la;h lame sa;saint!".Split(';').ToList();

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result.Equals("O draconian devil! Oh lame saint!"));

        }

        [TestMethod]

        public void TestGitHubSample2()
        {

            var fragments = "m quaerat voluptatem.;pora incidunt ut labore et d;, consectetur, adipisci velit;olore magnam aliqua;idunt ut labore et dolore magn;uptatem.;i dolorem ipsum qu;iquam quaerat vol;psum quia dolor sit amet, consectetur, a;ia dolor sit amet, conse;squam est, qui do;Neque porro quisquam est, qu;aerat voluptatem.;m eius modi tem;Neque porro qui;, sed quia non numquam ei;lorem ipsum quia dolor sit amet;ctetur, adipisci velit, sed quia non numq;unt ut labore et dolore magnam aliquam qu;dipisci velit, sed quia non numqua;us modi tempora incid;Neque porro quisquam est, qui dolorem i;uam eius modi tem;pora inc;am al"

                .Split(';').Select(s => s.TrimStart()).ToList();

            var result = CommonString.FindCommonString(fragments);

            Assert.IsTrue(result.Equals("Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem."));

        }

        [TestMethod]

        public void TestGitHubSample2Reversed()
        {

            var fragments = "m quaerat voluptatem.;pora incidunt ut labore et d;, consectetur, adipisci velit;olore magnam aliqua;idunt ut labore et dolore magn;uptatem.;i dolorem ipsum qu;iquam quaerat vol;psum quia dolor sit amet, consectetur, a;ia dolor sit amet, conse;squam est, qui do;Neque porro quisquam est, qu;aerat voluptatem.;m eius modi tem;Neque porro qui;, sed quia non numquam ei;lorem ipsum quia dolor sit amet;ctetur, adipisci velit, sed quia non numq;unt ut labore et dolore magnam aliquam qu;dipisci velit, sed quia non numqua;us modi tempora incid;Neque porro quisquam est, qui dolorem i;uam eius modi tem;pora inc;am al"

                .Split(';').Select(s => s.TrimStart()).Reverse().ToList();

            var result = CommonString.FindCommonString(fragments.ToList());

            Assert.IsTrue(result.Equals("Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem."));

        }

    }

}
