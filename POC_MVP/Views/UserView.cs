using POC_MVP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POC_MVP.Views
{
    public partial class UserView : UserControl, IUserView
    {
        public UserView()
        {
            InitializeComponent();
        }

        public ICollection SelectedList
        {
            get
            {
                return userListView.Items;
            }
        }

        public event EventHandler SelectionChanged;

        public void AddItem(UserModel item)
        {
            userListView.Items.Add(item.FirstName + " " + item.LastName);
        }

        public void RemoveItem(string key)
        {
            throw new NotImplementedException();
        }

        public void SelectItem(string key)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
