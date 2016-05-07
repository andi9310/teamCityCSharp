using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Core;

namespace Blog.DAL.Tests
{
    [TestClass]
    public class RepositoryTests: DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
            // test comment
        }
        [TestMethod]
        public void AddPost_OnePostInDb_GetAllPosts_ReturnTwoPosts()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            repository.AddPost("sylwester", "sample text");
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
            // test comment
        }
        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddPost_NoContent_Error()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            repository.AddPost("sylwester", null);
        }
    }
}
