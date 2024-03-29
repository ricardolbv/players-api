﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using players_api.Models;
using players_api.Services;
using players_api.Dtos.Player;
using Microsoft.AspNetCore.Authorization;

namespace players_api.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> Get()
        {
            return Ok(await _playerService.GetAllPlayers());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetPlayerDto>>> GetOne(int Id)
        {
            return Ok(await _playerService.GetPlayerById(Id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> Create(AddPlayerDto pl)
        {
            return Ok(await _playerService.CreatePlayer(pl));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetPlayerDto>>> Update(UpdatePlayerDto player)
        {
            return Ok(await _playerService.UpdatePlayer(player));
        }

        [HttpDelete("delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> Delete(int Id)
        {
            return Ok(await _playerService.DeletePlayer(Id));
        }
    }
}
