using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Service;
using BLL.Provider;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService = DependencyProvider.GetDependency<IPostService>();

        [HttpGet]
        public ActionResult MakePost()
        {
            return View("MakePost");
        }

        [HttpGet]
        public ActionResult SearchPost()
        {
            return View();
        }

        [HttpPost]
        public string MakePost(PostVM postVM)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostVM, PostDto>()).CreateMapper();
            var post = mapper.Map<PostVM, PostDto>(postVM);
            postService.PostNews(DateTime.Now, post);
            return "News posted";
        }

        [HttpPost]
        public ActionResult SearchPost(PostVM postVM)
        {
            var posts = new MapperConfiguration(cfg => cfg.CreateMap<PostDto, PostVM>()).CreateMapper();
            var q = posts.Map<IEnumerable<PostDto>, List<PostVM>>(postService.FindByHeader(postVM.NewsHeader));
            return View("SearchByHeader",q);
        }
    }
}
