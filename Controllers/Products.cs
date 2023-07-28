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

    public class Products : Controller
    {
        private IProductCollecion db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProduct());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El Campo nombre no puede estar vacio.");
            }

            await db.InsertPorduct(product);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El Campo nombre no puede estar vacio.");
            }



            product._id = id;

            await db.UpdateProduct(product);
            return Created("Created", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);
            return NoContent();
        }
    }
}
