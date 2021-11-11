using BookWebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookWebMvc.Controlles
{
    [Route("/[controller]")]
    public class LibrosController : Controller
    {
        static string webapi = "https://localhost:5001/";
        [HttpGet]
        public ActionResult<List<Book>> Libros()
        {
            //using HttpClient client = new();
            //string path = webapi + "api/v1/Books";
            //using HttpResponseMessage resp = await client.GetAsync(path);
            //var json = await resp.Content.ReadAsStringAsync();
            //var libros = JsonSerializer.Deserialize<List<Book>>(json,
            //        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            List<Book> lib = new();
            lib.Add(new Book { Id = 1, Title = "Title1", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 2, Title = "Title2", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 3, Title = "Title3", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 4, Title = "Title4", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 5, Title = "Title5", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 6, Title = "Title6", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            return View(lib);
        }

        [HttpPost]
        public async Task<IActionResult> CrearLibro(Book book)
        {
            using (HttpClient client = new HttpClient())
            {
                string path = webapi + "api/v1/Books";
                using HttpResponseMessage resp = await client.GetAsync(path);
                if (resp.IsSuccessStatusCode)
                {
                    return View(JsonSerializer.Deserialize<List<Book>>(
                        await resp.Content.ReadAsStringAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}