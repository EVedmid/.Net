using BLL.Service;
using BLL.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controller.Commands.Post
{
    public class FindByRubric : ACommand
    {
        private readonly IPostService _postService;

        public FindByRubric(IGuestService guestService, IPostService postService) : base(guestService)
        {
            _postService = postService;
        }

        public override void Execute()
        {
            try
            {
                Authorize();

                Console.Write("Enter rubric: ");
                string rubric = Console.ReadLine();

                var posts = _postService.GetAll().Where(post => post.Rubric == rubric)
                    .Select(post => post);

                if (posts == null)
                {
                    Console.WriteLine("0 posts was found");
                }
                else
                {
                    int count = 0;
                    foreach (var x in posts)
                    {
                        Console.WriteLine($"News number {count + 1}");
                        Console.WriteLine($"Author {x.guestLogin} Time {x.DateTime}");
                        Console.WriteLine($"Tags: {x.Tags}\nTopic: {x.Topic}\nRubric: {x.Rubric}");
                        Console.WriteLine($"Header {x.NewsHeader}\nText:\n{x.NewsBody}");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
