﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1.GroupSumByColumn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;

namespace Day1.GroupSumByColumn.Tests
{
    [TestClass()]
    public class GroupHelperTests
    {
        private static Book[] books;


        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            books = new Book[]
            {
                new Book{ Id = 1,Cost = 1, Revenu = 11,  SellPrice = 21},
                new Book{ Id = 2,Cost = 2, Revenu = 12,  SellPrice = 22},
                new Book{ Id = 3,Cost = 3, Revenu = 13,  SellPrice = 23},
                new Book{ Id = 4,Cost = 4, Revenu = 14,  SellPrice = 24},
                new Book{ Id = 5,Cost = 5, Revenu = 15,  SellPrice = 25},
                new Book{ Id = 6,Cost = 6, Revenu = 16,  SellPrice = 26},
                new Book{ Id = 7,Cost = 7, Revenu = 17,  SellPrice = 27},
                new Book{ Id = 8,Cost = 8, Revenu = 18,  SellPrice = 28},
                new Book{ Id = 9,Cost = 9, Revenu = 19,  SellPrice = 29},
                new Book{ Id = 10,Cost = 10, Revenu = 20,  SellPrice = 30},
                new Book{ Id = 11,Cost = 11, Revenu = 21,  SellPrice = 31}
            };
        }

        [TestMethod()]
        public void ThreeRows_ByGroup_Sum_ByCost_FromBooks()
        {
            // arrange


            var expected = new int[] { 6, 15, 24, 21 };


            // act
            var actual = GroupHelper.SumByColumn<Book>(books, 3, new Func<Book, int>((x) => x.Cost));

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void FourRows_ByGroup_Sum_ByRevenu_FromBooks()
        {
            // arrange


            var expected = new int[] { 50, 66, 60 };

            // act
            var actual = GroupHelper.SumByColumn<Book>(books, 4, new Func<Book, int>((x) => x.Revenu));

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void GroupRows_Bigger_Than_Collection_Length()
        {
            // arrange

            // act
            Action act = () => GroupHelper.SumByColumn<Book>(books, books.Length + 1, new Func<Book, int>((x) => x.Revenu));
            // assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}