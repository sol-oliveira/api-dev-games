using DevGames.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Persistence.Repositories
{
    public interface IBoardRepository
    {
        IEnumerable<Board> GetAll();
        Board GetById(int id);
        void Add(Board board);
        void Update(Board board);
    }
}
