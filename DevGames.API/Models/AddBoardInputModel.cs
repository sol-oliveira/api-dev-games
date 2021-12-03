using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Models
{
    public record AddBoardInputModel(int Id, string GameTitle, string Description, string Rules)
    {
    }
}
