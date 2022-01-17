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
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace WebApplication2.Controllers
{
    [EnableCors("AnotherPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService = DependencyProvider.GetDependency<IPostService>();

        [HttpGet]
        public ActionResult Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostDto, PostVm>()).CreateMapper();
            var list = mapper.Map<IEnumerable<PostDto>, List<PostVm>>(postService.GetAll());
            if (!list.Any()) return NotFound();
            return Ok(list);
        }

        // GET <controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostDto, PostVm>()).CreateMapper();
            var user = mapper.Map<PostDto, PostVm>(postService.FindById(id));
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] PostVm postVm)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PostVm, PostDto>()).CreateMapper();
            var user = mapper.Map<PostVm, PostDto>(postVm);
            try
            {
                postService.PostNews(DateTime.Now,user);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE <controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                postService.Delete(id);
                return Ok(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
