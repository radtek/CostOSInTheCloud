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
  public class TakeofflinesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Takeoffline> lTakeofflines = db.Takeoffline.GetAllCompanyTakeofflines(id);
          //return JsonConvert.SerializeObject(lTakeofflines.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Takeoffline takeoffline)
      {
          //Create
          db.Takeoffline.Add(takeoffline);
          db.SaveChanges();
          return JsonConvert.SerializeObject(takeoffline);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Takeoffline takeoffline)
      {
          //Update
          db.Takeoffline.Update(takeoffline);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Takeoffline takeoffline)
      {
          db.Takeoffline.Remove(takeoffline);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
