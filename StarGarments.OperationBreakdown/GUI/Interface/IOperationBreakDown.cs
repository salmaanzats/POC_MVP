using Stargarments.Domain.Entities.OperationBreakDown;
using System;
using System.Collections.Generic;

namespace StarGarments.OperationBreakdown.GUI.Interface
{
    public interface IOperationBreakDown
    {
        public event EventHandler OnLoadEvent;
        void AddGarmentTypesToDataSource(List<GarmentTypeModel> item);
        void AddStylesToDataSource(List<StyleModel> item);
    }
}
