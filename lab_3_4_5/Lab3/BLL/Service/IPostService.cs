using System;
using System.Collections.Generic;
using BLL.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Service
{
    public interface IPostService {
        void PostNews(DateTime postTime, PostDto postDto);
        PostDto FindById(int id);
        IEnumerable<PostDto> GetAll();
        bool Exists(int id);
        IEnumerable<PostDto> FindByHeader(string header);
        IEnumerable<PostDto> FindByGuest(string login);
        void Delete(int id);
    }
}
