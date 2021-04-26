using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface ILoginRepository
    {
        ResponseBase GetLogin(EntityLogin login);
    }
}
