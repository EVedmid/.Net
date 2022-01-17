using BLL.DTO;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controller.Commands.Post
{
    public class MakePost : ACommand
    {
        private readonly IPostService _postService;
        
        public MakePost(IGuestService guestService, IPostService postService) : base (guestService)
        {
            _postService = postService;
        }

        public override void Execute()
        {
            try
            {
                var guest = Authorize();

                Console.WriteLine("Enter news header:");
                string header = Console.ReadLine();
                Console.WriteLine("Enter news body:");
                string body = Console.ReadLine();
                Console.WriteLine("Enter news tags:");
                string tags = Console.ReadLine();
                Console.WriteLine("Enter news rubric:");
                string rubric = Console.ReadLine();
                Console.WriteLine("Enter new topic:");
                string topic = Console.ReadLine();
                DateTime time = DateTime.Now.Date;

                var post = new PostDto
                {
                    guestLogin = guest.Login,
                    DateTime = time,
                    NewsHeader = header,
                    NewsBody = body,
                    Tags = tags,
                    Topic = topic,
                    Rubric = rubric
                };

                _postService.PostNews(time,post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
