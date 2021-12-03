using DevGames.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Controllers
{
    [Route("api/board/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            return Ok();
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int id, AddPostInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }       
    }

}

