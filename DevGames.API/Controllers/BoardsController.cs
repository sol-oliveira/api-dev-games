using DevGames.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {  
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel model)
        {
            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpPut]
        public IActionResult Put(UpdateBoardInputModel model)
        {
            return Ok();
        }

    }
}
