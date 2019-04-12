using ContentClient.Models;
using ContentManagerBFF;
using ContentManagerBFFTests;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        private HttpClient apiClient;

        [SetUp]
        public void Setup()
        {
            var contentApiUrl = Configurations.GetContentApiUrl();
            Environment.SetEnvironmentVariable("CONTENT_API_URL", contentApiUrl);
            var server = new TestServer(Program.CreateWebHostBuilder());
            this.apiClient = server.CreateClient();
        }

        private Media GetSampleMedia()
        {
            return new Media()
            {
                Description = "Isso aqui é uma imagem muito legal",
                Name = "rosa",
                Path = "/images/rosa.png",
                Type = MediaType.Image
            };
        }

        [Test]
        public async Task Post_Media()
        {
            // Arrange
            var media = this.GetSampleMedia();
            var json = JsonConvert.SerializeObject(media);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            // Act
            var httpResponse = await this.apiClient.PostAsync("/api/media", content);
            var responseJson = await httpResponse.Content.ReadAsStringAsync();
            var resultMedia = JsonConvert.DeserializeObject<List<Media>>(responseJson);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.IsNotNull(resultMedia);
        }

        [Test]
        public async Task Get_Media()
        {
            // Arrange
            var media = this.GetSampleMedia();
            var json = JsonConvert.SerializeObject(media);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            // Act
            var httpResponse = await this.apiClient.GetAsync("/api/media");
            var responseJson = await httpResponse.Content.ReadAsStringAsync();
            var resultMedia = JsonConvert.DeserializeObject<List<Media>>(responseJson);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.IsNotNull(resultMedia);
        }
    }
}