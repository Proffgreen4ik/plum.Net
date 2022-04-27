using plumcourse.Data.Models;

namespace plumcourse.Data.Interfaces
{
    public interface IUsers
    {
        IEnumerable<User> AllUsers { get; }
        void Add(User user);
    }
    
}
