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
    public class UserController : ControllerBase
    {
        // POST api/values
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public List<UserModel> Post ()
        {
            return ResponseModel.FetchUsers();
        }

        [HttpGet]
        public string Get()
        {
            return "Ma-allim portal API running";
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
