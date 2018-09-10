using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    [Route ("api/[controller]")]
    [ApiController]

    public class PlayersController
    {
        PlayersProcessor processor;

        public PlayersController(PlayersProcessor pprocessor)
        {
            processor = pprocessor;
        }

        [HttpGet (" {id}")]
        public Task<Player> Get(Guid id)
        {
            return processor.Get(id);
        }

        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return processor.GetAll();

        }
        [HttpPost]
        public Task<Player> Create([FromBody] NewPlayer player)
        {
            return processor.Create(player);
        }

        [HttpPatch(" {id}")]
        public Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            return processor.Modify(id, player);
        }

        [HttpDelete(" {id}")]
        public Task<Player> Delete(Guid id)
        {
            return processor.Delete(id);
        }
    }
}
