using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordPressApiClient.Tests
{
    [TestClass]
    public class WordPressApiClientTests
    {
        [TestMethod]
        public void GetUsersWorks()
        {
            Uri siteUri = new Uri("https://resmanknowledgebase.azurewebsites.net");
            var task = WordPressApiJwtAuthenticator.Create(siteUri, "resman", "9Eyb4^V^UvuS%vweT!");
            task.Wait();
            var authenticator = task.Result;

            WordPressApiClient client = new WordPressApiClient(siteUri, authenticator);

            var usersTask = client.GetUsersAsync();
            usersTask.Wait();
            var users = usersTask.Result;
            Assert.AreNotEqual(0, users.Count);
        }
    }
}
