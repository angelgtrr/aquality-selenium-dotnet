﻿using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;

namespace Aquality.Selenium.Elements
{
    public class Button : Element, IButton
    {
        protected Button(By locator, string name) : this(locator, name, ElementState.Displayed)
        {
        }

        internal Button(By locator, string name, ElementState state) : base(locator, name, state)
        {
        }

        protected override string ElementType => throw new NotImplementedException();
    }
}
