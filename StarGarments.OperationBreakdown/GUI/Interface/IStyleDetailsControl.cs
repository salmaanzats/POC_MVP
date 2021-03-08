using Stargarments.Domain.Entities.OperationBreakDown;
using System;

namespace StarGarments.OperationBreakdown.GUI.Interface
{
    public interface IStyleDetailsControl
    {
        public event EventHandler OnLoadEvent;
        void AddStylesToDataGrid(SMVBreakDownVersion item);
    }
}
