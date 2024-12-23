﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterProject
{
    internal static class FileOps
    {
        public static void ReadClubsFile(string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);

                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        try
                        {
                            string textLine = sr.ReadLine();
                            string[] details = textLine.Split('|');
                            if (details.Length == 2)
                            {
                                Club club = new Club(details[0], details[1]);
                                NearMeClubs.ClubsList.Add(club);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            Console.WriteLine("Please Check Log File");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                Console.WriteLine("Please Check Log File");
            }
        }

        public static void ReadMembersFile(string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);

                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        try
                        {
                            string textLine = sr.ReadLine();
                            string[] details = textLine.Split('|');
                            if (details.Length == 4)
                            {
                                if (details[2] == "1")
                                {
                                    SingleClubMember singleClubMember = new SingleClubMember(Convert.ToInt32(details[0]), details[1]);
                                    CommunityFitness.CommunityOfMembers.Add(singleClubMember);
                                    Club queriedClub = NearMeClubs.ClubsList.Where(x => x.Name == details[3]).First();
                                    singleClubMember.AssignedClub = queriedClub;
                                }
                                else if (details[2] == "2")
                                {
                                    MultiClubMember multiClubMember = new MultiClubMember(Convert.ToInt32(details[0]), details[1]);
                                    CommunityFitness.CommunityOfMembers.Add(multiClubMember);
                                    multiClubMember.MembershipPoints = Convert.ToInt32(details[3]);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            Console.WriteLine("Please Check Log File");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                Console.WriteLine("Please Check Log File");
            }

        }

        public static void WriteMembersFile(string path, int id, string name, MemberType memberType, string clubName = "", int membershipPoints = 0)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                if (memberType == MemberType.SingleClubMember)
                {
                    sw.Write($"{id}|{name}|{1}|{clubName}\n");
                }
                else if (memberType == MemberType.MultiCLubMember)
                {
                    sw.Write($"{id}|{name}|{2}|{membershipPoints}\n");
                }
            }
        }

        public static void WriteClubsFile(string path, string clubName, string address)
        {
            using (StreamWriter sr = new StreamWriter(path, true))
            {
                sr.Write($"{clubName}|{address}\n");


            }
        }

    }
}