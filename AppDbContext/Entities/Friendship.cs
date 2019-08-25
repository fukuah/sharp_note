using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.AppDbContext.Entities
{
    public class Friendship : CommonEntity
    {
        // HasMany on a single entity is not supported yet, thus I created this entity
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public bool Approved { get; set; }

        public DateTime? ApprovedAt { get; set; }
    }
}
