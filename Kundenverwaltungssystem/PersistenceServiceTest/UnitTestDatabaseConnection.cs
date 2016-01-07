using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistenceService;

namespace PersistenceServiceTest
{
    [TestClass]
    public class UnitTestDatabaseConnection
    {
        private static KundenverwaltungContext _session;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            File.Delete(DatabaseConfig.ConnStringSQLite);
            _session = new KundenverwaltungContext();
            _session.Database.ExecuteSqlCommand("IF OBJECT_ID('dbo.Testtable') IS NOT NULL DROP TABLE Testtable");
            _session.Database.ExecuteSqlCommand("CREATE TABLE Testtable (ID int not null, Bla nvarchar(200))");
        }

        [ClassCleanup]
        public static void Clean()
        {
            //_session = HibernateSessionFactory.OpenSession();
            //_session.CreateSQLQuery("IF OBJECT_ID('dbo.Testtable') IS NOT NULL DROP TABLE Testtable").ExecuteUpdate();
        }

        [TestMethod]
        public void TestDatabaseConnection()
        {
            List<object> res;
            using (var transaction = _session.Database.BeginTransaction())
            {
                _session.Database.ExecuteSqlCommand("INSERT INTO Testtable (ID, Bla) VALUES (1,'asd'),(2,'asdf')");
                res = _session.Database.SqlQuery<object>("SELECT * FROM Testtable").ToList();

                transaction.Commit();
            }

            Assert.AreEqual(2, res.Count);
        }
    }
}
