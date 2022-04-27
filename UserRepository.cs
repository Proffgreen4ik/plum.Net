using plumcourse.Data.Interfaces;
using plumcourse.Data.Models;

namespace plumcourse.Data.Repository
{
    public class UserRepository : IUsers
    {
        private readonly AppDBContent appDBContent;
        public UserRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<User> AllUsers => appDBContent.User;

        public void Add(User item)
        {
            appDBContent.Add(item);
            appDBContent.SaveChanges();
        }
    }
}
