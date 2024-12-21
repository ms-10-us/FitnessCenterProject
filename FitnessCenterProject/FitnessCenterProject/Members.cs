using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterProject
{
    internal abstract class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Club AssignedClub { get; set; }
        public int MembershipPoints { get; set; }

        public Members(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract void CheckIn(Club club);

    }
}
