using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using BLL.Service;
using BLL.Provider;
using BLL.DTO;
using AutoMapper;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
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
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(GuestVM guestVM)
        {
            if(guestVM.Login == null || guestVM.PasswordHash == null || guestVM.Role == null)
            {
                return View("Error");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestVM, GuestDto>()).CreateMapper();
            var guestDto = mapper.Map<GuestVM, GuestDto>(guestVM);
            try
            {
                guestService.SignUp(guestDto);
            }
            catch(Exception)
            {
                if (guestService.FindByLogin(guestDto.Login).GuestRole=="Manager") return RedirectToRoute(new { controller = "ManagerPages", action = "Index" });
                else return RedirectToAction("GoToIndex","GuestPages",new { _guestVM = guestVM.Login });
            }
            return Redirect("Index");
        }
    }
}
