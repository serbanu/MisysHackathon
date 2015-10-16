using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    
    public class Person
    {
        public string ShortName;
        public string LongName;
        public string DateOfBirth;
        public string Hobby;

        public Person(string ShortName, string LongName, string DateOfBirth, string Hobby)
        {
            this.ShortName = ShortName;
            this.LongName = LongName;
            this.DateOfBirth = DateOfBirth;
            this.Hobby = Hobby;
        }
    }

    public class Birthday
    {
        public string Key;
        public string ShortUser;
        public string Bagman;
        public string DateOfBirth;
        public string Suggestion;

        public Birthday(string ShortUser, string Bagman, string DateOfBirth, string Suggestion)
        {
            this.ShortUser = ShortUser;
            this.Bagman = Bagman;
            this.DateOfBirth = DateOfBirth;
            this.Suggestion = Suggestion;
        }
    }

    public class UserFriend
    {
        public string ShortUser;
        public string ShortUserFriend;

        public UserFriend(string ShortUser, string ShortUserFriend)
        {
            this.ShortUser = ShortUser;
            this.ShortUserFriend = ShortUserFriend;
        }
    }

    public class Contribution
    {
        public string Key;
        public string ShortUser;
        public string Amount;
        public string HasPaid;

        public Contribution(string ShortUser, string Amount, string HasPaid)
        {
            this.ShortUser = ShortUser;
            this.Amount = Amount;
            this.HasPaid = HasPaid;
        }
    }

    public class IO_Operations
    {
        static int userInc = 13;
        static int ContributionInc = 11;
        static int bagmanInc = 38;
        static int birthdayInc = 11;
        static string path = @"\\bucd480\Home\smardalo\HacKaThon\DB\";
        static string toUsers = path + "users.txt";
        static string toContributions = path + "contributions.txt";
        static string toUsersFriends = path + "users_friends.txt";
        static string toBirthdays = path + "birthdays.txt";
        static string toUsersCounter = path + "user_counter.txt";
        static string toContributionCounter = path + "contribution_counter.txt";
        static string toBagmanCounter = path + "bagmen_counter.txt";
        static string toBirthdayCounter = path + "birthday_counter.txt";
        
        public static void Main(string[] args)
        {
            cleanFiles();
            writeToUsers(toUsers);
            writeToContributions(toContributions);
            writeToUsersFriends(toUsersFriends);
            writeToBirthdays(toBirthdays);
            //writeToBirthdayCustom(toBirthdays, new Birthday("ppopescu", "smardalo", "12/06", "Inot, calarie, ciclism"));
        }

        private static void cleanFiles()
        {
            System.IO.File.WriteAllText(toUsers, string.Empty);
            System.IO.File.WriteAllText(toContributions, string.Empty);
            System.IO.File.WriteAllText(toUsersFriends, string.Empty);
            System.IO.File.WriteAllText(toBirthdays, string.Empty);
            System.IO.File.WriteAllText(toUsersCounter, string.Empty);
            System.IO.File.WriteAllText(toContributionCounter, string.Empty);
            System.IO.File.WriteAllText(toBagmanCounter, string.Empty);
            System.IO.File.WriteAllText(toBirthdayCounter, string.Empty);
        }

        private static void writeCounter(string path, int inc)
        {
           using (System.IO.StreamWriter file =
                     new System.IO.StreamWriter(path))
            {
                file.WriteLine(inc);
                inc++;
            }
        }

        #region WriteFunctions
        public static void writeToUsers(string path)
        {
            if (new FileInfo(path).Length == 0)
            {
                
            using (System.IO.StreamWriter file =
                     new System.IO.StreamWriter(path))
                {
                    file.WriteLine("igheorgh|Iosif Gheorghe|19/12/1993|Swimming,Chess,Skateboarding");
                    file.WriteLine("ioneicut|Ionela Neicut|03/06/1993|Knitting,Pottery,Singing,(Public) Speaking");
                    file.WriteLine("smardalo|Serban Mardaloescu|08/02/1993|Music,Drawing,Traveling");
                    file.WriteLine("rstefane|Radu Stefanescu|01/02/1970|Hicking,Bycicles,Guitar");
                    file.WriteLine("alealexe|Alexandru Alexe|01/01/1970|Sailing,Wine tasting,Gaming");
                    file.WriteLine("andbarac|Andreea Barac|01/03/1970|Dancing,Novels,Oriental Music");
                    file.WriteLine("diansica|Diana Sica|01/04/70|Guitar,Animals,Books");
                    file.WriteLine("dpopescu|Dan Popescu|01/05/1970|Sun glasses,Keyboards,Piano");
                    file.WriteLine("acioroiu|Adrian Cioroiu|01/06/1970|Cars,Metal,Hiking");
                    file.WriteLine("taflorea|Tatiana Florea|01/07/1970|Rap,Flowers,Flies");
                    file.WriteLine("andpavel|Andrei Pavel|01/08/1970|Gaming,Gambling,Swimming, Voleyball");
                    file.WriteLine("mihratoi|Mihaela Tanasescu|01/09/1970|Painting,Bycicling,Theatre,Fashion");
                }
            }
        }

        public static void writeToUsersCustom(string path, Person p)
        {
            if (new FileInfo(toUsersCounter).Length > 0)
            {
                using (System.IO.StreamWriter file =
                     new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(p.ShortName + "|" + p.LongName + "|" + p.DateOfBirth);
                }
            }
        }

        public static void writeToContributions(string path)
        {
            if (new FileInfo(path).Length == 0)
            {
                using (System.IO.StreamWriter file =
                         new System.IO.StreamWriter(path))
                {
                
                    file.WriteLine("b1|dpopescu|20|1");
                    file.WriteLine("b1|ioneicut|20|1");
                    file.WriteLine("b1|igheorgh|20|1");
                    file.WriteLine("b1|diansica|20|1");
                    file.WriteLine("b2|andbarac|20|1");
                    file.WriteLine("b2|igheorgh|20|1");
                    file.WriteLine("b2|rstefane|20|1");
                    file.WriteLine("b2|smardalo|20|1");
                    file.WriteLine("b3|alealexe|20|1");
                    file.WriteLine("b3|ioneicut|20|1");
                    file.WriteLine("b3|smardalo|20|1");
                    file.WriteLine("b3|mihratoi|20|1");
                    file.WriteLine("b3|andpavel|20|1");
                    file.WriteLine("b3|taflorea|20|1");
                    file.WriteLine("b4|andbarac|20|1");
                    file.WriteLine("b4|ioneicut|20|1");
                    file.WriteLine("b4|igheorgh|20|1");
                    file.WriteLine("b4|smardalo|20|1");
                    file.WriteLine("b5|rstefane|20|1");
                    file.WriteLine("b5|taflorea|20|1");
                    file.WriteLine("b5|smardalo|20|1");
                    file.WriteLine("b5|mihratoi|20|1");
                    file.WriteLine("b6|igheorgh|20|1");
                    file.WriteLine("b6|smardalo|20|1");
                    file.WriteLine("b6|alealexe|20|1");
                    file.WriteLine("b6|rstefane|20|1");
                    file.WriteLine("b7|taflorea|20|1");
                    file.WriteLine("b7|rstefane|20|1");
                    file.WriteLine("b7|andbarac|20|1");
                    file.WriteLine("b7|andpavel|20|1");
                    file.WriteLine("b8|rstefane|20|1");
                    file.WriteLine("b8|andpavel|20|1");
                    file.WriteLine("b8|smardalo|20|1");
                    file.WriteLine("b8|diansica|20|1");
                    file.WriteLine("b9|mihratoi|20|1");
                    file.WriteLine("b9|smardalo|20|1");
                    file.WriteLine("b9|ioneicut|20|1");
                    file.WriteLine("b10|rstefane|20|1");
                    file.WriteLine("b10|ioneicut|20|1");
                    file.WriteLine("b10|alealexe|20|1");
                    file.WriteLine("b10|andbarac|20|1");
                }
            }
        }

        public static void writeToContributionsCustom(string path, Contribution c)
        {
            if (new FileInfo(toContributionCounter).Length > 0)
            {
                using (System.IO.StreamWriter file =
                                        new System.IO.StreamWriter(path, true))
                {    
                    file.WriteLine("b" + ContributionInc++ + "|" + c.ShortUser + "|" + c.Amount + "|" + c.HasPaid);
                }
            }  
        }

        public static void writeToUsersFriends(string path)
        {
            if (new FileInfo(path).Length == 0)
            {
                using (System.IO.StreamWriter file =
                         new System.IO.StreamWriter(path))
                {
                
                    file.WriteLine("smardalo|dpopescu");
                    file.WriteLine("smardalo|ioneicut");
                    file.WriteLine("smardalo|diansica");
                    file.WriteLine("smardalo|igheorgh");

                    file.WriteLine("igheorgh|andbarac");
                    file.WriteLine("igheorgh|rstefane");
                    file.WriteLine("igheorgh|smardalo");

                    file.WriteLine("ioneicut|alealexe");
                    file.WriteLine("ioneicut|smardalo");
                    file.WriteLine("ioneicut|mihratoi");
                    file.WriteLine("ioneicut|andpavel");
                    file.WriteLine("ioneicut|taflorea");

                    file.WriteLine("rstefane|andbarac");
                    file.WriteLine("rstefane|ioneicut");
                    file.WriteLine("rstefane|igheorgh");
                    file.WriteLine("rstefane|smardalo");

                    file.WriteLine("alealexe|rstefane");
                    file.WriteLine("alealexe|taflorea");
                    file.WriteLine("alealexe|smardalo");
                    file.WriteLine("alealexe|mihratoi");

                    file.WriteLine("andbarac|igheorgh");
                    file.WriteLine("andbarac|smardalo");
                    file.WriteLine("andbarac|alealexe");
                    file.WriteLine("andbarac|rstefane");

                    file.WriteLine("diansica|taflorea");
                    file.WriteLine("diansica|rstefane");
                    file.WriteLine("diansica|andbarac");
                    file.WriteLine("diansica|andpavel");

                    file.WriteLine("dpopescu|rstefane");
                    file.WriteLine("dpopescu|andpavel");
                    file.WriteLine("dpopescu|smardalo");
                    file.WriteLine("dpopescu|diansica");

                    file.WriteLine("acioroiu|mihratoi");
                    file.WriteLine("acioroiu|smardalo");
                    file.WriteLine("acioroiu|ioneicut");

                    file.WriteLine("andpavel|rstefane");
                    file.WriteLine("andpavel|ioneicut");
                    file.WriteLine("andpavel|alealexe");
                    file.WriteLine("andpavel|andbarac");
                }
            }
        }

        public static void writeToUsersFriendsCustom(string path, UserFriend u)
        {   
            if (new FileInfo(toBagmanCounter).Length > 0)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(u.ShortUser + "|" + u.ShortUserFriend);
                }
            }
        }
        

        public static void writeToBirthdays(string path)
        {
           
                if (new FileInfo(path).Length == 0)
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(path))
                    {
                        file.WriteLine("b1|smardalo|diansica|25/01|Color pen,Paintings,Ink");
                        file.WriteLine("b2|ioneicut|smardalo|25/05|Cactus,Butterflies,Puzzle");
                        file.WriteLine("b3|igheorgh|ioneicut|25/11|Origami,Spaceships,Travel Books");
                        file.WriteLine("b4|rstefane|andbarac|25/01|Hiking,Bycicles,Guitar");
                        file.WriteLine("b5|dpopescu|acioroiu|25/04|Sun glasses,Keyboards,Piano");
                        file.WriteLine("b6|diansica|taflorea|25/03|Guitar,Animals,Books");
                        file.WriteLine("b7|acioroiu|andpavel|25/05|Cars,Metal,Hiking");
                        file.WriteLine("b8|taflorea|alealexe|25/06|Rap,Flowers,Flies");
                        file.WriteLine("b9|mihratoi|ioneicut|25/07|Painting,Bycicling,Theatre");
                        file.WriteLine("b10|alealexe|rstefane|25/08|Sailing,Wine tasting,Gaming");
                }
            }
        }

        public static void writeToBirthdayCustom(string path, Birthday b)
        {
            using (System.IO.StreamWriter file =
                     new System.IO.StreamWriter(path, true))
            {
                if(new FileInfo(toBirthdayCounter).Length > 0)
                {
                    using (System.IO.StreamReader reader =
                     new System.IO.StreamReader(toBirthdayCounter, true))
                    {
                        birthdayInc = Int32.Parse(reader.ReadLine()) + 1;
                    }
                }
                file.WriteLine("b" + birthdayInc + "|" + b.ShortUser + "|" + b.DateOfBirth + "|" + b.Suggestion);
                writeCounter(toBirthdayCounter, birthdayInc);
            }
        }
    
        #endregion
        
        #region ReadFunctions
        
        static Person ReadUserFromUsers(string ShortName)
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsers))
            {
                string line;
                string[] tokens = null;
                while((line = file.ReadLine()) != null)
                {
                    if (line.Contains(ShortName))
                    {
                        tokens = line.Split('|');
                        break;
                    }
                }

                if (tokens == null)
                   throw new Exception("User not found");
                return new Person(tokens[0], tokens[1], tokens[2], tokens[3]);
            }

        }

        static List<Person> ReadAllUsersFromUsers()
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsers))
            {
                string line;
                string[] tokens = null;
                List<Person> list = new List<Person>();
                while ((line = file.ReadLine()) != null)
                {
                    tokens = line.Split('|');
                    list.Add(new Person(tokens[0], tokens[1], tokens[2], tokens[3]));
                }

                if (tokens == null)
                    throw new Exception("No user registered");
                return list;
            }
        }

        static Birthday ReadBirthdayFromBirthdays(string ShortName)
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toBirthdays))
            {
                string line;
                string[] tokens = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(ShortName))
                    {
                        tokens = line.Split('|');
                        break;
                    }
                }

                if (tokens == null)
                    throw new Exception("Birthday not found for searched user");
                return new Birthday(tokens[1], tokens[2], tokens[3], tokens[4]);
            }
        }

        static List<Birthday> ReadAllBirthdaysFromBirthdays()
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsers))
            {
                string line;
                string[] tokens = null;
                List<Birthday> list = new List<Birthday>();
                while ((line = file.ReadLine()) != null)
                {
                    tokens = line.Split('|');
                    list.Add(new Birthday(tokens[1], tokens[2], tokens[3], tokens[4]));
                }

                if (tokens == null)
                    throw new Exception("No birthday registered");
                return list;
            }
        }
        
        static UserFriend ReadUserFriendFromUserFriends(string ShortName)
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsersFriends))
            {
                string line;
                string[] tokens = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(ShortName))
                    {
                        tokens = line.Split('|');
                        break;
                    }
                }

                if (tokens == null)
                    throw new Exception("Bagman not found for searched user");
                return new UserFriend(tokens[0], tokens[1]);
            }
        }

        static List<UserFriend> ReadAllBagmenFromUserFriends(string ShortName = "")
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsers))
            {
                string line;
                string[] tokens = null;
                List<UserFriend> list = new List<UserFriend>();
                while ((line = file.ReadLine()) != null)
                {
                    if (ShortName.Length > 0 && tokens[0] == ShortName)
                    {
                        tokens = line.Split('|');
                        list.Add(new UserFriend(tokens[0], tokens[1]));
                    }
                }

                if (tokens == null)
                    throw new Exception("No bagman registered");
                return list;
            }
        }

        static Contribution ReadContributionFromContributions(string ShortName)
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsersFriends))
            {
                string line;
                string[] tokens = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(ShortName))
                    {
                        tokens = line.Split('|');
                        break;
                    }
                }

                if (tokens == null)
                    throw new Exception("Contribution not found for searched user");
                return new Contribution(tokens[1], tokens[2], tokens[3]);
            }
        }

        static List<Contribution> ReadAllContributionsFromContributions(string ShortName = "")
        {
            using (System.IO.StreamReader file =
                     new System.IO.StreamReader(toUsers))
            {
                string line;
                string[] tokens = null;
                List<Contribution> list = new List<Contribution>();
                while ((line = file.ReadLine()) != null)
                {
                    if (ShortName.Length > 0 && tokens[1] == ShortName)
                    {
                        tokens = line.Split('|');
                        list.Add(new Contribution(tokens[1], tokens[2], tokens[3]));
                    }
                }

                if (tokens == null)
                    throw new Exception("No bagman registered");
                return list;
            }
        }

        #endregion
    }
}
