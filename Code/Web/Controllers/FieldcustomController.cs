using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
  
  [Route("api/[controller]")]
  //[Authorize]
  [ApiController]
  public class FieldcustomsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Fieldcustom> lFieldcustoms = db.Fieldcustom.GetAllCompanyFieldcustoms(id);
          //return JsonConvert.SerializeObject(lFieldcustoms.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Fieldcustom fieldcustom)
      {
          //Create
          db.Fieldcustom.Add(fieldcustom);
          db.SaveChanges();
          return JsonConvert.SerializeObject(fieldcustom);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Fieldcustom fieldcustom)
      {
          //Update
          db.Fieldcustom.Update(fieldcustom);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Fieldcustom fieldcustom)
      {
          db.Fieldcustom.Remove(fieldcustom);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
