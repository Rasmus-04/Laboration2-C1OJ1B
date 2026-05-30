using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2.Model
{
    public class EventMember
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
