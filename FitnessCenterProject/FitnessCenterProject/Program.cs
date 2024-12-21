namespace FitnessCenterProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileOps.ReadClubsFile("Clubs.txt");
            FileOps.ReadMembersFile("Members.txt");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("******************************************************");
            Console.WriteLine("\t\tFitness Center Project");
            Console.WriteLine("******************************************************");
            
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Remove Member");
                Console.WriteLine("3. Display Member");
                Console.WriteLine("4. Check-In");
                Console.WriteLine("5. Member's Bill");
                Console.WriteLine("6. Display Database Info");
                Console.WriteLine("7. Quit The Application");

                Console.ForegroundColor= ConsoleColor.Gray;

                Console.WriteLine();

                Console.WriteLine("Please Choose from Main Menu");
                int userAnswer = GetUserInput();

                Console.ForegroundColor = ConsoleColor.Green;

                switch ((UserMenu)userAnswer)
                {
                    case (UserMenu.AddMembers):

                        Console.WriteLine("Please Enter Id");
                        int id = ValidateInterger(Console.ReadLine());

                        Console.WriteLine("Please Enter Name");
                        string name = Console.ReadLine();

                        Console.WriteLine("Is this a Single Club Member or Multi-Club Member?");
                        int memberType = ValidateInterger(Console.ReadLine());
                        switch ((MemberType)memberType)
                        {
                            case (MemberType.SingleClubMember):
                                SingleClubMember singleClubMember = new SingleClubMember(id, name);
                                CommunityFitness.AddMembers(singleClubMember);

                                Console.WriteLine("Enter Club Name");
                                string clubName = Console.ReadLine();

                                Console.WriteLine("Enter Club Address");
                                string clubAddress = Console.ReadLine();

                                Club club = new Club(clubName, clubAddress);
                                singleClubMember.AssignedClub = club;
                                break;
                            case (MemberType.MultiCLubMember):
                                MultiClubMember multiClubMember = new MultiClubMember(id, name);
                                CommunityFitness.AddMembers(multiClubMember);

                                Console.WriteLine("Enter Membership Points");
                                multiClubMember.MembershipPoints = ValidateInterger(Console.ReadLine());
                                break;
                        }
                        break;

                    case (UserMenu.RemoveMembers):
                        Console.WriteLine("Please Enter Index");
                        int indexMember = ValidateInterger(Console.ReadLine());
                        CommunityFitness.RemoveMembers(indexMember);
                        break;

                    case (UserMenu.DisplayMembers):

                        Console.WriteLine("Please Enter Index");
                        indexMember = ValidateInterger(Console.ReadLine());
                        CommunityFitness.DisplayMemberInfo(indexMember);
                        break;

                    case (UserMenu.CheckIn):

                        Console.WriteLine("Please Select Member to CheckIn");
                        indexMember = ValidateInterger(Console.ReadLine());

                        Console.WriteLine("Please Select Corresponding Club");
                        int indexClub = ValidateInterger(Console.ReadLine());

                        CommunityFitness.CommunityOfMembers[indexMember - 1].CheckIn(NearMeClubs.ClubsList[indexClub - 1]);
                        break;

                    case (UserMenu.MembersBill):
                        Console.WriteLine("Please Enter Index");
                        indexMember = ValidateInterger(Console.ReadLine());

                        CommunityFitness.BillOfFees(indexMember);

                        break;

                    case (UserMenu.DatabaseInfo):
                        CommunityFitness.DisplayAllMembers();
                        NearMeClubs.DisplayAllClubs();
                        break;

                    case (UserMenu.Quit):
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("GoodBye!");
                        Environment.Exit(0);
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine();

                Console.WriteLine("Would You Like to Continue?(y/n)");
                string userPrompt = Console.ReadLine();

                if (userPrompt.ToLower().Trim() == "y")
                {
                    Console.Clear();
                    continue;
                }
                else if (userPrompt.ToLower().Trim() == "n")
                {
                    Console.WriteLine("GoodBye!");
                    break;
                }
            }

        }

        public static int GetUserInput()
        {
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());  
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Enter a Valid Option!");
            }

            return userInput;
        }

        public static int ValidateInterger(string inputInteger)
        {
            int returnedInteger = 0;
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    returnedInteger = Convert.ToInt32(inputInteger);
                    isValid = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a Valid Integer!");
                }
            }

            return returnedInteger;

        }
    }
}
