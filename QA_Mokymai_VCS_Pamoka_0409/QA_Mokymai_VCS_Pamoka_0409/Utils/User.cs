
namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class User
    {
        public static User DefaultKikaUser = new User("testeris888@test.lt", "testeris888");
        
        public string Username;
        public string Password;

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
