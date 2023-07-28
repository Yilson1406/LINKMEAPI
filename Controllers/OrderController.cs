using LINKME.Data;
using LINKME.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Controllers
{

        [Route("api/[controller]")]
        [ApiController]

        public class Orders : Controller
        {
            private IOrderCollecion db = new OrderCollection();

            [HttpGet]
            public async Task<IActionResult> GetAllOrder()
            {
                return Ok(await db.GetAllorder());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetOrderDetails(string id)
            {
                return Ok(await db.GetorderById(id));
            }
            [HttpPost]
            public async Task<IActionResult> InsertOrder([FromBody] Order order)
            {
                if (order == null)
                {
                    return BadRequest();
                }
                

                await db.Insertorder(order);
                return Created("Created", true);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateOrder([FromBody] Order order, string id)
            {
                if (order == null)
                {
                    return BadRequest();
                }




                order._id = id;

                await db.Updateorder(order);
                return Created("Created", true);
            }
        }
    
}
