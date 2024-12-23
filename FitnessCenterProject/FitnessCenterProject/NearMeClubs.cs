using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterProject
{
    internal class NearMeClubs
    {
        public static List<Club> ClubsList  = new List<Club>();

        public NearMeClubs()
        {

        }

        public static void AddClubs(Club club)
        {
            ClubsList.Add(club);
        }

        public static void DisplayAllClubs()
        {
            Console.WriteLine();

            Console.WriteLine("Clubs");

            Console.WriteLine("{0, -5} {1,-50} {2, -70}", "Index", "Name", "Address");

            for (int i = 0; i < ClubsList.Count; i++)
            {
                Console.WriteLine("{0, -5} {1,-50} {2, -70}" ,i + 1, ClubsList[i].Name, ClubsList[i].Address); 
            }
        }

    }
}
