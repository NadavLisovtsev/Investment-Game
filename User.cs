using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class User
    {
        public String user_id;
        public String turkAss;
        public String hitId;

        private UserInfo _info;

        public User(String userID,String ass,String hitid)
        {
            user_id = userID;
            turkAss = ass;
            hitId = hitid;
        }

        public void addUserInfo(UserInfo u)
        {
            _info = u;
        }
    }
}