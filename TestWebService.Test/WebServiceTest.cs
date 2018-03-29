using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService;
using System.Collections.Generic;
using ProcesssAutomation;

namespace TestWebService.Test
{
    [TestClass]
    public class WebServiceTest
    {
        [TestMethod]
        public void TestCreateTable()
        {

            WebService1 service = new WebService1();
            String TableName = "Student", ColumnName = "RollNo,Name,Age";
            int res = service.CreateTable(TableName, ColumnName);
            Assert.AreNotEqual(0, res);

        }

        [TestMethod]
        public void TestenterData()
        {
            WebService1 service = new WebService1();
            String TableName="Student", values = "i141604,Rashid Ali,23", columns = "RollNo,Name,Age";
            int res = service.enterData(TableName,columns, values);
            Assert.AreEqual(1, res);
            TableName = "Test";
             res = service.enterData(TableName, columns, values);
            Assert.AreNotEqual(1, res);

        }

        [TestMethod]
        public void TestreturnData()
        {
            WebService1 service = new WebService1();
            String TableName = "Student";
            String[] res = service.returnData(TableName);
            Assert.AreNotEqual(null, res);
            TableName = "Test";
            res = service.returnData(TableName);
            Assert.AreEqual(null, res);
        }

        [TestMethod]
        public void TestgetTableData()
        {
            WebService1 service = new WebService1();
            String TableName = "Student";
            List<GroupMembers> res = service.getTableData(TableName);
            Assert.AreNotEqual(null, res);
            TableName = "Test";
            res = service.getTableData(TableName);
            Assert.AreEqual(null, res);
        }

        [TestMethod]
        public void TestLogin()
        {
            WebService1 service = new WebService1();
            String TableName = "UsersTable";
            String email = "rashid@gmail.com", password = "1234";
            String res = service.Login(email, password, TableName);
            Assert.AreNotEqual(null, res);
            Assert.AreEqual("true,Student", res.Trim());
            email = "asim@yahoo.com"; password = "1234";
            res = service.Login(email, password, TableName);
            Assert.AreEqual("true,Instructor", res.Trim());
            email = "asim@yahoo.com"; password = "1234";TableName = "Test";
            res = service.Login(email, password, TableName);
            Assert.AreEqual(null, res);


        }


    }
}
