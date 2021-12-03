using DevGames.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Persistence
{
    public class DevGamesContext
    {
        
        public DevGamesContext()
        {
            Boards = new List<Board>();
        }

        public List<Board> Boards { get; private set; }
    }
}
