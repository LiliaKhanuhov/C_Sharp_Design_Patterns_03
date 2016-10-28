using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace A15_Ex03
{
     public class AccurateCalculationStrategy : IStrategy
    {
         public override float RatioOfBoysFromTotal(User i_LoggedInUser, LogicApp i_logicApp)
        {
            int counterBoys = 0;
            int counterGirls = 0;

            String userGender = UsefulMethods.getGender(i_LoggedInUser);

            foreach (User friend in i_logicApp.getListOfFriends())
            {
                String m_friendGender = UsefulMethods.getGender(friend);
                String m_UserRelationshipStatus = UsefulMethods.getRelationshipStatus(friend);

                if (m_friendGender == "female" && !(m_UserRelationshipStatus.Equals("Married") || m_UserRelationshipStatus.Equals("In a relationship")))
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

