using POC_MVP.Model;

namespace POC_MVP.Events
{
    class UserLoadedMessage : IApplicationEvent
    {
        public UserModel User { get; private set; }

        public UserLoadedMessage(UserModel user)
        {
            User = user;
        }
    }
}
