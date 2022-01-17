using DAL.Entity;
using DAL.Repository;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Service.Implementation
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void PostNews(DateTime postTime, PostDto postDto)
        {
            var post = new Post()
            {
                NewsHeader = postDto.NewsHeader,
                NewsBody = postDto.NewsBody,
                Rubric = postDto.Rubric,
                Tags = postDto.Tags,
                Topic = postDto.Topic,
                guestLogin = postDto.guestLogin,
                DateTime = postTime
            };

            _unitOfWork.Posts.Create(post);
            _unitOfWork.Save();
        }

        public bool Exists(int id)
        {
            return FindById(id) != null;
        }

        public PostDto FindById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostDto>()).CreateMapper();
            return mapper.Map<Post, PostDto>(_unitOfWork.Posts.FindById(id));
        }

        public IEnumerable<PostDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Post>, List<PostDto>>(_unitOfWork.Posts.FindAll());
        }

        public IEnumerable<PostDto> FindByHeader(string header)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Post>, List<PostDto>>(_unitOfWork.Posts.FindByPredicate((post => post.NewsHeader == header)));
        }

        public IEnumerable<PostDto> FindByGuest(string login)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Post>, List<PostDto>>(_unitOfWork.Posts.FindByPredicate((post => post.guestLogin == login)));
        }

        public void Delete(int id)
        {
            _unitOfWork.Posts.RemoveById(id);
        }
    }
}
