using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

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

        private Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        //ref in front of param overwrites inherant pass by value with reference
        private void RefGetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
    }
}
