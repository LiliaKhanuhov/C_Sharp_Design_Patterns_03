namespace A15_Ex03
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using FacebookWrapper.ObjectModel;
    using FacebookWrapper;
    using System.Data;

    public class LogicApp
    {
        private List<User> m_listFriends = new List<User>();
        private static LogicApp s_LogicApp;
        private static bool s_Created = false;

        private LogicApp()
        {
            s_LogicApp = this;
            s_Created = true;
        }

        public static LogicApp getLogicApp()
        {
            if (!s_Created)
            {
                s_LogicApp = new LogicApp();
            }

            return s_LogicApp;
        }

        public void fetchFriends(User i_logInUser)
        {
            if (m_listFriends != null)
            {
                m_listFriends.Clear();
            }

            foreach (User friend in i_logInUser.Friends)
            {
                DateTime dt;
                dt = Convert.ToDateTime(friend.Birthday);
                dt.AddYears(18);
                dt.CompareTo(DateTime.Now);
                if (dt.CompareTo(DateTime.Now) <= 0)
                {
                    m_listFriends.Add(friend);
                }
            }
        }

        public List<User> getListOfFriends()
        {
            return m_listFriends;
        }
    }
}

