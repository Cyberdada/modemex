using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConnection
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        [TestMethod]
        [ExpectedException(typeof(exercise.ConnectionIsOpenException))]
        public void ShouldNotBeAbleToOpenconnectonTwice()
        {

            //Given an open com object
            // we should not be able to open connection
            var conn = new exercise.ConnectionImp();
            conn.Open();
            conn.Open();
           
      
        }
        [TestMethod]
        public void ShouldBeAbleToOpenConnection()
        {
            //Given a closed com object
            // we should be able to open connection
            var conn = new exercise.ConnectionImp();
           conn.Open();
           Assert.AreEqual(exercise.ConnectionImp.ConnectionState.Open, conn.State);

        }

        [TestMethod]
        public void ShouldBeAbleToCloseConnection()
        {
            //Given a closed com object
            // we should be able to open connection
            var conn = new exercise.ConnectionImp();
            conn.Open();
            conn.Close();
            Assert.AreEqual(exercise.ConnectionImp.ConnectionState.Closed, conn.State);


        }

        [TestMethod]
        public void ShouldBeAbleToLoginWhenConnectionIsOpen()
        {
            //Given a  com object with an open connection
            // we should be able to login 

            var conn = new exercise.ConnectionImp("pelle", "puff");
            conn.Open();
            conn.Login();
            Assert.AreEqual(conn.Log[0], "LOGIN pelle puff");
        }

        [TestMethod]
        [ExpectedException(typeof(exercise.ConnectionIsClosedException))]
        public void ShouldNotBeAbleToLoginWhenConnectionIsClosed()
        {
            //Given a  com object with a closed connection
            // we should not be able to login 
            var conn = new exercise.ConnectionImp();  
            conn.Login();
        }


        [TestMethod]
        public void ShouldBeAbleToLogOutWhenConnectionIsOpen()
        {
            //Given a  com object with an open connection
            // we should be able to login 

            var conn = new exercise.ConnectionImp("pelle", "puff");
            conn.Open();
            conn.Logout();
            Assert.AreEqual(conn.Log[0], "LOGOUT pelle");
        }

        [TestMethod]
        public void StatusShouldBeUnknownBeforeAnyAction()
        {
            //Given a  com object with an open connection
            var conn = new exercise.ConnectionImp("pelle", "puff");

            //status should be -1 
            Assert.AreEqual(-1, conn.Status());
        }

        [TestMethod]
        public void StatusShouldBeOpenWhenOpened()
        {
            //Given a  com object with an open connection
            var conn = new exercise.ConnectionImp("pelle", "puff");
            conn.Open();
            //status should be -1 
            Assert.AreEqual(1, conn.Status());
        }
        [TestMethod]

        public void StatusShouldBeClosedWhenClosed()
        {
            //Given a  com object with an open connection
            var conn = new exercise.ConnectionImp("pelle", "puff");
            conn.Close();
            //status should be -1 
            Assert.AreEqual(0, conn.Status());
        }


        [TestMethod]
        [ExpectedException(typeof(exercise.ConnectionIsClosedException))]
        public void ShouldNotBeAbleToLogoutWhenConnectionIsClosed()
        {
            //Given a  com object with a closed connection
            // we should not be able to login 
            var conn = new exercise.ConnectionImp();
            conn.Logout();
        }




    }
}
