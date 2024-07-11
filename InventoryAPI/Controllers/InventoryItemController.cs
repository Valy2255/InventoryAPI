using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly InventoryItemManager inventoryItemManager;
        public InventoryItemController()
        {
            inventoryItemManager = new InventoryItemManager();
        }

        [HttpGet]
        public IActionResult GetInventoryItems()
        {
            return Ok(inventoryItemManager.GetInventoryItems());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetInventoryItem(int id)
        {
            var inventoryItem = inventoryItemManager.GetInventoryItem(id);
            if (inventoryItem == null)
            {
                return NotFound($"can't find the item with id: {id} ");
            }
            return Ok(inventoryItem);
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] InventoryItem item)
        {
            try
            {
                inventoryItemManager.AddItem(item);
                return Created();
            }
            catch
            {
                return BadRequest("The request is not valid");
            }
        }

        [HttpPut]
        public IActionResult UpdateItem([FromBody] InventoryItem item)
        {
            try
            {
                inventoryItemManager.UpdateItem(item);
                return Ok();
            }
            catch
            {
                return BadRequest("The request is not valid");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveItem(int id)
        {
            try
            {
                inventoryItemManager.RemoveItem(id);
                return Ok();
            }
            catch
            {
                return BadRequest($"can't find the item with id: {id}");

            }
        }


    }
}
