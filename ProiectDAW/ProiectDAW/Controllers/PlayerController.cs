using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Authorize]
    [Route("api/players")]
    public class PlayerController : Controller
    {
        private BDRepo bdr = new BDRepo();

        [AllowAnonymous]
        [HttpGet]
        [Route("all")]
        public IActionResult GetPlayers()
        {
            var players = bdr.GetObjects<Player>();

            return Ok(players);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            var newPlayer = bdr.PostObject<Player>(player);

            if (newPlayer == null)
                return BadRequest("Could not create team");

            return Ok(newPlayer);
        }

        [HttpPost]
        [Route("{playerName}")]
        public IActionResult PutPlayer([FromBody] Player player)
        {
            var updatedPlayer = bdr.PutObject<Player>(player);

            if (updatedPlayer == null)
                return BadRequest("Could not update user");

            return Ok(updatedPlayer);
        }

        [HttpDelete]
        [Route("{playerName}")]
        public IActionResult DeletePlayer(string playerName)
        {
            var getPlayer = bdr.GetPlayer(playerName);

            bdr.DeleteObject<Player>(getPlayer);

            return NoContent();
        }
    }
}
