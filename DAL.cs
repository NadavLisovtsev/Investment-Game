using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class DAL
    {
        private string _connectionString;

        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }


        private string DALTypesToDBTypesString(DALTypes t)
        {
            if (t == DALTypes.Int)
            {
                return "int";
            }
            if (t == DALTypes.Double)
            {
                return "real";
            }
            if (t == DALTypes.String)
            {
                return "varchar(50)";
            }
            return "";
        }

        public void createTable(string tableName, Dictionary<string, DALTypes> columns)
        {

            List<string> queryList = new List<string>();
            foreach (KeyValuePair<string, DALTypes> column in columns)
            {
                queryList.Add(String.Format("{0} {1}", column.Key, DALTypesToDBTypesString(column.Value)));
            }
            string query = String.Format("create table {0} ({1})", tableName, String.Join(", ",queryList.ToArray()));

            using (SQLiteConnection sqlConnection =
                     new SQLiteConnection(_connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(query, sqlConnection);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public bool isTableEmpty(string tableName)
        {
            bool isEmpty = true;
            using (SQLiteConnection sqlConnection =
                       new SQLiteConnection(_connectionString))
            {
                
            /*    SqlCommand cmd2 = new SqlCommand("create table Scenarios (id int, turn int, stockId int, earning real)",sqlConnection);
                SqlCommand cmd3 = new SqlCommand("create table StocksNames (id int, name varchar(50))", sqlConnection);
                SqlCommand cmd1 = new SqlCommand("create table StocksEarnings (id int, earning real)", sqlConnection);

                SqlCommand cmd4 = new SqlCommand("create table GameUser (UserId varchar(100), Assignment_Id varchar(100), time varchar(100))", sqlConnection);
                SqlCommand cmd5 = new SqlCommand("create table UserInfo (UserId varchar(100), Gender varchar(100), Age varchar(100), Education varchar(100), Nationality varchar(100), Reason varchar(100), Mobile varchar(100))", sqlConnection);
                SqlCommand cmd6 = new SqlCommand("create table UserSatisfaction (UserId varchar(100), GeneralSatisfication varchar(100), AgentSatisfaction varchar(100), Payment varchar(100), ParticipateAgain varchar(100), Comments varchar(500))", sqlConnection);
                SqlCommand cmd7 = new SqlCommand("create table UserInvestments (UserId varchar(100), RoundNum int, ScenarioNum int, StockId int, money real, moneyInvested real, earnPercent real, earnMoney real, commissionPercent real, commissionMoney real, moneyGettedBack real, endMoney real, isGain int)", sqlConnection);

                SqlCommand d1 = new SqlCommand("delete from Scenarios", sqlConnection);
                SqlCommand d2 = new SqlCommand("delete from StocksNames", sqlConnection);
                SqlCommand d3 = new SqlCommand("delete from StocksEarnings", sqlConnection);

                SqlCommand d4 = new SqlCommand("delete from GameUser", sqlConnection);
                SqlCommand d5 = new SqlCommand("delete from UserInfo", sqlConnection);
                SqlCommand d6 = new SqlCommand("delete from UserInvestments", sqlConnection);
                SqlCommand d7 = new SqlCommand("delete from UserSatisfaction", sqlConnection);

                SqlCommand drp1 = new SqlCommand("drop table trace_xe_action_map",sqlConnection);
                SqlCommand drp2 = new SqlCommand("drop table trace_xe_event_map", sqlConnection);
                SqlCommand drp3 = new SqlCommand("drop table UserInfo", sqlConnection);
                SqlCommand drp4 = new SqlCommand("drop table UserSatisfaction", sqlConnection);
                SqlCommand drp5 = new SqlCommand("drop table Result", sqlConnection); */

                SQLiteCommand cmd = new SQLiteCommand(String.Format("Select count(*) From {0}", tableName), sqlConnection);

                sqlConnection.Open();

          //      drp1.ExecuteNonQuery();
          //      drp2.ExecuteNonQuery();
         //       drp3.ExecuteNonQuery();
         //       drp4.ExecuteNonQuery();
         //       drp5.ExecuteNonQuery();

             //   cmd7.ExecuteNonQuery();
             //   cmd6.ExecuteNonQuery();
              //  cmd4.ExecuteNonQuery();
              //  cmd5.ExecuteNonQuery();

              //  d1.ExecuteNonQuery();
             //   d2.ExecuteNonQuery();
             //   d3.ExecuteNonQuery();

             /*   d4.ExecuteNonQuery();
                d5.ExecuteNonQuery();
                d6.ExecuteNonQuery();
                d7.ExecuteNonQuery();*/

             //   cmd1.ExecuteNonQuery();
             //   cmd2.ExecuteNonQuery();
             //   cmd3.ExecuteNonQuery();
                
                long result = (long)cmd.ExecuteScalar();
                if (result > 0)
                {
                    isEmpty = false;
                }
                sqlConnection.Close();
            }
            return isEmpty;
        }

        public List<List<DALType>> ReadFullTable(string tableName, DALTypes[] columnTypesArray)
        {
            string query = String.Format("select * from {0}", tableName);
            return ReadData(query, columnTypesArray);
        }

        public List<List<DALType>> ReadData(string query, DALTypes[] columnTypesArray)
        {
            DataTable dt = ReadDataTableData(query);
            List<List<DALType>> data = dataTableToDalType(dt, columnTypesArray);
            
            if(data.Count == 0)
            {
                return null;
            }
            return data;
            
        }

        public void writeData(string tableName, List<List<DALType>> values)
        {
            

            List<string> valuesString = new List<string>();
            foreach(List<DALType> row in values) 
            {
                List<string> rowString  = new List<string>();
                foreach(DALType column in row)
                {
                    if(column.returnType() == DALTypes.String)
                    {
                        rowString.Add(String.Format("'{0}'", column.getData().ToString()));
                    }
                    else
                    {
                        rowString.Add(column.getData().ToString());
                    }
                }
                String rowQuery = String.Format("({0})", String.Join(",",rowString.ToArray()));
                valuesString.Add(rowQuery);
            }


            String valuesQuery;
            String query;
            while (valuesString.Count > 800)
            {
                valuesQuery = String.Join(",",valuesString.GetRange(0, 800).ToArray());
                query = String.Format("Insert into {0} VALUES {1}", tableName, valuesQuery);

                using (SQLiteConnection sqlConnection =
                      new SQLiteConnection(_connectionString))
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, sqlConnection);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                valuesString.RemoveRange(0, 800);

            }


            valuesQuery = String.Join(",",valuesString.ToArray());

            query = String.Format("Insert into {0} VALUES {1}", tableName, valuesQuery);

            using (SQLiteConnection sqlConnection =
                       new SQLiteConnection(_connectionString))
            {
                 SQLiteCommand cmd = new SQLiteCommand(query, sqlConnection);
                 sqlConnection.Open();
                 cmd.ExecuteNonQuery();
                 sqlConnection.Close();
            }
        }

        private DataTable ReadDataTableData(string query)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter;

            using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
       
        private List<List<DALType>> dataTableToDalType(DataTable dt, DALTypes[] columnsTypesArray)
        {
            int len = columnsTypesArray.Length;
            DALTypeFactory factory = new DALTypeFactory();
            List<List<DALType>> tableList = new List<List<DALType>>();
            foreach(DataRow dr in dt.Rows)
            {
                List<DALType> rowList = new List<DALType>();
                for(int i = 0; i < len; i++)
                {
                    rowList.Add(factory.getDALType(columnsTypesArray[i], dr[i]));
                }
                tableList.Add(rowList);
            }
            return tableList;
        }
    }

    public enum DALTypes {String, Int, Double};

    public class DALTypeFactory
    {
        Dictionary<DALTypes, Type> dict = new Dictionary<DALTypes, Type>();


       public DALTypeFactory()
       {
           dict[DALTypes.String] = Type.GetType("InvestmentGame.DALString");
           dict[DALTypes.Int] = Type.GetType("InvestmentGame.DALInt");
           dict[DALTypes.Double] = Type.GetType("InvestmentGame.DALDouble");


       }

        public DALType getDALType(DALTypes type, object data)
       {
            object[] constructorArgs = new Object[1];
            constructorArgs[0] = data;
            DALType dalType = (DALType)Activator.CreateInstance(dict[type]);
            dalType._data = data;
            return dalType;
       }
    }

    public abstract class DALType
    {
        public object _data { get; set; }
        

         public abstract DALTypes returnType();

         public DALType()
         {
             _data = new object();
         }

        public DALType(object data)
        {
            _data = data;
        }

        virtual
        public object getData()
        {
            return _data;
        }

    }

    public class DALString : DALType
    {


        public DALString()
            : base("")
        { }
        
        public DALString(string data)
            : base(data)
        {}
        


        override
        public  DALTypes returnType()
        {
            return DALTypes.String;
        }

    }

    public class DALInt : DALType
      {

        public DALInt()
            : base(0)
        { }    

          public DALInt(Int32 data)
            : base(data)
          {}


        override
        public  DALTypes returnType()
        {
            return DALTypes.Int;
        }

        override 
        public object getData()
        {
            return Int32.Parse(_data.ToString());
        }
            
      }

    public class DALDouble : DALType
      {

        public DALDouble()
            : base(0)
        { }
        
        public DALDouble(Double data)
            : base(data)
          {}

        override
        public  DALTypes returnType()
        {
            return DALTypes.Double;
        }

        public override object getData()
        {
            return double.Parse(_data.ToString());
        }
        
      }


}
