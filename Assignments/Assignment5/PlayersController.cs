using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace assignment5
{
    
    
    [Route ("api/[controller]")]
    [ApiController]
    public class PlayersController
    {
        PlayersProcessor PP;
        public PlayersController (PlayersProcessor ppr)
        {
            PP = ppr;
        }

        [HttpGet]
        [Route ("{id:guid}")]
        public Task<Player> GetPlayer (Guid id)
        {
            return PP.GetPlayer (id);
        }

        [HttpGet]
        [Route ("{name:alpha}")]
        public Task<Player> GetPlayer (string name)
        {
            return PP.GetPlayer (name);
        } 

        [HttpGet]
        public Task<Player[]> GetAllPlayers ()
        {
            return PP.GetAllPlayers ();
        }
        [HttpGet]
        [Route ("minScore:{score}")]
        public Task<Player[]> GetAllPlayers (float score)
        {
            return PP.GetAllPlayersMinScore((int)score);
        }
        [HttpGet]
        [Route ("Type:{type}")]
        public Task<Player[]> GetAllPlayers (int type)
        {
            return PP.GetAllPlayersWithType(type);
        }
        [HttpGet]
        [Route ("AverageLevel")]
        public Task<AverageInfo> GetAverageLevel(){
            return PP.GetAverageLevel();
        }

        [HttpPost]
        public Task<Player> CreatePlayer ([FromBody] NewPlayer player)
        {
            return PP.CreatePlayer (player);
        }

        [HttpPut ("{id}")]
        public Task<Player> ModifyPlayer (Guid id, [FromBody] ModifiedPlayer player)
        {
            return PP.ModifyPlayer (id, player);

        }

        [HttpDelete ("{id}")]
        public Task<Player> DeletePlayer (Guid id)
        {
            return PP.DeletePlayer (id);
        }

    }
    public class AverageInfo
    {
        public float level {get;set;}
        public float howMany{get;set;}
    }
}