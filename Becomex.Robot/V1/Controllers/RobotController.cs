using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Becomex.Robot.Api.Controllers;
using Becomex.Robot.Application.Interfaces;
using Becomex.Robot.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Becomex.Robot.Api.V1.Controllers
{
    public class RobotController : BaseController
    {
        private readonly IRobot _robot;

        public RobotController(IRobot robot)
        {
            _robot = robot;
        }

        /// <summary>
        /// get robot
        /// </summary>
        /// <param name="apiVersion">API version.</param>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(ApiVersion apiVersion)
        {
            var robot = await _robot.GetRobotAsync();
      
            return Ok(robot);
        }

        /// <summary>
        /// Initialize robot
        /// </summary>
        /// <param name="apiVersion">API version.</param>
        /// <param name="robot">Entity robot</param>
        [HttpPut("initialize")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Update(ApiVersion apiVersion, [FromBody] Domain.Entities.Robot robot)
        {
            return Ok(await _robot.InitialAsync(robot));
        }

        /// <summary>
        /// Move head
        /// </summary>
        /// <param name="apiVersion">API version.</param>
        /// <param name="robot">Entity robot</param>
        [HttpPut("moveHead")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> MoveHead(ApiVersion apiVersion, [FromBody]  Domain.Entities.Robot robot)
        {
            try
            {
                return Ok(await _robot.MoveHeadAsync(robot));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Move Ancon
        /// </summary>
        /// <param name="apiVersion">API version.</param>
        /// <param name="robot">Entity Robot</param>
        [HttpPut("moveAncon")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> MoveAncon(ApiVersion apiVersion, [FromBody]  Domain.Entities.Robot robot)
        {
            try
            {
                return Ok(await _robot.MoveAnconAsync(robot));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Move fist
        /// </summary>
        /// <param name="apiVersion">API version.</param>
        /// <param name="robot">Entity Robot</param>
        [HttpPut("moveFist")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> MoveFist(ApiVersion apiVersion, [FromBody]  Domain.Entities.Robot robot)
        {
            try
            {
                return Ok(await _robot.MoveFistAsync(robot));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
