using BL.Interfaces;
using Common.Dto.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI_UnitTests.ControllerTests
{
    public class BookControllerTests
    {
        private readonly BookController _sut;

        public BookControllerTests()
        {
            var mockBookService = new Mock<IBookSevice>();

            mockBookService.Setup(x => x.GetBook(It.Is<long>(x => x == 2))).ReturnsAsync(
                new BookResponseDto
                {
                    Id = 2,
                    Title = "The Lion, the Witch and the Wardrobe",
                    PageCount = 100,
                    ImagePath = "thelion.jpg",
                    Description = "Lewis, The Lion,the Witch and the Wardrobe, the film tells the story of 4 children who go to live with an old professor during the war. One day, while playing hide and seek, Lucy, the youngest of the children, finds a wardrobe which leads to a magical land called Narnia.",
                    AmazonLink = "https://amzn.com/dp/0064404994",
                    BookName = "LionWitchWardrobe.pdf",
                }
            );

            var mockLogger = new Mock<ILogger<BookController>>();

            _sut = new BookController(mockBookService.Object);
        }

        [Fact]
        public async Task Get_Book_WithIdTwo_Returns_BookResponseDto()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _sut.GetBookById(id) as ObjectResult;
            var books = result.Value as BookResponseDto;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("The Lion, the Witch and the Wardrobe", books.Title);
        }

        [Fact]
        public async Task Get_BookIdZero_Returns_BadRequest()
        {
            //Arrange
            var id = 0;

            //Act
            var result = await _sut.GetBookById(id) as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Get_BookIdInadecvat_Returns_NotFound()
        {
            //Arrange
            var id = 30;

            //Act
            var result = await _sut.GetBookById(id) as ObjectResult;

            //Assert
            Assert.Equal(null, result.Value);
        }

        [Fact]
        public async Task Get_BookIdString_Returns_BadRequest()
        {
            //Arrange
            var id = 's';

            //Act
            var result = await _sut.GetBookById(id) as ObjectResult;

            //Assert
            Assert.Equal(null, result.Value);
        }
    }
}
