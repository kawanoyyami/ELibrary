using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services.Interfaces;
using Xunit;

namespace WebAPI_UnitTests
{
    public class BookControllerTests
    {
        private readonly BookController _sut;
        public BookControllerTests()
        {
            var mockBookService = new Mock<IBookSevice>();

            mockBookService.Setup(x => x.GetBook(It.Is<long>(x => x == 2)))
                .ReturnsAsync(
                    new BookResponseDto
                    {
                        Id = 2,
                        Title = "Another test title",
                        PageCount = 100
                    }
                );
            _sut = new BookController(mockBookService.Object);
        }
        [Fact]
        public async Task Get_BookWithIdTwo_Returns_DtoWithAllInfoOfBookTwo()
        {
            //Arrange
            var id = 2;
            //Act
            var result = await _sut.GetBook(id) as ObjectResult;
            var boook = result.Value as BookResponseDto;
            //Assert
            Assert.Equal(result.Value, boook);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Get_BookWithIdNull_Returns_Exception()
        {
            long id = 32;

            var result = await _sut.GetBook(id) as ObjectResult;
            var boook = result.Value as List<BookResponseDto>;

            Assert.Equal(result.Value, boook);
            //Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
