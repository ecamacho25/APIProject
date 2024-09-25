namespace APIProject.Test.APITest.User;

using APIProject.Resources.Pages;
using APIProject.Test.APITest;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using APIProject.Resources.Utils;

public class APIUserTest : BaseTest
{

    private APIUser _apiUser;

    [SetUp]
    public void Setup()
    {
        _apiUser = new APIUser(_apiClientManager);
        _test = GlobalSetup._extent.CreateTest(TestContext.CurrentContext.Test.Name).AssignCategory("User Tests");

    }


    [Test, Description("This test checks if GET /users is response as expected - code 200")]
    [Category("User Tests")]
    public async Task VerifyUserInfo()
    {
        var expectedResponseContent = Utils.ReadJsonFileFromTestdata("GetUser.json");
        var expectedCity = JsonConvert.DeserializeObject<APIUser>(expectedResponseContent);

        var response = await _apiUser.GetUserById("2");
        var actualUser = JsonConvert.DeserializeObject<APIUser>(response.Content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), $"HTTP code expected is {System.Net.HttpStatusCode.OK} but It returned {response.StatusCode}");

        Assert.That(actualUser.Data.First_Name, Is.EqualTo(expectedCity.Data.First_Name));

        

    }

    [Test, Description("This test checks if GET /users response not found for non-existing user")]
    [Category("User Tests")]
    public async Task VerifyUserNotFound()
    {
        var response = await _apiUser.GetUserById("23");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), $"HTTP code expected is {System.Net.HttpStatusCode.NotFound} but It returned {response.StatusCode}");

    }

    [Test, Description("This test checks if POST /users works as expected")]
    [Category("User Tests")]
    public async Task CreateUserSuccess()
    {

        var newUser = new UserPost
        {
            Name = "Edier",
            Job = "QA Automation"
        };

        var response = await _apiUser.CreateUserSuccess(newUser);
        var createdUser = JsonConvert.DeserializeObject<UserPost>(response.Content);
        
        DateTime creationDateTime = createdUser.CreatedAt;

        DateTime truncatedCreationDateTime = new DateTime(creationDateTime.Year, creationDateTime.Month, creationDateTime.Day, creationDateTime.Hour, 0, 0);
        DateTime truncatedCurrentDateTime = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, 0, 0);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        Assert.That(createdUser.Name, Is.EqualTo(newUser.Name));
        Assert.That(createdUser.Job, Is.EqualTo(newUser.Job));
        Assert.That(truncatedCreationDateTime, Is.EqualTo(truncatedCurrentDateTime), "The creation date and current date do not match up to the hour.");
    }
}

