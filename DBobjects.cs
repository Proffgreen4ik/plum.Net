using plumcourse.Data.Models;

namespace plumcourse.Data
{
    public class DBobjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.User.Any())
            {
                content.User.AddRange(Users.Select(c => c.Value));
            }
            content.SaveChanges();
               
        }
        private static Dictionary<string, User> user;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (user == null)
                {
                    var list = new User[]
                    {
                        new User {name="Миша",surname="Акимов"},
                        new User {name="Дима",surname="Барсуков"}
                    };
                    user = new Dictionary<string, User>();
                    foreach (User el in list)
                    {
                        user.Add(el.name,el);
                    }
                }
                return user;
            }
        }
    }
}
