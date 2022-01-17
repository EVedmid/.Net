using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Provider;
using BLL.Service;
using WebApplication2.Models;
using AutoMapper;
using System.Net.Http;
using System.Web;
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace WebApplication2.Controllers
{
    [EnableCors("AnotherPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService guestService = DependencyProvider.GetDependency<IGuestService>();
        private readonly IPostService postService = DependencyProvider.GetDependency<IPostService>();

        [HttpGet]
        public IEnumerable<GuestVm> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestDto, GuestVm>()).CreateMapper();
            var list = mapper.Map<IEnumerable<GuestDto>, List<GuestVm>>(guestService.GetAll());
            return list;
        }

        [HttpGet("{login}")]
        public GuestVm Get(string login)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestDto, GuestVm>()).CreateMapper();
            var user = mapper.Map<GuestDto, GuestVm>(guestService.FindByLogin_(login));
            if (user == null) throw new ArgumentException(new string("login error"));
            return user;
        }

        [HttpPost]
        public HttpResponseMessage Post ([FromBody] GuestVm guestVm)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestVm, GuestDto>()).CreateMapper();
            var user = mapper.Map<GuestVm, GuestDto>(guestVm);
            try
            {
                guestService.SignUp(user);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete("{login}")]
        public HttpResponseMessage Delete(string login)
        {
            try
            {
                guestService.Delete_(login);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
