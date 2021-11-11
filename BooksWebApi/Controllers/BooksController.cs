using BooksWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BooksWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : Controller
    {
        static string FakeRestApi = ($"https://fakerestapi.azurewebsites.net/");
        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            using (HttpClient client = new())
            {
                List<Book> books;
                string path = FakeRestApi + "api/v1/Books";
                using HttpResponseMessage resp = await client.GetAsync(path);
                switch (resp.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                       books = JsonSerializer.Deserialize<List<Book>>(
                        await resp.Content.ReadAsStringAsync(), jsonOptions);
                        return Ok(books);

                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound();

                    default:
                        return BadRequest("No hemos podido realizar su peticion.");
                }
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> Get(int Id)
        {
            using (HttpClient client = new())
            {
                Book book;
                string path = FakeRestApi + $"api/v1/Books/{Id}";
                using HttpResponseMessage resp = await client.GetAsync(path);
                switch (resp.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        book = JsonSerializer.Deserialize<Book>(
                         await resp.Content.ReadAsStringAsync(), jsonOptions);
                        return Ok(book);

                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound("El libro no existe.");

                    default:
                        return BadRequest("No hemos podido realizar su peticion.");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            using (HttpClient client = new())
            {
                string path = FakeRestApi + "api/v1/Books";
                using HttpResponseMessage resp = await client.PostAsync(path,
                    new StringContent(JsonSerializer.Serialize<Book>(book, jsonOptions), Encoding.UTF8, "Application/json"));
                switch (resp.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        book = JsonSerializer.Deserialize<Book>(
                         await resp.Content.ReadAsStringAsync(), jsonOptions);
                        return Ok(book);
                    default:
                        return BadRequest("No hemos podido realizar su peticion.");
                }
            }
        }

            [HttpPut]
        public async Task<IActionResult> Put([FromBody] Book book)
        {

            using (HttpClient client = new HttpClient())
            {
                string path = FakeRestApi + $"api/v1/Books/{book.Id}";
                using HttpResponseMessage resp = await client.PutAsync(path,
                new StringContent(JsonSerializer.Serialize<Book>(book, jsonOptions), Encoding.UTF8, "application/json"));
                if (resp.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No hemos podido realizar su peticion.");
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            string path = FakeRestApi + $"api/v1/Books/{Id}";
            using (HttpClient client = new HttpClient())
            {
                using HttpResponseMessage resp = await client.DeleteAsync(path);
                if (resp.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else { return BadRequest("No hemos podido realizar su peticion."); }
            }
        }


    }
}
