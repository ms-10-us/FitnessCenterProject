using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitnessCenterProject
{
    internal class MultiClubMember : Members
    {
     
        public MultiClubMember(int id, string name) : base (id, name)
        {

        }

        public override void CheckIn(Club club)
        {
            MembershipPoints += 20;
        }
    }
}
