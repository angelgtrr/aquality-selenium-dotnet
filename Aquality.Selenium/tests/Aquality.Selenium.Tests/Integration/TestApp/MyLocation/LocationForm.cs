﻿using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Globalization;

namespace Aquality.Selenium.Tests.Integration.TestApp.MyLocation
{
    internal class LocationForm : Form
    {
        private const string LocatorTemplate = "//div[@aria-expanded='true']//td[contains(., '{0}')]/following-sibling::td[not(contains(.,'waiting') or contains(.,'failed'))]";
        private readonly ILabel latitudeLabel = ElementFactory.GetLabel(By.XPath(string.Format(LocatorTemplate, "Latitude")), "Latitude");
        private readonly ILabel longitudeLabel = ElementFactory.GetLabel(By.XPath(string.Format(LocatorTemplate, "Longitude")), "Longitude");
        private readonly IButton browserGeoLocationButton = ElementFactory.GetButton(By.XPath("//*[@aria-controls='geo-div']"), "Browser GeoLocation");
        private readonly IButton startTestButton = ElementFactory.GetButton(By.Id("geo-test"), "Browser GeoLocation");
        private readonly IButton dismissCookieInfoButton = ElementFactory.GetButton(By.XPath("//a[contains(@aria-label,'dismiss')]"), "Dismiss cookie info");
        
        public LocationForm() : base(By.Id("accordion"), "My Location")
        {
        }

        public void DismissCookieInfo()
        {
            dismissCookieInfoButton.Click();
            dismissCookieInfoButton.State.WaitForNotDisplayed();
        }

        public void DetectBrowserGeolocation()
        {
            browserGeoLocationButton.Click();
            startTestButton.Click();
        }

        public double Latitude => double.Parse(latitudeLabel.Text, CultureInfo.InvariantCulture);

        public double Longitude => double.Parse(longitudeLabel.Text, CultureInfo.InvariantCulture);

        public static void Open()
        {
            AqualityServices.Browser.GoTo(Constants.UrlMyLocation);
            AqualityServices.Browser.WaitForPageToLoad();
        }
    }
}
