using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    public abstract class BaseTests
    {
        protected abstract string Url { get; }

        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Navigate().GoToUrl(Url);
            //Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Quit()
        {
            Driver.Quit();
        }
    }
}
