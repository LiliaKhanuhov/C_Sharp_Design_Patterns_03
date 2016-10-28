using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace A15_Ex03
{
    class SimpleCalculationStrategy : IStrategy
    {
        public override float RatioOfBoysFromTotal(User i_LoggedInUser, LogicApp i_logicApp)
        {
            int counterBoys = 0;
            int counterGirls = 0;

            String userGender = UsefulMethods.getGender(i_LoggedInUser);

            foreach (User friend in i_logicApp.getListOfFriends())
            {
                String friendGender = UsefulMethods.getGender(friend);

                if (friendGender == "female")
                {
                    counterGirls += 1;
                }
                else
                {
                    counterBoys += 1;
                }
            }

            float result = counterBoys / i_LoggedInUser.Friends.Count;

            return result;
        }
    }
}
