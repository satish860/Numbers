using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberApi
{
    [Route("api/numbers")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private static Random _Random = new Random();

        [HttpGet]
        public IActionResult GetNumber()
        {
            var n = _Random.Next(0, 100);
            return Ok(n);
        }
    }
}
