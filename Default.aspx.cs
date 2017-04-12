using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using ZeroMQ;
using System.Web.Script.Serialization;
using InvestmentGame.Utils;


namespace InvestmentGame
{
    public partial class Default : System.Web.UI.Page 
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                String val = null;
                //friend assigment
                val = Request.QueryString["assignmentId"];
                if (val == null)
                {
                    User us = new User("friend", "turkAss", "hit id friend");
                    Session["User"] = us;
                    btnNext0.Enabled = true;

                }
                //from AMT but did not took the assigment
                else if (val.Equals("ASSIGNMENT_ID_NOT_AVAILABLE"))
                {
                    btnNext0.Enabled = false;
                }
                //from AMT and accepted the assigment - continue to experiment
                else
                {
                    User us = new User(Request.QueryString["workerId"], val, Request.QueryString["hitId"]);
                    Session["User"] = us;
                    btnNext0.Enabled = true;
                }
            }
        }

       
        protected void btnNext_Click(object sender, EventArgs e)
        {

            User user = (User)Session["User"];
            UserManager manager = new UserManager(user);
            Session["QuizManager"] = new QuizManager(user);
            if (user.user_id.Equals("friend"))
            {
                manager.addUserToDB();
                MultiView1.SetActiveView(Intro2);
            }
            else
            {             
                if(!manager.CheckIfUserExists())
                {
                    manager.addUserToDB();
                    MultiView1.SetActiveView(Intro2);
                }
                else
                {
                    Alert.Show("You already participated in this game. Please return the HIT");
                }
            }
        }

        protected void btnNext_Intro2_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(understanding_quiz_view);
        }

        //quiz view
        protected void btnNextUQ_Click(object sender, EventArgs e)
        {
            QuizManager qm = (QuizManager)Session["QuizManager"];
            if (rbl1.SelectedIndex == 3 && rbl2.SelectedIndex == 2 && rbl3.SelectedIndex == 3)
            {
                qm.saveTriesCountToDB();
                MultiView1.SetActiveView(general_data_view);
            }
            else
            {
                qm.incrementTriesCount();
                Alert.Show("wrong answer, please try again");
            }
        }

        //general_data_view
        protected void btnNextGD_Click(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            UserManager manager = new UserManager(user);
            string mobile = "not_mobile";
            if (Request.Browser.IsMobileDevice)
            {
                mobile = "mobile_user";
            }

            UserInfo user_info = new UserInfo(DropDownList1.Text,
                                              DropDownList2.Text,
                                              DropDownList3.Text,
                                              DropDownList4.Text,
                                              DropDownList5.Text,
                                              mobile);


            manager.saveUserInfo(user_info);
            init_game();

            MultiView1.SetActiveView(training_view);
        }

        private void init_game()
        {
            Session["Round"] = 1;
            Session["TrainingRound"] = 1;
            Session["MinTrainigRounds"] = int.Parse(ConfigurationManager.AppSettings["TrainingRounds"]);
            Session["isMinTrainingDone"] = 0;
            Session["isTraining"] = true;
            Session["Money"] = int.Parse(ConfigurationManager.AppSettings["InitialMoneyAmount"]);
            Session["History"] = new History();
            Session["waitTime"] = int.Parse(ConfigurationManager.AppSettings["AfterIvestmentWait"]) * 1000;
            Session["MaxRounds"] = ConfigurationManager.AppSettings["MaxRounds"];
        }

        //training view
        protected void nextTraining(object sender, EventArgs e)
        {
            float moneyInput;
            if (!checkRoundInput(TrainingMoneyInput.Text, out moneyInput))
            {
                Alert.Show("Wrong Input!");
                return;
            }

            doInvestment(moneyInput, true);

            TrainingMoneyInput.Text = "";
            MultiView1.SetActiveView(investment_message_view);
        }


        //done training
        protected void goToGame(object sender, EventArgs e)
        {
            Session["isTraining"] = false;
            Session["Money"] = int.Parse(ConfigurationManager.AppSettings["InitialMoneyAmount"]);
            Session["History"] = new History();
            MultiView1.SetActiveView(investment_view);
        }

        private double floor2(double num)
        {
            return Math.Floor(num * 100) / 100;
        }

        private void doInvestment(float moneyInput, bool isTrain)
        {
         
            double money = float.Parse(Session["Money"].ToString());
            GameManager gm = (GameManager)Session["GM"];
            User user = (User)Session["User"];

            int roundNum = isTrain ? (int)Session["TrainingRound"] : (int)Session["Round"];

            CommisionFactory commFactory = new CommisionFactory();
            Comission comm = commFactory.GetCommission(ConfigurationManager.AppSettings["CommissionType"]);

            AgentsFactory factory = new AgentsFactory();
            InvestAgent a = factory.CreateAgent(ConfigurationManager.AppSettings["AgentType"], gm, comm, isTrain);

            InvestmentData investment_data = a.Invest(moneyInput, (History)Session["History"], roundNum);

            double AfterMoney = floor2(money - moneyInput + investment_data.endMoney);
            Session["Money"] = AfterMoney;

            History hist = (History)Session["History"];
            hist.addRecord(new HistoryRecord(investment_data, money, AfterMoney, roundNum));
            Session["History"] = hist;

            InvestmentsRecorder recorder = new InvestmentsRecorder(user);
            int scenarioNum = isTrain ? gm.relevantTrainingScenario : gm.relevantScenario;
            recorder.RecordInvestment(investment_data, money, AfterMoney, roundNum, scenarioNum, investment_data.stockId, isTrain);


            if (isTrain)
            {
                Session["TrainingRound"] = (int)Session["TrainingRound"] + 1;
                if((int)Session["TrainingRound"] > (int)Session["MinTrainigRounds"] )
                {
                    Session["isMinTrainingDone"] = 1;
                }
            }
            else
            {
                Session["Round"] = (int)Session["Round"] + 1;
            }

            MoneyInput.Text = "";

            if (investment_data.investmentMoney == 0)
            {
                
                Session["InvestmentMessageInvestedMoney"] = "You invested $0.";
                Session["InvestmentMessageEarning"] = String.Format("The agent earned $0.", Session["Money"]);
                Session["InvestmentMessageCommission"] = String.Format("Commission of $0 has been taken from your investment.", Session["Money"]);
                Session["InvestmentMessageFinal"] = String.Format("You get back $0, so now you have ${0} in your account.", Session["Money"]);
            }
            else if (investment_data.earn > 0)
            {
                

                Session["InvestmentMessageInvestedMoney"] = String.Format("You invested ${0}.", investment_data.investmentMoney);
                Session["InvestmentMessageEarning"] = String.Format("The agent earned ${0} ({1}%).", floor2(investment_data.earnMoney), floor2(100 * investment_data.earn));
                Session["InvestmentMessageCommission"] = String.Format("Commission of {0}%  (${1}) has been taken from your investment.", floor2(investment_data.commission_percent), floor2(investment_data.commission));
                Session["InvestmentMessageFinal"] = String.Format("You get back ${0}, so now you have ${1} in your account", floor2(investment_data.endMoney), Session["Money"]);
            }
            else if (investment_data.earn < 0)
            {
                


                Session["InvestmentMessageInvestedMoney"] = String.Format("You invested ${0}.", investment_data.investmentMoney);
                Session["InvestmentMessageEarning"] = String.Format("The agent lost ${0} ({1}%).", floor2(investment_data.earnMoney) * (-1), floor2(100 * investment_data.earn) * (-1));
                Session["InvestmentMessageCommission"] = String.Format("Commission of {0}%  (${1}) has been taken from your investment.", floor2(investment_data.commission_percent), floor2(investment_data.commission));
                Session["InvestmentMessageFinal"] = String.Format("You get back ${0}, so now you have ${1} in your account", floor2(investment_data.endMoney), Session["Money"]);
            }
            else if (investment_data.earn == 0)
            {
                

                Session["InvestmentMessageInvestedMoney"] = String.Format("You invested ${0}.", investment_data.investmentMoney);
                Session["InvestmentMessageEarning"] = String.Format("The agent earned nothing ({0}%).", floor2(investment_data.earn) * 100);
                Session["InvestmentMessageCommission"] = String.Format("Commission of {0}%  (${1}) has been taken from your investment.", floor2(investment_data.commission_percent), floor2(investment_data.commission));
                Session["InvestmentMessageFinal"] = String.Format("You get back ${0}, so now you have ${1} in your account", floor2(investment_data.endMoney), Session["Money"]);
            
            }

        }

        private bool checkRoundInput(string input, out float money)
        {
            bool isGood = true;

            if (!float.TryParse(input, out money))
                isGood = false;

            if(money < 0 || money > float.Parse(Session["Money"].ToString()))
                isGood = false;

            return isGood;
        }

        //investment_view    
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            float moneyInput;
            if (!checkRoundInput(MoneyInput.Text, out moneyInput))
            {
                Alert.Show("Wrong Input!");
                return;
            }

            doInvestment(moneyInput, false);

            MultiView1.SetActiveView(investment_message_view);
        }

        //investment_message_view
        protected void btnNext2_Click(object sender, EventArgs e)
        {
            if ((int)Session["Round"] > int.Parse(ConfigurationManager.AppSettings["MaxRounds"]))
            {
                Session["Bonus"] = Math.Ceiling(float.Parse(Session["Money"].ToString()) / double.Parse(ConfigurationManager.AppSettings["BonusCoeff"]));
                MultiView1.SetActiveView(end_game_view);
                return;
            }

            if (float.Parse(Session["Money"].ToString()) == 0)
            {
                MultiView1.SetActiveView(no_money_view);
                return;
            }

            if(bool.Parse(Session["isTraining"].ToString()))
            {
                MultiView1.SetActiveView(training_view);
                return;
            }
            else
            {
                MultiView1.SetActiveView(investment_view);
                return;
            }
        }
         
        protected void btnNext6_Click(object sender, EventArgs e)
        {

            UserSatisfaction s = new UserSatisfaction(DropDownList7.Text,
                                                      DropDownList8.Text,
                                                      DropDownList9.Text,
                                                      DropDownList10.Text,
                                                      TextArea1.Text);
            UserManager m = new UserManager((User)Session["User"]);
            m.saceUserSatisfaction(s);

            NameValueCollection data = new NameValueCollection();
            data.Add("assignmentId", ((User)Session["User"]).turkAss);
            data.Add("workerId", ((User)Session["User"]).user_id);
            data.Add("hitId", ((User)Session["User"]).hitId);

            Alert.RedirectAndPOST(this.Page, "https://www.mturk.com/mturk/externalSubmit", data);
        }

    }
}