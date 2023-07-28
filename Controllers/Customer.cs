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

    public class Customer : Controller
    {
        private ICustomerCollecion db = new CustomerCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllcustomer());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsDetails(string id)
        {
            return Ok(await db.GetcustomerById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] Cuatomer product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            

            await db.Insertcustomer(product);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Cuatomer product, string id)
        {



            product._id = id;

            await db.Updatecustomer(product);
            return Created("Created", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.Deletecustomer(id);
            return NoContent();
        }
    }
}
