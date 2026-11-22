using DAL;

namespace BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool CheckLogin(string username, string password)
        {
            return _userRepository.CheckLogin(username, password);
        }
    }
}