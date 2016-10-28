using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace A15_Ex03
{
    class UsefulMethods
    {
        public static String getGender(User i_User)
        {
            return i_User.Gender.ToString();
        }

        public static String getRelationshipStatus(User i_User)
        {
            return i_User.RelationshipStatus.ToString();
        }
    }
}
