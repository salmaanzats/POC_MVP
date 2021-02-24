using StarGarments.Service.Service.User;
using StarGarments_POC.GUI.Controls.Interface;
using System;
using System.Windows.Forms;

namespace StarGarments.Presenter.User
{
    public class UserPresenter
    {
        public IUserList userView;
        private IUserService userService;

        public UserPresenter(IUserList userView)
        {
            this.userView = userView;
            this.userService = new UserService();
            userView.Load += ViewOnLoad;
            userView.DoubleClickEvent += OnDoubleClick;
        }

        public void AddUsersToListView(POC.Domain.Entitities.User user)
        {
            userView.AddItem(user);
        }

        private async void ViewOnLoad(object sender, EventArgs eventArgs)
        {
            await userView.AddListDataSource(await this.userService.LoadUsersAsync());
        }

        private async void OnDoubleClick(object sender, EventArgs eventArgs)
        {
            var ss = userView.SelectedItem;
            MessageBox.Show(ss.FirstName, ss.LastName);
        }
    }
}
