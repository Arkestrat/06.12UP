using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryKhasanovUP;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var add = new Add();

            // Assert
            Assert.IsNotNull(add.Comments, "Comments collection should be initialized.");
            Assert.IsNotNull(add.Orders, "Orders collection should be initialized.");
            Assert.AreEqual(0, add.Comments.Count, "Comments collection should be empty.");
            Assert.AreEqual(0, add.Orders.Count, "Orders collection should be empty.");
            Assert.IsNull(add.Description, "Description should be null by default.");
            Assert.IsNull(add.Status, "Status should be null by default.");
        }

        [TestMethod]
        public void Add_ShouldSetAndGetPropertiesCorrectly()
        {
            // Arrange
            var add = new Add
            {
                AddId = 1,
                UserId = 2,
                CategoryId = 3,
                Title = "Test Title",
                Description = "Test Description",
                Price = 100.50m,
                Status = "Active"
            };

            // Assert
            Assert.AreEqual(1, add.AddId, "AddId property is not set correctly.");
            Assert.AreEqual(2, add.UserId, "UserId property is not set correctly.");
            Assert.AreEqual(3, add.CategoryId, "CategoryId property is not set correctly.");
            Assert.AreEqual("Test Title", add.Title, "Title property is not set correctly.");
            Assert.AreEqual("Test Description", add.Description, "Description property is not set correctly.");
            Assert.AreEqual(100.50m, add.Price, "Price property is not set correctly.");
            Assert.AreEqual("Active", add.Status, "Status property is not set correctly.");
        }

        [TestMethod]
        public void Add_ShouldHandleEmptyDescriptionAndStatus()
        {
            // Arrange
            var add = new Add
            {
                Title = "Sample Add",
                Price = 50.0m
            };

            // Act & Assert
            Assert.IsNull(add.Description, "Description should be null if not set.");
            Assert.IsNull(add.Status, "Status should be null if not set.");
        }

        [TestMethod]
        public void Add_ShouldAllowAddingComments()
        {
            // Arrange
            var add = new Add();
            var comment = new Comment { CommentId = 1, CommentText = "Test Comment" };

            // Act
            add.Comments.Add(comment);

            // Assert
            Assert.AreEqual(1, add.Comments.Count, "Comments collection should contain one item.");
            Assert.IsTrue(add.Comments.Contains(comment), "Comment should be in the collection.");
        }

        [TestMethod]
        public void Add_ShouldAllowAddingOrders()
        {
            // Arrange
            var add = new Add();
            var order = new Order { OrderId = 1, Status = "Pending" };

            // Act
            add.Orders.Add(order);

            // Assert
            Assert.AreEqual(1, add.Orders.Count, "Orders collection should contain one item.");
            Assert.IsTrue(add.Orders.Contains(order), "Order should be in the collection.");
        }
    }
}
