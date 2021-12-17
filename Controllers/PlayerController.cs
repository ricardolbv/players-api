using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using players_api.Models;
using players_api.Services;

namespace players_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("getAll")]
        public ActionResult Get()
        {
            return Ok(_playerService.GetAllPlayers());
        }

        [HttpGet("{Id}")]
        public ActionResult<Player> GetOne(int Id)
        {
            return Ok(_playerService.GetPlayerById(Id));
        }

        [HttpPost("create")]
        public ActionResult<List<Player>> Create(Player pl)
        {
            return Ok(_playerService.CreatePlayer(pl));
        }
    }
}
