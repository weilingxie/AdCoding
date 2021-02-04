using System;
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
        //private String overlap;
        //private String result;
        private String expected;


        /*
             Test Method FindLongestSubstring
         */

        [TestMethod]
        public void ShouldReturnSubstring_WhenTwoStringsHasOverlap()
        {
            s1 = "abcd";
            s2 = "cdef";
            string expectedOverlap = "cd";
            string expectedConcat = "abcdef";
            var result = CommonString.FindLongestSubstring(s1, s2);
            Assert.AreEqual(expectedOverlap, result.Overlap);
            Assert.AreEqual(expectedConcat, result.Concat);
        }

        [TestMethod]
        public void ShouldReturnNullOverlapAndDirectConcat_WhenTwoStringsHasNoOverlap()
        {
            s1 = "abcd";
            s2 = "efgh";            
            string expectedConcat = "abcdefgh";
            var result = CommonString.FindLongestSubstring(s1, s2);
            Assert.IsNull(result.Overlap);
            Assert.AreEqual(expectedConcat, result.Concat);
        }

        [TestMethod]
        public void ShouldReturnEitherString_WhenTwoStringsHasTwoOverlap()
        {
            s1 = "abcd";
            s2 = "cdeab";
            var expectedOverlap = new List<string>() { "ab", "cd" }; 
            var expectedConcat = new List<string>() { "abcdeab", "cdeabcd" };
            var result = CommonString.FindLongestSubstring(s1, s2);
            Assert.IsNotNull(expectedOverlap.Find(expect => expect == result.Overlap));
            Assert.IsNotNull(expectedConcat.Find(expect => expect == result.Concat));
        }

        [TestMethod]
        public void ShouldReturnBetterConcatSubstring_WhenOneStringsHasTwoOverlap()
        {
            s1 = "abcdab";
            s2 = "deab";
            expected = "ab";
            string expectedOverlap = "ab";
            string expectedConcat = "deabcdab";
            var result = CommonString.FindLongestSubstring(s1, s2);
            Assert.AreEqual(expectedOverlap, result.Overlap);
            Assert.AreEqual(expectedConcat, result.Concat);
        }

        [TestMethod]
        public void ShouldReturnChildString_WhenOneStringsContainsAnother()
        {
            s1 = "abcd";
            s2 = "bc";
            string expectedOverlap = "bc";
            string expectedConcat = "abcd";
            var result = CommonString.FindLongestSubstring(s1, s2);
            Assert.AreEqual(expectedOverlap, result.Overlap);
            Assert.AreEqual(expectedConcat, result.Concat);
            result = CommonString.FindLongestSubstring(s2, s1);
            Assert.AreEqual(expectedOverlap, result.Overlap);
            Assert.AreEqual(expectedConcat, result.Concat);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowException_WhenOneOrTwoStringsAreNull()
        {
            s1 = "abcd";
            s2 = null;
            CommonString.FindLongestSubstring(s1, s2);
            CommonString.FindLongestSubstring(s2, s1);
            CommonString.FindLongestSubstring(s2, s2);
        }

        /*
             Test Method FindCommonString
         */

        [TestMethod]
        public void ShouldReturnCommonstring_WhenStringListHasOverlap()
        {
            List<String> sList = new List<string> { "abc", "bcd", "cde" };
            expected = "abcde";
            var result = CommonString.FindCommonString(sList);
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void ShouldReturnAnyCommonString_WhenStringListHasNoOverlap()
        {
            List<String> sList = new List<string>() { "abc", "def", "ghi" };            
            var result = CommonString.FindCommonString(sList);
            Assert.IsTrue(result.Contains("abc"));
            Assert.IsTrue(result.Contains("def"));
            Assert.IsTrue(result.Contains("ghi"));
        }

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
