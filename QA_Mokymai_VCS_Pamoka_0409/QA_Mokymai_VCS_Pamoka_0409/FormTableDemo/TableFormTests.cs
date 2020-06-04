using NUnit.Framework;
using QA_Mokymai_VCS_Pamoka_0409.Utils;

namespace QA_Mokymai_VCS_Pamoka_0409.FormTableDemo
{
    public class TableFormTests
    {
        TableFormPage tableFormPage;

        [SetUp]
        public void BeforeTest()
        {
            Driver.Init();
            Driver.Current.Url = "https://www.seleniumeasy.com/test/table-search-filter-demo.html";
            tableFormPage = new TableFormPage();
        }

        [Test]
        public void VerifyTaskTitleAndStatusByList()
        {
            var assignee = "Emily John";
            var taskTitle = "Bootstrap 3";
            var taskStatus = "in progress";
            tableFormPage.AssertTaskTitleByList(taskTitle, assignee).
                AssertStatusTitleByList(taskStatus, assignee);
        }

        [Test]
        public void VerifyTaskTitleAndStatusByXpath()
        {
            var assignee2 = "Emily John";
            var taskTitle = "Bootstrap 3";
            var taskStatus = "in progress";
            tableFormPage.AssertTaskByXpath(taskTitle, assignee2).
                AssertStatusByXpath(taskStatus, assignee2);
        }


        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
