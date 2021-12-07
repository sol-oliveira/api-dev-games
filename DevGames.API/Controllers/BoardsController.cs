using AutoMapper;
using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
using DevGames.API.Persistence.Repositories;
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
        private readonly IBoardRepository repository;
        private readonly IMapper mapper;

        public BoardsController(IBoardRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var boards = repository.GetAll();

            return Ok(boards);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var board = repository.GetById(id);

            if (board == null)
                return NotFound();

            return Ok(board);
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel model)
        {
            var board = mapper.Map<Board>(model);

            repository.Add(board);

            return CreatedAtAction("GetById", new { id = board.Id }, model);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateBoardInputModel model)
        {
            var board = repository.GetById(id);

            if (board == null)
                return NotFound();

            board.Update(model.Description, model.Rules);

            repository.Update(board); 

            return NoContent();
        }

    }
}
