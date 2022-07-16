using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework13
{
    internal class TestsHomework14 : BaseTests

    {
        protected override string Url => @"file:///C:/Users/Max/source/repos2/Homework13/Homework13/Htmls/Register/register.html";

        [Test]
        public void ValidateClearButton()
        {
            EnterFirstName("Anna");
            EnterLastName("Smith");
            SelectFemaleGender();
            SelectFavouriteTechnologies();
            ClickClearButton();
            Assert.That(Driver.FindElement(By.CssSelector("#fname")).Text, Is.EqualTo(""));
            Assert.That(Driver.FindElement(By.CssSelector("#lname")).Text, Is.EqualTo(""));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("input[id='male']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='java']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='cs']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='html']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='css']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='js']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("#clear")).Enabled);
        }
        [Test]
        public void ValidateRefreshClearsContent()
        {
            EnterFirstName("Anna");
            EnterLastName("Smith");
            SelectFemaleGender();
            SelectFavouriteTechnologies();
            RefreshBrowser();
            Assert.That(Driver.FindElement(By.CssSelector("#fname")).Text, Is.EqualTo(""));
            Assert.That(Driver.FindElement(By.CssSelector("#lname")).Text, Is.EqualTo(""));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("input[id='male']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='java']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='cs']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='html']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='css']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='js']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("#clear")).Enabled);
        }
        [Test]
        public void ValidateEnablingRegisterAndClearButtons()
        {
            EnterFirstName("Anna");
            EnterLastName("Smith");
            Driver.FindElement(By.TagName("body")).Click();
            Assert.IsTrue(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsTrue(Driver.FindElement(By.CssSelector("#clear")).Enabled);
            ClearFirstName();
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsTrue(Driver.FindElement(By.CssSelector("#clear")).Enabled);
            ClearLastName();
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("#clear")).Enabled);
        }

        [Test]
        public void ValidateDivElementIsDashed()
        {
            IWebElement divElement = Driver.FindElement(By.CssSelector("div"));
            Assert.That(divElement.GetAttribute("style"), Does.Contain("dashed"));
        }
        [Test]
        public void ValidateRadioButtonsPosition()
        {
            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            int xCoordinateFemaleRadioButton = femaleRadioInput.Location.X;
            IWebElement maleRadioInput = Driver.FindElement(By.CssSelector("input[id='male']"));
            int xCoordinateMaleRadioButton = maleRadioInput.Location.X;
            Assert.That(xCoordinateFemaleRadioButton, Is.GreaterThan(xCoordinateMaleRadioButton));
        }

        [Test]
        public void ValidateCountOfAttribute()
        {
            List<IWebElement> elements = Driver.FindElements(By.CssSelector("[onclick='submitData()']")).ToList();
            Assert.AreEqual(elements.Count, 1);
        }
    }
}