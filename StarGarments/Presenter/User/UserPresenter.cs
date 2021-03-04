using StarGarments.GUI.Controls.Interface;
using StarGarments.Service.Service.User;
using StarGarments_POC.GUI.Controls.Interface;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace StarGarments.Presenter.User
{
    public class UserPresenter
    {
        public IUserList userListView;
        public IUser userView;
        private IUserService userService;
        //public MemoryCache cache;
        //public CacheItemPolicy policy;

        public UserPresenter(IUserList userListView, IUser userView)
        {
            //cache = MemoryCache.Default;
            //policy = new CacheItemPolicy();

            //policy.AbsoluteExpiration =
            //       DateTimeOffset.Now.AddSeconds(3600);

            this.userService = new UserService();
            this.userListView = userListView;
            this.userView = userView;

            userListView.Load += ViewOnLoad;
            userListView.DoubleClickEvent += OnDoubleClick;
            userView.OnUpdateClickEvent += OnUpdateClick;
            userView.OnCreateClickEvent += OnCreateClick;
            userView.OnSaveClickEvent += OnSaveClick;
            userView.OnDeleteClickEvent += OnDeleteClick;
        }

        public void AddUsersToListView(Stargarments.Domain.Entities.User user)
        {
            userListView.AddItem(user);
        }

        private async void ViewOnLoad(object sender, EventArgs eventArgs)
        {
            GetAllUsers();
        }

        private async void GetAllUsers()
        {
            //var userList = new List<Stargarments.Domain.Entities.User>();
            //userList = cache.Get("userList", null) as List<Stargarments.Domain.Entities.User>;
            //if (userList == null)
            //{

            //    userList = await this.userService.LoadUsersAsync();
            //    cache.Add("userList", userList, policy);
            //}

            var userList = await this.userService.LoadUsersAsync();
            await userListView.AddListDataSource(userList);
        }

        private async void OnDoubleClick(object sender, EventArgs eventArgs)
        {
            this.userView.PatchFormValues(userListView.SelectedItem);
        }

        private async void OnUpdateClick(object sender, EventArgs eventArgs)
        {
            await this.userService.UpdateUsersAsync(this.userView.GetUser);
            // MemoryCache.Default.Remove("userlist");
            GetAllUsers();
        }

        private async void OnCreateClick(object sender, EventArgs eventArgs)
        {
            userView.Clear();
        }

        private async void OnSaveClick(object sender, EventArgs eventArgs)
        {
            await this.userService.SaveUserAsync(this.userView.GetUser);
            GetAllUsers();
        }

        private async void OnDeleteClick(object sender, EventArgs eventArgs)
        {
            await this.userService.DeleteUserAsync(this.userView.GetUser.Id);
            userView.Clear();
            GetAllUsers();
        }
    }
}
