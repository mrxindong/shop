using BookShop.Web.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 CommonCodeTest 的测试类，旨在
    ///包含所有 CommonCodeTest 单元测试
    ///</summary>
    [TestClass()]
    public class CommonCodeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
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

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Md5Compte 的测试
        ///</summary>
        // TODO: 确保 UrlToTest 属性指定一个指向 ASP.NET 页的 URL(例如，
        // http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
        //无论要测试页、Web 服务还是 WCF 服务都是如此。
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\BookShop三层建好的项目[原始]\\BookShop\\Web", "/")]
        [UrlToTest("http://localhost:3448/")]
        public void Md5CompteTest()
        {
            string txt = "1234567"; // TODO: 初始化为适当的值
            string expected = "E10ADC3949BA59ABBE56E057F20F883E"; // TODO: 初始化为适当的值
            string actual;
            actual = CommonCode.Md5Compte(txt);

            Assert.AreEqual(expected, actual);
           
        }
    }
}
