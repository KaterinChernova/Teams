using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data.Models;
using Teams.Services;
using Microsoft.AspNetCore.Mvc;

namespace Teams.Controllers
{
    [Route("Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Получение команды по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор команды.</param>
        /// <returns>Модель команды.</returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var teamDto = await _teamService.Get(id);

            return Ok(new { Success = true, Team = teamDto});
        }

        /// <summary>
        /// Получение команды по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор команды.</param>
        /// <returns>Модель команды.</returns>
        [HttpGet]
        [Route(nameof(GetTeamsBySport))]
        public async Task<IActionResult> GetTeamsBySport(int sportId)
        {
            var teamDto = await _teamService.Get(sportId);

            return Ok(new { Success = true, Team = teamDto });
        }

        /// <summary>
        /// Добавление команды.
        /// </summary>
        /// <param name="teamDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного команды.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(TeamDto teamDto)
        {
            return Ok(new { Success = true, TeamId = await _teamService.Create(teamDto) });
        }

        /// <summary>
        /// Обновление команды.
        /// </summary>
        /// <param name="teamDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновленной команды.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(TeamDto teamDto)
        {
            return Ok(new { Success = true, TeamId = await _teamService.Update(teamDto) });
        }

        /// <summary>
        /// Удаление команды.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        /// <returns>Идентификатор обновленной команды.</returns>
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}