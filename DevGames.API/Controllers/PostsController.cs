using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
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
        private readonly DevGamesContext context;

        public PostsController(DevGamesContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var posts = context.Posts.Where(b => b.BoardId == id);           

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
             var post = context.Posts.SingleOrDefault(p => p.Id == postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(int id, AddPostInputModel model)
        {
            var post = new Post(model.Title, model.Description, id);

            context.Posts.Add(post);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = post.Id, postId = post.Id }, model);
        }

        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id, int postId, AddPostInputModel model)
        {
            var postExists = context.Posts.Any(p => p.Id == postId);

            if (!postExists)
                return NotFound();

            var comment = new Comment(model.Title, model.Description, model.User, postId);

            context.Comments.Add(comment);
            context.SaveChanges();

            return NoContent();
        }
    }

}

