using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Repository;
using Microsoft.AspNetCore.Authorization;
using ProiectDAW.Models;

namespace ProiectDAW.Controllers
{
    [Authorize]
    [Route("api/team")]
    public class TeamController : Controller
    {
        private BDRepo bdr = new BDRepo();

        [HttpGet]
        [Route("all")]
        public IActionResult GetTeams()
        {
            var teams = bdr.GetObjects<Team>();

            return Ok(teams);
        }

        [HttpGet]
        [Route("{country}")]
        public IActionResult GetTeamByCountry(string country)
        {
            var teams = bdr.GetObjects<Team>();

            if (teams == null)
                return BadRequest();

            var teamsByCountry = teams.Where(x => x.Country == country);

            return Ok(teamsByCountry);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUser([FromBody] Team team)
        {
            var newTeam = bdr.PostObject<Team>(team);

            if (newTeam == null)
                return BadRequest("Could not create team");

            return Ok(team);
        }

        [HttpPost]
        [Route("{teamName}")]
        public IActionResult PutUser([FromBody] Team team)
        {
            var updatedTeam = bdr.PutObject<Team>(team);

            if (updatedTeam == null)
                return BadRequest("Could not update user");

            return Ok(updatedTeam);
        }

        [HttpDelete]
        [Route("{teamName}")]
        public IActionResult DeleteUser(string teamName)
        {
            var getTeam = bdr.GetTeam(teamName);

            bdr.DeleteObject<Team>(getTeam);

            return NoContent();
        }
    }
}