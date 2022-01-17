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
    public class GuestPagesController : Controller
    {
        private readonly IPostService postService = DependencyProvider.GetDependency<IPostService>();
        private readonly IGuestService guestService = DependencyProvider.GetDependency<IGuestService>();

        [HttpGet]
        public ActionResult GoToIndex(string _guestVM)
        {
            var posts = new MapperConfiguration(cfg => cfg.CreateMap<PostDto, PostVM>()).CreateMapper();
            var q = posts.Map<IEnumerable<PostDto>, List<PostVM>>(postService.FindByGuest(_guestVM));
            return View("Index", q);
        }

        [HttpGet]
        public ActionResult MakePost()
        {
            return RedirectToRoute(new { controller = "Post", action = "MakePost" });
        }

        [HttpGet]
        public ActionResult BackToMain()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
