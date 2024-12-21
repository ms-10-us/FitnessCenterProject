using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterProject
{
    internal class CommunityFitness
    {
        public static List<Members> CommunityOfMembers = new List<Members>();

        public CommunityFitness()
        {

        }

        public static void AddMembers(Members member)
        {
            CommunityOfMembers.Add(member);
        }

        public static void RemoveMembers(int index)
        {
            CommunityOfMembers.RemoveAt(index - 1);
        }

        public static void DisplayMemberInfo(int index)
        {
            Console.WriteLine($"Name: {CommunityOfMembers[index - 1].Name}");
            Console.WriteLine($"Id: {CommunityOfMembers[index - 1].Id}");
            if (CommunityOfMembers[index - 1].GetType() == typeof(SingleClubMember))
            {
                Console.WriteLine($"Assigned Club: {CommunityOfMembers[index - 1].AssignedClub.Name}");
            }
            else if (CommunityOfMembers[index - 1].GetType() == typeof(MultiClubMember))
            {
                Console.WriteLine($"Points: {CommunityOfMembers[index - 1].MembershipPoints}");
            }
        }

        public static void BillOfFees(int index)
        {
            Console.WriteLine();

            Console.WriteLine("******************************************************");
            Console.WriteLine("\t\t\tBill");
            Console.WriteLine("******************************************************");
            if (CommunityOfMembers[index - 1].GetType() == typeof(SingleClubMember))
            {
                Console.WriteLine("{0, -30} {1, -5}", "Fixed Annual Price", $"{100:c}");
            }
            else if (CommunityOfMembers[index - 1].GetType() == typeof(MultiClubMember))
            {
                Console.WriteLine($"Points: {CommunityOfMembers[index - 1].MembershipPoints}");
                Console.WriteLine("{0, -30} {1, -5}", "Total Price:", $"{(CommunityOfMembers[index - 1].MembershipPoints * 0.1):c}");
            }
        }

        public static void DisplayAllMembers()
        {
            Console.WriteLine();

            Console.WriteLine("Members");
            for (int i = 0; i < CommunityOfMembers.Count; i++)
            {
                Console.WriteLine("{0, -5} {1,-5} {2, -20}", i + 1, CommunityOfMembers[i].Id, CommunityOfMembers[i].Name); 
            }
        }

    }
}
