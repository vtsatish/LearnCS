using System;
using System.Threading;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Xunit;
using System.Diagnostics;

namespace WebDriverTests
{
    public class WindowsApplicationTests
    {
        private WindowsDriver<WindowsElement> winappDriver;
        private DesiredCapabilities appCapabilities;
        private Process winappListenerProcess;
        [Fact (Skip = "skipping as devoptions not exists")]
        [Trait("Category", "p0")]
        public void VerifyNotepadOperations()
        {
            try
            {
                string program = "C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe";
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = program;
                startInfo.UseShellExecute = false;
                winappListenerProcess = Process.Start(startInfo);
                appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", @"C:\Windows\System32\notepad.exe");
                winappDriver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
                winappDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                WindowsElement FileMenu = winappDriver.FindElementByName("File");
                Assert.True(FileMenu.Enabled);
                FileMenu.Click();
                WindowsElement ExitButton = winappDriver.FindElementByName("Exit");
                Assert.True(ExitButton.Enabled);
                Thread.Sleep(3000);
            }
            finally
            {
                winappDriver.CloseApp();
                winappListenerProcess.Kill();
            }
        }

        [Fact(Skip = "skipping as devoptions not exists")]
        [Trait("Category", "p0")]
        public void VerifyControlPanel()
        {
            try
            {
                string program = "C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe";
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = program;
                startInfo.UseShellExecute = false;
                winappListenerProcess = Process.Start(startInfo);
                appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", "windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel");
                //Microsoft.Windows.ControlPanel
                winappDriver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
                winappDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                WindowsElement Accounts = winappDriver.FindElementByName("Accounts");
                Accounts.Click();
                WindowsElement Yourinfo = winappDriver.FindElementByName("Your info");
                Thread.Sleep(3000);
                Assert.True(Yourinfo.Displayed);
                Thread.Sleep(3000);
            }
            finally
            {
                winappDriver.CloseApp();
                winappListenerProcess.Kill();
            }
        }
    }
}
