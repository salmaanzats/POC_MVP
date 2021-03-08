using Stargarments.Domain.Entities.OperationBreakDown;
using StarGarments.OperationBreakdown.GUI.Interface;
using System;
using System.Windows.Forms;

namespace StarGarments.OperationBreakdown.GUI
{
    public partial class StyleDetailsControl : UserControl, IStyleDetailsControl
    {
        public StyleDetailsControl()
        {
            InitializeComponent();
            this.Load += (s, a) => OnLoad();
        }

        public event EventHandler OnLoadEvent;

        public void AddStylesToDataGrid(SMVBreakDownVersion item)
        {
            dataGridView1.DataSource = item;
        }

        protected virtual void OnLoad()
        {
            var handler = OnLoadEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
