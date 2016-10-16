using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class UserManager
    {
        private User _user;
        private DAL d = new DAL(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        private const string userTable = "GameUser";
        private const string infoTable = "UserInfo";
        private const string satisfactionTable = "UserSatisfaction";

        public UserManager(User user)
        {
            _user = user;
        }

        public bool CheckIfUserExists()
        {
            string query = "Select Assignment_Id from " + userTable + " Where UserId='" + _user.user_id + "'";
            List<DALTypes> columns = new List<DALTypes>();
            columns.Add(DALTypes.String);
            columns.Add(DALTypes.String);
            columns.Add(DALTypes.String);
            var result = d.ReadData(query, columns.ToArray());

            return result != null;
        }

        public void addUserToDB()
        {
            List<List<DALType>> data = new List<List<DALType>>();
            List<DALType> userData = new List<DALType>();

            userData.Add(new DALString(_user.user_id));
            userData.Add(new DALString(_user.turkAss));
            userData.Add(new DALString(DateTime.UtcNow.ToString()));
            data.Add(userData);

            d.writeData(userTable, data);

        }

        public void saveUserInfo(UserInfo info)
        {
            _user.addUserInfo(info);

            List<DALType> infoData = new List<DALType>();
            infoData.Add(new DALString(_user.user_id));
            infoData.Add(new DALString(info.Gender));
            infoData.Add(new DALString(info.Age));
            infoData.Add(new DALString(info.Education));
            infoData.Add(new DALString(info.Nationality));
            infoData.Add(new DALString(info.Reason));
            infoData.Add(new DALString(info.Mobile));

            List<List<DALType>> data = new List<List<DALType>>();
            data.Add(infoData);
            d.writeData(infoTable, data);
        }

        public void saceUserSatisfaction(UserSatisfaction s)
        {
            List<DALType> infoData = new List<DALType>();
            infoData.Add(new DALString(_user.user_id));
            infoData.Add(new DALString(s.GeneralSatisfication));
            infoData.Add(new DALString(s.AgentSatisfaction));
            infoData.Add(new DALString(s.Payment));
            infoData.Add(new DALString(s.ParticipateAgain));
            infoData.Add(new DALString(s.Comments));

            List<List<DALType>> data = new List<List<DALType>>();
            data.Add(infoData);
            d.writeData(satisfactionTable, data);
        }
    }
}