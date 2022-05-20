using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services.Interfaces;

namespace WebAPI_UnitTests
{
    public class AuthorControllerTests
    {
        private readonly AuthorController _sut;

        public AuthorControllerTests()
        {
            var mockAuthorSevice = new Mock<IAuthorSevice>();

        }
    }
}
