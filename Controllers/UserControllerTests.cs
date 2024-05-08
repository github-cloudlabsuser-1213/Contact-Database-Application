using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();
            var expectedUsers = new List<User>
            {
                new User { Id = 1, Name = "John" },
                new User { Id = 2, Name = "Jane" }
            };
            UserController.userlist = expectedUsers;

            // Act
            var result = controller.Index() as ViewResult;
            var actualUsers = result.Model as List<User>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUsers, actualUsers);
        }

        [TestMethod]
        public void Details_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var expectedUser = new User { Id = 1, Name = "John" };
            UserController.userlist = new List<User> { expectedUser };

            // Act
            var result = controller.Details(1) as ViewResult;
            var actualUser = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        public void Details_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Create_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        [TestMethod]
        public void Edit_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var expectedUser = new User { Id = 1, Name = "John" };
            UserController.userlist = new List<User> { expectedUser };

            // Act
            var result = controller.Edit(1) as ViewResult;
            var actualUser = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        public void Edit_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Delete_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var expectedUser = new User { Id = 1, Name = "John" };
            UserController.userlist = new List<User> { expectedUser };

            // Act
            var result = controller.Delete(1) as ViewResult;
            var actualUser = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        public void Delete_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void DeleteConfirmed_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
