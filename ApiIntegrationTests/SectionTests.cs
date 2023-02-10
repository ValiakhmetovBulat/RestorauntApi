using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using RestorauntApi.Models.Entities;
using System.Text;
using System.Net.Http.Headers;
using System.Net;

namespace ApiIntegrationTests
{
    public class MenuPositionsTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public MenuPositionsTests(TestingWebAppFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Section_With_Id_1_Name_New()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/section");
            var section = new Section
            {
                Id = 1,
                Name = "New"
            };
            postRequest.Content = CreateContent(section);
            var resp = await _httpClient.SendAsync(postRequest);
            resp.EnsureSuccessStatusCode();
            var responseString = await resp.Content.ReadAsStringAsync();
            Assert.Contains("New",responseString);   
        }

        [Fact]
        public async Task Get_Section_With_Name_New()
        {
            var response = await _httpClient.GetAsync("api/section");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("New", responseString);
        }

        [Fact]
        public async Task Get_Check_Sections_Not_Null()
        {
            var response = await _httpClient.GetAsync("api/section");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var convertedRes = JsonConvert.DeserializeObject<List<Section>>(responseString);
            Assert.NotNull(convertedRes);
        }

        [Fact]
        public async Task Post_Section_With_Existed_Id_1()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/section");
            var section = new Section
            {
                Id = 1,
                Name = "New"
            };
            postRequest.Content = CreateContent(section);
            var resp = await _httpClient.SendAsync(postRequest);

            postRequest = new HttpRequestMessage(HttpMethod.Post, "api/section");
            section = new Section
            {
                Id = 1,
                Name = "New"
            };
            postRequest.Content = CreateContent(section);
            resp = await _httpClient.SendAsync(postRequest);
            Assert.True(resp.StatusCode == HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Get_Section_With_Unexisted_Id_2()
        {
            var response = await _httpClient.GetAsync("api/section/2");
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Post_Null_Object()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/section");
            var section = new Section();
            postRequest.Content = CreateContent(section);
            var resp = await _httpClient.SendAsync(postRequest);
            Assert.True(resp.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_Section_With_Name_New_To_Name_NotNew()
        {
            var putRequest = new HttpRequestMessage(HttpMethod.Put, "api/section");
            var section = new Section
            {
                Id = 1,
                Name = "NotNew"
            };
            putRequest.Content = CreateContent(section);
            var resp = await _httpClient.SendAsync(putRequest);
            resp.EnsureSuccessStatusCode();
            var responseString = await resp.Content.ReadAsStringAsync();
            Assert.Contains(section.Name, responseString);
        }

        [Fact]
        public async Task Delete_Section_With_Id_1()
        {
            var resp = await _httpClient.DeleteAsync("api/section/1");
            var respString = await resp.Content.ReadAsStringAsync();
            Assert.Contains("NotNew", respString);
        }

        private static HttpRequestMessage CreateMessage(string uri, HttpMethod method, object model)
        {
            var message = new HttpRequestMessage(method, uri);
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                return message;

            message.Content = CreateContent(model);
            return message;
        }

        private static HttpContent CreateContent(object model)
        {
            if (model is HttpContent cont)
                return cont;

            var content = new ByteArrayContent(model == null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentEncoding.Add("UTF-8");
            return content;
        }
    }
}