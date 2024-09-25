using System;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using APIProject.Resources.Utils;
using Microsoft.Extensions.Configuration;
using APIProject.Resources.APIClients;

namespace APIProject.Test.APITest
{

    [SetUpFixture]
    public class GlobalSetup
    {
        public static ExtentReports _extent;


        [OneTimeSetUp]
        public void SetupReport()
        {
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../report/extentSparkReport.html");
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../report"));
            var sparkReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
            
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            _extent.Flush();
        }
    }

}

