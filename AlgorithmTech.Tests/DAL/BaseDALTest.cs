using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dylan.AlgorithmTech.DAL;
using Dylan.AlgorithmTech.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagedList;
using System.Linq;

namespace Dylan.AlgorithmTech.Tests.DAL
{
    [TestClass]
    public class BaseDALTest
    {
        private BaseDAL m_BaseDAL;
        public BaseDALTest()
        {
            ATTDbContext context = new ATTDbContext();
            m_BaseDAL = new BaseDAL(context);
        }

        [TestMethod]
        public void Insert()
        {
            TagInfo tagInfo = new TagInfo(){ Name="排序算法" };
            tagInfo = m_BaseDAL.Insert<TagInfo>(tagInfo);
            Assert.IsNotNull(tagInfo.TagId);
        }

        [TestMethod]
        public void InsertList()
        {
            List<TagInfo> tagInfos = new List<TagInfo>(){new TagInfo(){ Name="快速排序"}, new TagInfo(){Name="二叉树"}};
            tagInfos = m_BaseDAL.Insert<TagInfo>(tagInfos);
            Assert.IsNotNull(tagInfos[0].TagId);
        }

        [TestMethod]
        public void Delete()
        {
            TagInfo tagInfo = new TagInfo { TagId = Guid.Parse("C9DB5F24-A157-E411-BEBE-28D2442A247A") };
            m_BaseDAL.Delete<TagInfo>(tagInfo);
        }

        [TestMethod]
        public void DeleteList()
        {
            List<TagInfo> tagInfos = new List<TagInfo> { new TagInfo() { TagId = Guid.Parse("C3604F4E-A057-E411-BEBE-28D2442A247A") }, new TagInfo() { TagId = Guid.Parse("C8DB5F24-A157-E411-BEBE-28D2442A247A") } };
            m_BaseDAL.Delete<TagInfo>(tagInfos);
        }

        [TestMethod]
        public void Update()
        {
            TagInfo tagInfo = new TagInfo() { TagId = Guid.Parse("B85F60E7-9F57-E411-BEBE-28D2442A247A"), Name = "平衡二叉树" };
            m_BaseDAL.Update<TagInfo>(tagInfo);
        }

        [TestMethod]
        public void UpdateList()
        {
            List<TagInfo> tagInfos = new List<TagInfo>() { new TagInfo() { TagId = Guid.Parse("B85F60E7-9F57-E411-BEBE-28D2442A247A"), Name = "二叉树" }, new TagInfo() { TagId = Guid.Parse("B3F4EFF9-9F57-E411-BEBE-28D2442A247A"), Name = "冒泡排序" } };
            m_BaseDAL.Update<TagInfo>(tagInfos);
        }

        [TestMethod]
        public void Find()
        {
            TagInfo tagInfo = m_BaseDAL.Find<TagInfo>(Guid.Parse("B85F60E7-9F57-E411-BEBE-28D2442A247A"));
            Assert.AreEqual(tagInfo.Name, "二叉树");
        }

        [TestMethod]
        public void FindAll()
        {
            List<TagInfo> tagInfoList = m_BaseDAL.FindAll<TagInfo>();
            Assert.IsTrue(tagInfoList.Count > 0);
        }

        [TestMethod]
        public void FindAllWithCondition()
        {
            List<TagInfo> tagInfoList = m_BaseDAL.FindAll<TagInfo>(s => s.Name == "二叉树");
            Assert.IsTrue(tagInfoList.Count > 0);
        }

        [TestMethod]
        public void FindAllByPage()
        {
            IPagedList<TagInfo> tagInfoList = m_BaseDAL.FindAllByPage<TagInfo>(null, "Name", "ASC", 1, 2);
            List<TagInfo> list = tagInfoList.ToList<TagInfo>();
            Assert.IsTrue(tagInfoList.Count > 0);
        }

        [TestMethod]
        public void Count()
        {
            int count = m_BaseDAL.GetCount<TagInfo>(null);
            Assert.IsTrue(count > 0);
        }
    }
}
