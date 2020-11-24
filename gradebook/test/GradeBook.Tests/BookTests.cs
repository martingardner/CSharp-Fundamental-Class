using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            var testresult = book.GetStatistics();
            //what is expected / what is being tested / [optional] precision
            Assert.Equal(85.6, testresult.Average, 1);
            Assert.Equal(90.5, testresult.High, 1);
            Assert.Equal(77.3, testresult.Low, 1);
        }
    }
}
