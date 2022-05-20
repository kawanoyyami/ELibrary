using AutoMapper;
using Entity.Models;
using Entity.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.Services.Interfaces;
using Xunit;

namespace WebAPI_UnitTests.ServiceTests
{
    public class BookSeviceTests
    {
        private readonly IBookSevice _sut;

        public BookSeviceTests()
        {
            var mockRepository = new Mock<IRepository<Book>>();
            var mockMapper = new Mock<IMapper>();
            mockRepository.Setup(x => x.ListAsync()).ReturnsAsync(new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "The Lion, the Witch and the Wardrobe",
                    PageCount = 100,
                    ImagePath = "thelion.jpg",
                    Description = "Lewis, The Lion,the Witch and the Wardrobe, the film tells the story of 4 children who go to live with an old professor during the war. One day, while playing hide and seek, Lucy, the youngest of the children, finds a wardrobe which leads to a magical land called Narnia.",
                    AmazonLink = "https://amzn.com/dp/0064404994",
                    BookName = "LionWitchWardrobe.pdf",
                },
                new Book
                {
                    Id=2,
                    Title = "She: A History of Adventure",
                    PageCount = 100,
                    ImagePath = "she.jpg",
                    Description = "The story is a first-person narrative which follows the journey of Horace Holly and his ward Leo Vincey to a lost kingdom in the African interior. They encounter a primitive race of natives and a mysterious white queen named Ayesha who reigns as the all-powerful She or She - who - must - be - obeyed.",
                    AmazonLink = "https://amzn.com/dp/1925110133",
                    BookName = "she.pdf",
                },
            });

            _sut = new BookService(mockRepository.Object, mockMapper.Object);
        }
    }
}
