using StarGarments.OperationBreakdown.GUI.Interface;
using StarGarments.Service.Service.OperationBreakdown;
using System;

namespace StarGarments.OperationBreakdown.Presenter
{
    public class OperationBreakDownPresenter
    {
        private IOperationBreakDown operationView;
        private IOperationBreakdownService operationBreakdownService;
     
        public OperationBreakDownPresenter(IOperationBreakDown operationView)
        {
            this.operationBreakdownService = new OperationBreakDownService();
            this.operationView = operationView;

            operationView.OnLoadEvent += onLoad;
        }

        private async void onLoad(object sender, EventArgs eventArgs)
        {
            GetStyles();
            GetAllGarmentTypes();
        }

        private async void GetStyles()
        {
            var styles = await this.operationBreakdownService.LoadStylesAsync();
            operationView.AddStylesToDataSource(styles);
        }

        private async void GetAllGarmentTypes()
        {
            var garmentTypes = await this.operationBreakdownService.LoadGarmentTypesAsync();
            operationView.AddGarmentTypesToDataSource(garmentTypes);
        }
    }
}
