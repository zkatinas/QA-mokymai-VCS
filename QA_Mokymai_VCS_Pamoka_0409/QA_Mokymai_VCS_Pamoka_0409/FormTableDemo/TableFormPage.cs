using NUnit.Framework;
using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Collections.Generic;


namespace QA_Mokymai_VCS_Pamoka_0409.FormTableDemo
{
    public class TableFormPage
    {
        private IList<IWebElement> taskTableRowList => Driver.Current.FindElements(By.CssSelector("#task-table tbody tr"));
        
        private IWebElement GetTableRowByList(string assignee)
        {
            for (int i = 0; i < taskTableRowList.Count; i++)
            {
                var elementAssignee = taskTableRowList[i].FindElements(By.TagName("td"))[2];
                if (elementAssignee.Text == assignee)
                {
                    return taskTableRowList[i];
                }
            }
            return null;
        }
        public TableFormPage AssertTaskTitleByList(string expectedTaskTitle, string assignee)
        {
            var elementTaskTitle = GetTableRowByList(assignee).FindElements(By.TagName("td"))[1];
            Assert.AreEqual(expectedTaskTitle, elementTaskTitle.Text);
            return this;
        }

        public TableFormPage AssertStatusTitleByList(string expectedTaskStatus, string assignee)
        {
            var elementStatusTitle = GetTableRowByList(assignee).FindElements(By.TagName("td"))[3];
            Assert.AreEqual(expectedTaskStatus, elementStatusTitle.Text);
            return this;
        }

        private IWebElement ElementTask(string assignee)
        {
            return Driver.Current.FindElement(By.XPath($"//table[@id = 'task-table']//td[text()='{assignee}']/../td[2]"));
        }

        private IWebElement ElementStatus(string assignee)
        {
            return Driver.Current.FindElement(By.XPath($"//table[@id = 'task-table']//td[text()='{assignee}']/../td[4]"));
        }

        public TableFormPage AssertTaskByXpath(string expectedTask, string assignee)
        {
            Assert.AreEqual(expectedTask, ElementTask(assignee).Text);
            return this;
        }

        public TableFormPage AssertStatusByXpath(string expectedStatus, string assignee)
        {
            Assert.AreEqual(expectedStatus, ElementStatus(assignee).Text);
            return this;
        }

    }

    
}
