using BirthList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace BirthList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthItemController : ControllerBase
    {

        // GET: api/<BirthItemController>
        [HttpGet]
        public async Task<IEnumerable<BirthItem>> GetAsync()
        {

            List<BirthItem> birthItems = new List<BirthItem>();
            var directory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(directory, "data.json");

            using (var streamReader = new StreamReader(filePath))
            {
                var jsonreader = await streamReader.ReadToEndAsync();

                birthItems = JsonSerializer.Deserialize<List<BirthItem>>(jsonreader);
            }
            

            return birthItems;
        }

        // PUT api/<BirthItemController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BirthItem birthItem)
        {
            List<BirthItem> birthItems = new List<BirthItem>();
            var directory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(directory, "data.json");

            using (var streamReader = new StreamReader(filePath))
            {
                var jsonreader = await streamReader.ReadToEndAsync();

                birthItems = System.Text.Json.JsonSerializer.Deserialize<List<BirthItem>>(jsonreader);
            }


            var toupdate = birthItems.Find(x=> x.Id == id);
            toupdate.isAvaillable = birthItem.isAvaillable;


            /// Modifier le fichier
            for (int i = 0; i < birthItems.Count; i++)
            {
                if (birthItems[i].Id == toupdate.Id)
                {
                    birthItems[i].isAvaillable = toupdate.isAvaillable;
                }
            }



            /// Réécrire le fichier
            string jsonString = JsonSerializer.Serialize(birthItems);
            System.IO.File.WriteAllText(filePath, jsonString);

        }

    }
}
