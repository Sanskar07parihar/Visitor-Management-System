using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Management_System.Data;
using Visitor_Management_System.Controllers;
using Visitor_Management_System.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace VisitorManagementSystemTest1
{
    [TestClass]
    public class Customerstests
    {

        private ApplicationDbContext _context;
        private CustomersController _controller;
        private List<Customer> _customers = new List<Customer>();



        [TestInitialize]
        public void TestInitialize()
        {


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            _context = new ApplicationDbContext(options);




            var customer1 = new Customer { CustomerId = 1, Name = "Mahesh" };
            var customer2 = new Customer { CustomerId = 2, Name = "Naman" };
            var customer3 = new Customer { CustomerId = 3, Name = "Tashiv" };


            _context.Customers.Add(customer1);
            _context.Customers.Add(customer2);
            _context.Customers.Add(customer3);
            _context.SaveChanges();


            _customers.Add(customer1);
            _customers.Add(customer2);
            _customers.Add(customer3);


            _controller = new CustomersController(_context);
        }

        [TestMethod]
        public void Management1()
        {

            var Result = _controller.Edit(null);
            var Result1 = (NotFoundResult)Result.Result;
            Assert.AreEqual(404, Result1.StatusCode);
        }

        [TestMethod]
        public void Management2()
        {
            var aResult2 = _controller.Edit(100);
            var Result2 = (NotFoundResult)aResult2.Result;
            Assert.AreEqual(404, Result2.StatusCode);
        }

        [TestMethod]
        public void Management3()
        {
            var aResult3 = _controller.Edit(1);
            var Result3 = (ViewResult)aResult3.Result;
            Assert.IsNotNull(Result3);
        }



    }
}
