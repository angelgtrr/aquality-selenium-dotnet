using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquality.Selenium.Tests.Unit
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    internal class Tests
    {
        [Test]
        public void AddCookie()
        {
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie("key", "value")); 
        }

    }
}
