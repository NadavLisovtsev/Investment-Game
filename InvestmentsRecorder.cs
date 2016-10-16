using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class InvestmentsRecorder
    {
        private const string investmentsTable = "UserInvestments";
        private DAL dal = new DAL(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        private User _user;

        public InvestmentsRecorder( User u)
        {
            _user = u;
        }

        public void RecordInvestment(InvestmentData data, double beforeMoney, double AfterMoney, int roundNum, int scernarioNum, int stockId, bool isTrain)
        {
            int isGain = 0;
            int training = 0;

            if(data.earn > 0)
            {
                isGain = 1;
            }
            else if(data.earn < 0)
            {
                isGain = -1;
            }
            
            training = isTrain ? 1 : 0;

            
            List<DALType> record = new List<DALType>(); 
            record.Add(new DALString(_user.user_id));
            record.Add(new DALInt(roundNum));
            record.Add(new DALInt(scernarioNum));
            record.Add(new DALInt(stockId));
            record.Add(new DALDouble(beforeMoney));
            record.Add(new DALDouble(data.investmentMoney));
            record.Add(new DALDouble(data.earn * 100));
            record.Add(new DALDouble(data.earnMoney));
            record.Add(new DALDouble(data.commission_percent));
            record.Add(new DALDouble(data.commission));
            record.Add(new DALDouble(data.endMoney));
            record.Add(new DALDouble(AfterMoney));
            record.Add(new DALInt(isGain));
            record.Add(new DALInt(training));
            record.Add(new DALString(DateTime.UtcNow.ToString()));

            List<List<DALType>> records = new List<List<DALType>>();
            records.Add(record);

            dal.writeData(investmentsTable, records);
        }
    }
}