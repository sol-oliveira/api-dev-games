using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Models
{
    public record UpdateBoardInputModel(int Id, string Description, string Rules)
    {
    }
}
