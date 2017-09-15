using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Dockering.IntegrationTests
{
    public class UnitTest1
    {
        public const string AppRoot = "http://dockering";
        public const string MailRoot = "http://mail:8025/api/v2";

        [Fact]
        public async Task Test1Async()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{AppRoot}");
                response.EnsureSuccessStatusCode();

                response = await client.GetAsync($"{MailRoot}/messages");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var messages = JObject.Parse(content);

                messages.Should().HaveElement("total").Which.Should().Be(1);
            }
        }
    }
}
 