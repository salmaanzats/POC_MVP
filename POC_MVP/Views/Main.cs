using POC_MVP.Views;
using System.Windows.Forms;

namespace POC_MVP
{
    public partial class Main : Form, IMain
    {
        public Main(Control userControl)
        {
            InitializeComponent();
            userControl.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(userControl);
        }
    }
}
