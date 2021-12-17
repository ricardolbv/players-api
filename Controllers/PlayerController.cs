using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using players_api.Models;

namespace players_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private static List<Player> players = new List<Player>
        {
            new Player{Name = "Test1", Age = 17, Id = 1},
            new Player{Name = "Test2", Age = 18, Id = 2}
        };

        [HttpGet("getAll")]
        public ActionResult Get()
        {
            return Ok(players);
        }

        [HttpGet("{Id}")]
        public ActionResult<Player> GetOne(int Id)
        {
            Player pl = players.FirstOrDefault(p => p.Id == Id);

            if (pl == null)
                return NotFound();

            return Ok(pl);
        }

        [HttpPost("create")]
        public ActionResult<List<Player>> Create(Player pl)
        {
            players.Add(pl);

            return Ok(players);
        }
    }
}
