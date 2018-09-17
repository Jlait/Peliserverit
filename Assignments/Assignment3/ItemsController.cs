using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
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
        public Task<Item> Get(Guid id)
        {
            return processor.GetItem(id);
        }

        [HttpGet]
        public Task<Item[]> GetAll()
        {
            return processor.GetAll();

        }

        [HttpPost]
        public Task<Item> Create(Guid id, [FromBody] NewItem item)
        {
            return processor.Create(id, item);
        }

        [HttpPatch(" {id}")]
        public Task<Item> Modify(Guid id, [FromBody] ModifiedItem item)
        {
            return processor.Modify(id, item);
        }

        [HttpDelete(" {id}")]
        public Task<Item> Delete(Guid id)
        {
            return processor.DeleteItem(id);
        }
    }
 
}
