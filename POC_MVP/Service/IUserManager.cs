using POC_MVP.Model;
using System.Collections.Generic;

namespace POC_MVP.BusinessLogic
{
    public interface IUserManager
    {
        IEnumerable<UserModel> Users { get; }
    }
}
