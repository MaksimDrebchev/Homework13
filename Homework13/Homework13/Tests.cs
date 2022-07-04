using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework13
{
    public class Tests : BaseTests
    {
        protected override string Url => @"file:///C:/Users/Max/source/repos2/Homework13/Homework13/Htmls/Register/register.html";

        [Test]
        public void RegisterWithFavouriteTechnologies()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("Anna");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Smith");

            IWebElement femaleRadioLabel = Driver.FindElement(By.CssSelector("label[for='female']"));
            femaleRadioLabel.Click();
            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            bool selected = femaleRadioInput.Selected;
            Assert.IsTrue(selected);

            IWebElement htmlCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='html']"));
            htmlCheckBoxLabel.Click();
            IWebElement htmlCheckBoxInput = Driver.FindElement(By.CssSelector("input[id='html']"));
            Assert.IsTrue(htmlCheckBoxInput.Selected);

            IWebElement cssCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='css']"));
            cssCheckBoxLabel.Click();
            IWebElement cssCheckBoxInput = Driver.FindElement(By.CssSelector("input[id='css']"));
            Assert.IsTrue(cssCheckBoxInput.Selected);

            IWebElement jsCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='js']"));
            jsCheckBoxLabel.Click();
            IWebElement jsCheckBoxInput = Driver.FindElement(By.CssSelector("input[id='js']"));
            Assert.IsTrue(jsCheckBoxInput.Selected);


            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();
            Driver.SwitchTo().Alert().Accept();

            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));
            Assert.That(firstParagraph.Text, Does.Contain("Name: Anna Smith"));
            Assert.That(firstParagraph.Text, Does.Contain("Gender:Female"));

            IWebElement secondParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(2)"));
            Assert.That(secondParagraph.Text, Does.Contain("Favourite technologies: HTML,CSS,JavaScript"));

        }
        [Test]
        public void RegisterWithoutFavouriteTechnologies()
        {
            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys("Anna");

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys("Smith");

            IWebElement femaleRadioLabel = Driver.FindElement(By.CssSelector("label[for='female']"));
            femaleRadioLabel.Click();
            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            bool selected = femaleRadioInput.Selected;
            Assert.IsTrue(selected);

            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();
            Driver.SwitchTo().Alert().Accept();

            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));
            Assert.That(firstParagraph.Text, Does.Contain("Name: Anna Smith"));
            Assert.That(firstParagraph.Text, Does.Contain("Gender:Female"));

            IWebElement secondParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(2)"));
            Assert.That(secondParagraph.Text, Does.Contain("No favourite technologies"));

        }


    }
}


