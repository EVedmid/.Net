using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using WebApplication1.Models;
using BLL.Service;
using BLL.Provider;

namespace WebApplication1.Controllers
{
    public class ManagerPagesController : Controller
    {
        private readonly IPostService postService = DependencyProvider.GetDependency<IPostService>();
        private readonly IGuestService guestService = DependencyProvider.GetDependency<IGuestService>();

        [HttpGet]
        public ActionResult Index()
        {
            var posts = new MapperConfiguration(cfg => cfg.CreateMap<PostDto, PostVM>()).CreateMapper();
            var q = posts.Map<IEnumerable<PostDto>, List<PostVM>>(postService.GetAll());
            return View(q);
        }

        [HttpGet]
        public ActionResult AllUsers()
        {
            var users = new MapperConfiguration(cfg => cfg.CreateMap<GuestDto, GuestVM>()).CreateMapper();
            var q = users.Map<IEnumerable<GuestDto>, List<GuestVM>>(guestService.GetAll());
            return View(q);
        }

        [HttpGet]
        public string DeletePosts(int id)
        {
            postService.Delete(id);
            return "Post deleted";
        }

        [HttpGet]
        public string DeleteUsers(string login)
        {
            guestService.Delete(guestService.FindByLogin_(login));
            return "User deleted";
        }

        [HttpGet]
        public ActionResult MakePost()
        {
            return RedirectToRoute(new { controller = "Post", action = "MakePost" });
        }

        [HttpGet]
        public ActionResult GoToSearchPage()
        {
            return RedirectToRoute(new { controller = "Post", action = "SearchPost" });
        }
    }
}
