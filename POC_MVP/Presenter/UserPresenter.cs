using POC_MVP.Events;
using POC_MVP.Model;
using POC_MVP.Views;

namespace POC_MVP.Presenter
{
    class UserPresenter
    {
        public IUserView userView;

        public UserPresenter(IUserView userView)
        {
            this.userView = userView;
            EventAggregator.Instance.Subscribe<UserLoadedMessage>(m => AddUsersToListView(m.User));
        }

        public void AddUsersToListView(UserModel user)
        {
            userView.AddItem(user);
        }
    }
}
