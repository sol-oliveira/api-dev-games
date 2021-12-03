using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevGames.API.Entities
{
    public class Comment
    {
        public Comment(string title, string description, string user)
        {
            Title = title;
            Description = description;
            User = user;

            CreateAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string User { get; private set; }
        public DateTime CreateAt { get; private set; }

    }
}
