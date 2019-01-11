﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Map_AddSubtitles_DictCount()
        {
            Map map = (new Map("Test name 1", "Test video URL 1", 10, 20))
                .AddSubtitles(3, "Test 3 (1)")
                .AddSubtitles(5, "Test 5 (2)")
                .AddSubtitles(8, "Test 8 (3)");
            Assert.AreEqual(3, map.dict.Count);
        }

        [TestMethod]
        public void Map_AddSubtitles_SubtitlesCount()
        {
            Map map = (new Map("Test name 1", "Test video URL 1", 10, 20))
                .AddSubtitles(3, "Test 3 (1)")
                .AddSubtitles(5, "Test 5 (2)")
                .AddSubtitles(8, "Test 8 (3)");
            Assert.AreEqual(3, map.subtitles.Count);
        }
    }
}
