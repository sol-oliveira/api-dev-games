﻿using DevGames.API.Entities;
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
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase  
    {
        private readonly DevGamesContext context;

        public BoardsController(DevGamesContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Boards);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var board = context.Boards.SingleOrDefault(b => b.Id == id);
            
            if(board == null)
                return NotFound();

            return Ok(context.Boards);
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel model)
        {
            var board = new Board(model.Id, model.GameTitle, model.Description, model.Rules);

            context.Boards.Add(board);

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateBoardInputModel model)
        {
            var board = context.Boards.SingleOrDefault(b => b.Id == id);

            if (board == null)
                return NotFound();

            board.Update(model.Description, model.Rules);

            return NoContent();
        }

    }
}
