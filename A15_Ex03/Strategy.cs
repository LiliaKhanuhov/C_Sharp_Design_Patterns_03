using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace A15_Ex03
{

    public abstract class IStrategy
    {
        public abstract float RatioOfBoysFromTotal(User i_LoggedInUser, LogicApp i_logicApp);
    }
}
