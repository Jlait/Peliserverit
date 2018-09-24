using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    [Route("/api/[Controller]")]
    [ApiController]
    [NotImplExceptionFilterAttribute]

    public class ItemsController {
        ItemsProcessor processor;
        public  ItemsController(ItemsProcessor pprocessor)
        {
            processor = pprocessor;
        }

        [HttpGet(" {id}")]
        public Task<Item> GetItem(Guid Playerid, Guid id)
        {
            return processor.GetItem(Playerid, id);
        }

        [HttpGet]
        public Task<Item[]> GetAllItems(Guid Playerid)
        {
            return processor.GetAllItems(Playerid);

        }

        [HttpPost]
        public Task<Item> Create(Guid id, [FromBody] NewItem item)
        {
            return processor.Create(id, item);
        }

        [HttpPatch(" {id}")]
        public Task<Item> Modify(Guid Playerid, Guid id, [FromBody] ModifiedItem item)
        {
            return processor.Modify(Playerid, id, item);
        }

        [HttpDelete(" {id}")]
        public Task<Item> Delete(Guid Playerid, Guid id)
        {
            return processor.DeleteItem(Playerid, id);
        }
    }
 
}
