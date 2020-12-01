using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {

        private int count = 0;

        [Fact]
        public void MultiCastDelegateExample()
        {
            // to show that multiple delegates can be chained together and invoked
            WriteLogDelegate log = MultiCastReturn1;
            log += MultiCastReturn1;
            log += MultiCastReturn2;

            var result = log("Hello!");
            Assert.Equal(3, count);
            /* 
            confusing but MultiCastReturn1 gets invoked twice apparently
            once on initial += and once again on second += before MultiCastReturn2 is added
            */
        }

        string MultiCastReturn1(string message)
        {
            count++;
            return message;
        }

        string MultiCastReturn2(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            //log = new WriteLogDelegate(ReturnMessage);
            log = ReturnMessage;
            var result = log("Hello!");

            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void GetBookDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void DiffBooksSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2)); //same as Assert.Same
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharpIsPassByValueByDefault()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void CSharepCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            //ref in front passes by reference instead of default of value
            RefGetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void TestValueSetChangeToX()
        {
            var x = SetInt(3);
            Assert.Equal(6, x);
        }

        private int SetInt(int number)
        {
            return number + 3;
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        //ref in front of param overwrites inherant pass by value with reference
        private void RefGetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
    }
}
