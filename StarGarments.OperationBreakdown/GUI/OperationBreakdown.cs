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
        public delegate void InvokeDelegate();
        public delegate void InvokeStyleDelegate();
        List<GarmentTypeModel> GarmentTypes = new List<GarmentTypeModel>();
        List<StyleModel> Styles = new List<StyleModel>();

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
            GarmentTypes = Item;
            cmbGarment_Type.BeginInvoke(new InvokeDelegate(InvokeMethod));
        }

        public void InvokeMethod()
        {
            cmbGarment_Type.DataSource = GarmentTypes;
            cmbGarment_Type.DisplayMember = "GarmentType";
            cmbGarment_Type.ValueMember = "GarmentTypeId";
        }

        public void AddStylesToDataSource(List<StyleModel> Item)
        {
            Styles = Item;
            cmbStyle.BeginInvoke(new InvokeStyleDelegate(InvokeStyleMethod));
        }

        public void InvokeStyleMethod()
        {
            cmbStyle.DataSource = Styles;
            cmbStyle.DisplayMember = "StyleNumber";
            cmbStyle.ValueMember = "StyleNumber";
        }
    }
}
