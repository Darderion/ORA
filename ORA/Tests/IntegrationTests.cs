using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Map_XMLSave()
        {
            Map map = (new Map("Test name 1", "Test video URL 1", 10, 20));
            map.AddSubtitle(3, "Test 3 (1)")
                .AddSubtitle(5, "Test 5 (2)")
                .AddSubtitle(8, "Test 8 (3)");
            var storage = new MapsXML();
            try
            {
                storage.Save(map);
                Assert.AreEqual(map.ToString(), storage.Load(map.Name).ToString());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void Map_DBSave()
        {
            Map map = (new Map("Test name 1", "Test video URL 1", 10, 20));
            map.AddSubtitle(3, "Test 3 (1)")
                .AddSubtitle(5, "Test 5 (2)")
                .AddSubtitle(8, "Test 8 (3)");
            var storage = new MapsDB();
            Map loadedMap = new Map();
            try
            {
                storage.Save(map);
                loadedMap = storage.Load(map.Name);
                Assert.AreEqual(map.ToString(), loadedMap.ToString());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
