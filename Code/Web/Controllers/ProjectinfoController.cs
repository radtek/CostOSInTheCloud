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
  public class ProjectinfosController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projectinfo> lProjectinfos = db.Projectinfo.GetAllCompanyProjectinfos(id);
          //return JsonConvert.SerializeObject(lProjectinfos.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projectinfo projectinfo)
      {
          //Create
          db.Projectinfo.Add(projectinfo);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projectinfo);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projectinfo projectinfo)
      {
          //Update
          db.Projectinfo.Update(projectinfo);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projectinfo projectinfo)
      {
          db.Projectinfo.Remove(projectinfo);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
