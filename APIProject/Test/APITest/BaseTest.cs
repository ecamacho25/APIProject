using System;
using APIProject.Resources.APIClients;
using APIProject.Resources.Utils;
using Microsoft.Extensions.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace APIProject.Test.APITest
{

	public abstract class BaseTest
	{

        protected ExtentTest _test;
        protected DateTime currentDateTime = DateTime.UtcNow;

        protected Dictionary<string, string> properties;
        protected ApiSettings _apiSettings;
        protected APIClientManager _apiClientManager;



        [SetUp]
        public virtual void BaseSetup()
        {
            var configuration = ConfigLoader.LoadConfiguration();
            properties = PropertiesLoader.LoadProperties();
            _apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            _apiClientManager = new APIClientManager(_apiSettings.BaseAPIUrl);
           // _test = GlobalSetup._extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [TearDown]
        public void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                _test.Pass("Test passed");
            }
            else if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                _test.Fail($"Test failed: {TestContext.CurrentContext.Result.Message}");
            }
        }

       
    }
}

