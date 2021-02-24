using StarGarments.GUI.Controls;
using StarGarments_POC.GUI.Controls;
using System.Windows.Forms;

namespace StarGarments_POC.GUI.Main
{
    public partial class Frm_Main : Form
    {
        Ctrl_User userView;
        public Frm_Main()
        {
            InitializeComponent();
            Ctrl_UserList userListView = new Ctrl_UserList();
            userView = new Ctrl_User();
            userView.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(userListView);
        }

        public void ShowUserView()
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(userView);
        }
    }
}
