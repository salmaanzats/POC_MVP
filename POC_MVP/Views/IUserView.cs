using POC_MVP.Model;
using System;
using System.Collections;

namespace POC_MVP.Views
{
    public interface IUserView
    {
        ICollection SelectedList { get; }

        void AddItem(UserModel item);
        void RemoveItem(string key);
        void SelectItem(string key);

        event EventHandler SelectionChanged;
    }
}
