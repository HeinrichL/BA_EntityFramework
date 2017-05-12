using System;
using System.Data.Entity.Core;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistenceService;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure;

namespace PersistenceServiceTest
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für UnitTestPersistenceApi
    /// </summary>
    [TestClass]
    public class UnitTestPersistenceApi
    {
        private static KundenverwaltungContext _session;
        private static IPersistenceService _ps;
        private static ITransactionService _ts;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _session = new KundenverwaltungContext();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            _session.Database.ExecuteSqlCommand("IF OBJECT_ID('dbo.TestMember') IS NOT NULL DROP TABLE TestMember");
            _session.Database.ExecuteSqlCommand("IF OBJECT_ID('dbo.TestClass') IS NOT NULL DROP TABLE TestClass");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _ps = new EFPersistenceService();
            _ts = (ITransactionService)_ps;
        }


        [TestMethod]
        public void TestMethodSave()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now };
            _ps.Save(m);
            Assert.IsTrue(m.ID != 0);
        }

        [TestMethod]
        public void TestMethodSaveAll()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now };
            TestMember m2 = new TestMember() { Hehe = DateTime.Now };
            TestMember m3 = new TestMember() { Hehe = DateTime.Now };
            TestMember m4 = new TestMember() { Hehe = DateTime.Now };
            var res = _ps.SaveAll(new[] { m, m2, m3, m4 }.ToList());
            res.ForEach(x => Assert.IsTrue(x.ID != 0));
        }

        [TestMethod]
        public void TestMethodGetById()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now };
            _ps.Save(m);
            TestMember res = _ps.GetById<TestMember, int>(m.ID);
            Assert.AreEqual(m, res);
            Assert.AreSame(m, res);
        }

        [TestMethod]
        public void TestMethodGetAll()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now };
            TestMember m2 = new TestMember() { Hehe = DateTime.Now };
            TestMember m3 = new TestMember() { Hehe = DateTime.Now };
            TestMember m4 = new TestMember() { Hehe = DateTime.Now };
            var res = _ps.SaveAll(new[] { m, m2, m3, m4 }.ToList());
            var all = _ps.GetAll<TestMember>();
            res.ForEach(elem => Assert.IsTrue(all.Contains(elem)));
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now };
            _ps.Save(m);
            int id = m.ID;
            _ps.Delete(m);
            Assert.IsTrue(null == _ps.GetById<TestMember, int>(id));
        }

        [TestMethod]
        public void TestMethodQuery()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Today };
            TestMember m2 = new TestMember() { Hehe = DateTime.Today.AddDays(2) };
            TestMember m3 = new TestMember() { Hehe = DateTime.Today };
            TestMember m4 = new TestMember() { Hehe = DateTime.Today };
            var res = _ps.SaveAll(new[] { m, m2, m3, m4 }.ToList());

            var query = _ps.Query<TestMember>().Where(x => DateTime.Compare(x.Hehe, DateTime.Today) == 0).ToList();
            var linqQuery = from tm in _ps.Query<TestMember>()
                            where DateTime.Compare(tm.Hehe, DateTime.Today) == 0
                            select tm;
            Assert.AreEqual(3, query.Count);
            Assert.AreEqual(m, linqQuery.First());

        }

        [TestMethod]
        public void TestTransaction()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now };

            _ps.Save(m);

            IPersistenceService ps2 = new EFPersistenceService();
            ITransactionService ts2 = (ITransactionService)ps2;
            TestMember mConcurrent = ps2.GetById<TestMember, int>(m.ID);

            Assert.AreNotSame(m, mConcurrent);
            ts2.ExecuteInTransaction(() =>
            {
                mConcurrent.Hehe = DateTime.Today.AddDays(20);
                ps2.Update(mConcurrent);
            });
            Assert.AreNotSame(m, mConcurrent);
            try
            {
                m.Hehe = DateTime.Now.AddMinutes(5);
                _ps.Update(m);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(DbUpdateConcurrencyException), e.GetType());
            }
        }

        [TestMethod]
        public void TestTransaction2()
        {
            TestMember m = new TestMember() { Hehe = DateTime.Now.AddDays(12) };
            _ps.Save(m);

            IPersistenceService ps2 = new EFPersistenceService();
            ITransactionService ts2 = (ITransactionService)ps2;
            TestMember mConcurrent = ps2.GetById<TestMember, int>(m.ID);

            Assert.AreNotSame(m, mConcurrent);
            var mts = ts2.ExecuteInTransaction(() =>
            {
                mConcurrent.Hehe = DateTime.Today.AddDays(20);
                ps2.Update(mConcurrent);
                return true;
            });
            Assert.AreNotSame(m, mConcurrent);
            try
            {
                m.Hehe = DateTime.Now.AddMinutes(5);
                _ps.Update(m);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(DbUpdateConcurrencyException), e.GetType());
            }
        }
    }

    public class TestMember
    {
        public int ID { get; set; }
        public DateTime Hehe { get; set; }
        public byte[] Version { get; set; }
    }

    public class TestMap : EntityTypeConfiguration<TestMember>
    {
        public TestMap()
        {
            Property(x => x.Version).IsRowVersion();
        }
    }
}
