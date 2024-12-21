using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterProject
{
    internal class SingleClubMember : Members
    {
        
        public SingleClubMember(int id , string name) : base (id, name)
        {

        }

        public override void CheckIn(Club club)
        {
            if (AssignedClub.Equals(club))
            {
                Console.WriteLine("Welcome to your fitness club!");
            }
            else
            {
                Console.WriteLine("This is not your fitness club!");
            }
        }



    }
}
