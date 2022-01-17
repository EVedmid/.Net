using System;
using NUnit.Framework;
using DAL.Entity;
using BLL.Provider;
using DAL.Context;

namespace Lab3.Test
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void CreateBd()
        {
            //arrange
            bool flag = true;

            //act
            var act = DependencyProvider.Init();
            //assert
            Assert.AreEqual(flag, act);

        }

        [Test]
        public void AddToGuestBd()
        {
            //arrang
            int _count = 1;
            string login = "userTest";

            //act
            var bd = new NewsContext();
            bd.Guests.Add(new Guest { Login = "userTest", PasswordHash = "userTest", GuestRole = Guest.Role.Guest });
            var count = bd.Guests.Local.Count;

            //assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_count, count);
                Assert.True(bd.Guests.Find(login).Login==login);
            });
        }

        [Test]
        public void AddToPostBd()
        {
            //arrang
            int _count = 1;
            string head = "testhead";

            //act
            var bd = new NewsContext();
            bd.Posts.Add(new Post {Id = 1, NewsHeader = "testhead", NewsBody = "testbody", DateTime = DateTime.Now, guestLogin = "userTest", Rubric = "testR", Tags = "test", Topic = "te" });
            var count = bd.Posts.Local.Count;

            //assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_count, count);
                Assert.IsTrue(bd.Posts.Find(1).NewsHeader == head);
            });
        }

        [Test]
        public void RemoveFromPostBd()
        {
            //arrang
            int _count = 0;

            //act
            var bd = new NewsContext();
            bd.Posts.Add(new Post { Id = 1, NewsHeader = "testhead", NewsBody = "testbody", DateTime = DateTime.Now, guestLogin = "userTest", Rubric = "testR", Tags = "test", Topic = "te" });
            bd.Posts.Remove(bd.Posts.Find(1));
            var count = bd.Posts.Local.Count;

            //assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_count, count);
            });
        }

        [Test]
        public void RemoveFromGuestBd()
        {
            //arrang
            int _count = 0;

            //act
            var bd = new NewsContext();
            bd.Guests.Add(new Guest { Login = "userTest", PasswordHash = "userTest", GuestRole = Guest.Role.Guest });
            bd.Guests.Remove(bd.Guests.Find("userTest"));
            var count = bd.Guests.Local.Count;

            //assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_count, count);
            });
        }

    }
}
