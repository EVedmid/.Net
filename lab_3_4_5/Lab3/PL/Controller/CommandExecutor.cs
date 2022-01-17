using BLL.Provider;
using BLL.Service;
using PL.Controller.Commands.Guest;
using PL.Controller.Commands.Post;
using System;
using System.Collections.Generic;

namespace PL.Controller
{
    public static class CommandExecutor
    {
        private static Dictionary<string, ACommand> Commands { get; set; }

        private static readonly IGuestService GuestService = DependencyProvider.GetDependency<IGuestService>();

        private static readonly IPostService PostService = DependencyProvider.GetDependency<IPostService>();

        public static void Execute()
        {
            Init();
            while (true)
            {
                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Commands:\n" +
                    "1 - Sign up\n" +
                    "2 - Make post\n" +
                    "3 - Get all guests\n" +
                    "4 - Get all posts\n" +
                    "5 - Find by guest\n" +
                    "6 - Find by rubric\n" +
                    "7 - Find by time\n" +
                    "8 - Find by topic\n" +
                    "9 - Find by tags\n" +
                    "10 - Delete guest\n" +
                    "11 - Delete guest\n" +
                    "Exit");
                Console.Write("Enter a command number or exit: ");
                var command = Console.ReadLine();
                if (command == null)
                {
                    Console.WriteLine("Please, enter a command number or exit");
                    continue;
                }

                if (command == "exit")
                {
                    break;
                }

                if (!Commands.ContainsKey(command))
                {
                    Console.WriteLine("Wrong command number!");
                }
                else
                {
                    Commands[command].Execute();
                }
            }
        }

        private static void Init()
        {
            Commands = new Dictionary<string, ACommand>
            {
                {"1",new SignUpCommand(GuestService)},
                {"2",new MakePost(GuestService,PostService)},
                {"3",new GetAllGuests(GuestService)},
                {"4",new GetAllPosts(GuestService,PostService)},
                {"5",new FindByGuest(GuestService,PostService)},
                {"6",new FindByRubric(GuestService,PostService)},
                {"7",new FindByTime(GuestService,PostService)},
                {"8",new FindByTopic(GuestService,PostService)},
                {"9",new FindByTags(GuestService,PostService)},
                {"10",new DeleteGuest(GuestService)},
                {"11",new DeletePost(GuestService, PostService)},
            };
        }
    }
}
