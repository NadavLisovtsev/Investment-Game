using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class QuizManager
    {
        private List<int> _answers = new List<int>();
        private User _user;
        private const string tableName = "QuizInfo";
        private DAL dal = new DAL(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        public int triesCount {get; private set;}

        public QuizManager(User user)
        {
            _answers.Add(3);
            _answers.Add(2);
            _answers.Add(3);

            triesCount = 1;
            _user = user;
        }

        public bool checkAnswers(List<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if(a[i] != _answers[i])
                    return false;
            }
            return true;
        }

        public void incrementTriesCount()
        {
            triesCount++;
        }

        public void saveTriesCountToDB()
        {
            List<DALType> row = new List<DALType>();

            row.Add(new DALString(_user.user_id));
            row.Add(new DALInt(triesCount));

            List<List<DALType>> values = new List<List<DALType>>();
            values.Add(row);

            dal.writeData(tableName, values);
        }
    }
}