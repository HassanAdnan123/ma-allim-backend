using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ma_allim_backend.Models;
using Microsoft.AspNetCore.Cors;

namespace ma_allim_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaallimController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return base.Content("<div><h1> Ma-allim Backend now functional </h1></div>", "text/html");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public List<singlerow> Post ([FromBody] RequestModel json)
        {
            return ResponseModel.PopulateFruits(json.noOfRecs);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
