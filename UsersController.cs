using Microsoft.AspNetCore.Mvc;
using plumcourse.Data.Interfaces;
using plumcourse.Data.Models;


namespace plumcourse.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsers _users;
        //private readonly ICourses _courses;
        public UsersController(IUsers iusers)
        {
            _users = iusers;
        }   
        [HttpGet]
        public IEnumerable<User> List()
        {
            var users = _users.AllUsers;
            return users;
        }
        [HttpPost]
        public void Create([FromBody] User item)
        {
            _users.Add(item);

        }
    }
}
