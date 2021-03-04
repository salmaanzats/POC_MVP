using Stargarments.Domain.Entities.OperationBreakDown;
using StarGarments.OperationBreakdown.GUI.Interface;
using StarGarments.OperationBreakdown.Presenter;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarGarments.OperationBreakdown.GUI
{
    public partial class OperationBreakdownForm : Form, IOperationBreakDown
    {
        public OperationBreakdownForm()
        {
            InitializeComponent();
            Tag = new OperationBreakDownPresenter(this);
            this.Load += (s, a) => OnLoad();
        }

        public event EventHandler OnLoadEvent;
        protected virtual void OnLoad()
        {
            var handler = OnLoadEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void AddGarmentTypesToDataSource(List<GarmentTypeModel> Item)
        {
            cmbGarment_Type.DataSource = Item;
            cmbGarment_Type.DisplayMember = "GarmentType";
            cmbGarment_Type.ValueMember = "GarmentTypeId";
        }

        public void AddStylesToDataSource(List<StyleModel> Item)
        {
            cmbStyle.DataSource = Item;
            cmbStyle.DisplayMember = "StyleNumber";
            cmbStyle.ValueMember = "StyleNumber";
        }
    }
}
