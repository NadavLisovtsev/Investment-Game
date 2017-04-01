<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InvestmentGame.Default" %>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

     <!--   <script src="Scripts/jquery-1.4.3.js" type="text/javascript"></script> -->
        
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>

     <!-- amCharts javascript sources -->
		<script type="text/javascript" src="https://www.amcharts.com/lib/3/amcharts.js"></script>
		<script type="text/javascript" src="https://www.amcharts.com/lib/3/xy.js"></script>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="view0" runat="server">
        
            <p>  You are now given an initial amount of virtual $100.</p>
            <p>  Your goal is to accumulate as much money as possible through the game. To reach this goal, you can invest your money with the help of our new investments agent.</p>
            <p>  All you need to do is to decide on the amount of money you want the agent to invest on your behalf on each step. </p>
            <p>The agent will invest the money you give it and you will see the results of the investment after it was carried out.</p>
            <br/>
            <p>For its help the agent will charge a 2% commission out of each investment it makes.</p>
            <p>For example, if you give the agent $100, the agent will invest the given amount and charge 2$ from the result. </p>
            <br/>
            <p>The amount of virtual money you end up with at the end of the game, will determine your additional bonus for this hit - each virtual $3 will get you 1 cent as a bonus.</p>
            <p>For example, if you end up with $150, you will get a bonus of 50 cents.</p>
            <p>Press the "Next" button to continue.</p>
            
            <asp:Button ID="btnNext0" runat="server" Text="Next" onclick="btnNext_Click" Enabled="false"/>

        </asp:View>

          <asp:View ID="Intro2" runat="server">
        
           <script src="https://sarnelab.cs.biu.ac.il/Investment Game/Scripts/graph.js" type="text/javascript"></script> -->
           <!--  <script src="http://localhost:52667/Scripts/graph.js" type="text/javascript"></script> -->

            <br />
              <p>Our agent can invest in eight possible stocks.</p>
              <p>Each time it can either choose the same or different stock.</p>
              <p>The chart below describes the possible returns of the different stocks.</p>
            <p>As you can see, different stocks have different behaviors and each stock is associated with a different average return and risk.</p>
            <strong class="style1 style2">  
                     <p> In each turn you will have to decide how much money you want to give to invest. </p>
                     <p>   And the agent will try it's best to maximize your money. </p>
            </strong>
            
            
            <h3> Good Luck! </h3>

            <div id="chartdiv1" style="width: 100%; height: 400px; background-color: #FFFFFF;" ></div>

                <p>Press the button to move on to a short quiz on the Hit rules, and then proceed to training and game.</p>
            
            <asp:Button ID="BtnNext05" runat="server" Text="Start!" onclick="btnNext_Intro2_Click" Enabled="true"/>

            

        </asp:View>
         
       <asp:View ID="understanding_quiz_view" runat="server">
            <h2>Quiz</h2>
            <div style="text-align:center; width:640px; margin:0 auto;">
                <table style="text-align:left; width:640px;" border="1">
                    <tr>
                        <td>
                            <asp:Label ID="lblQuiz1" style="color:Red;" runat="server" Text="Please answer correctly the following questions in order to proceed"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>How much bonus will you get if you will end up with $300?
                        <asp:RadioButtonList ID="rbl1" runat="server">
                            <asp:ListItem>20 cents</asp:ListItem>
                            <asp:ListItem>50 cents</asp:ListItem>
                            <asp:ListItem>80 cents</asp:ListItem>
                            <asp:ListItem>100 cents</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfv1" Style="color:Red;" ControlToValidate="rbl1" runat="server" ErrorMessage="You have to answer"></asp:RequiredFieldValidator>
                    
                    </td></tr>
                    <tr><td>If you give the agent $100 to invest and the investment resulted in losing half of this amount. How much will the agent charge you? 
                        <asp:RadioButtonList ID="rbl2" runat="server">
                            <asp:ListItem>$1</asp:ListItem>
                            <asp:ListItem>$10</asp:ListItem>
                            <asp:ListItem>$2</asp:ListItem>
                            <asp:ListItem>$0.5</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfv2" Style="color:Red;" ControlToValidate="rbl2" runat="server" ErrorMessage="You have to answer"></asp:RequiredFieldValidator>
                      </td>
                    </tr>
                     <tr><td>If at the first round you gave the agent $100 to invest, and the investment resulted in 100% gain. How much will you have at the beginning of the second round?
                        <asp:RadioButtonList ID="rbl3" runat="server">
                            <asp:ListItem>$100</asp:ListItem>
                            <asp:ListItem>$200</asp:ListItem>
                            <asp:ListItem>$199</asp:ListItem>
                            <asp:ListItem>$198</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfv3" Style="color:Red;" ControlToValidate="rbl3" runat="server" ErrorMessage="You have to answer"></asp:RequiredFieldValidator>
                      </td>
                    </tr>
                </table>
            </div>
           <p>Finish the quiz and press the "Next" button to move on to the next step</p>
            <asp:Button ID="btnNextUnderstandingQuiz" runat="server" Text="Next" onclick="btnNextUQ_Click" />
        </asp:View>

         <asp:View ID="general_data_view" runat="server">
            <h2 style="color:#0066FF;"><span class="style13"><strong>Some information before we start..</strong></span></h2>
                <asp:Panel ID="panel" runat="server"  
                    style="text-align: left; margin-top: 0px;">
                    <asp:Label ID="label1" runat="server" Text="Your Gender:" Style="color: #000000; text-align: center;"
                        Font-Size="Large" Font-Bold="True" Font-Names="Comic Sans MS" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="148px" 
                        style="text-align: center">
                        <asp:ListItem>-- select one --</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredGenderValidator" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="  Please select gender" ControlToValidate="DropDownList1"
                        ValidationGroup="selectDropDownList" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="label2" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" 
                        Text="Your Age:" Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="22px" Width="148px">
                        <asp:ListItem>-- select one --</asp:ListItem>
                        <asp:ListItem>0-10</asp:ListItem>
                        <asp:ListItem>11-20</asp:ListItem>
                        <asp:ListItem>21-25</asp:ListItem>
                        <asp:ListItem>26-30</asp:ListItem>
                        <asp:ListItem>31-35</asp:ListItem>
                        <asp:ListItem>36-40</asp:ListItem>
                        <asp:ListItem>41-45</asp:ListItem>
                        <asp:ListItem>46-50</asp:ListItem>
                        <asp:ListItem>51-55</asp:ListItem>
                        <asp:ListItem>56-60</asp:ListItem>
                        <asp:ListItem>61-65</asp:ListItem>
                        <asp:ListItem>66-70</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredAgeValidator" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="  Please select age" ControlToValidate="DropDownList2"
                        ValidationGroup="selectDropDownList" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="label3" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" Text="Your Education:" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="148px">
                        <asp:ListItem>-- select one --</asp:ListItem>
                        <asp:ListItem>Primary education</asp:ListItem>
                        <asp:ListItem>Secondary education</asp:ListItem>
                        <asp:ListItem>Bachelor</asp:ListItem>
                        <asp:ListItem>Master</asp:ListItem>
                        <asp:ListItem>Doctoral</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredEducationValidator" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="Please select education" ControlToValidate="DropDownList3"
                        ValidationGroup="selectDropDownList" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="label4" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" Text="Your Nationaity:" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="149px">
                        <asp:ListItem>-- select one --</asp:ListItem>
                        <asp:ListItem>United States</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                        <asp:ListItem>Russian Federation</asp:ListItem>
                        <asp:ListItem>Afghanistan</asp:ListItem>
                        <asp:ListItem>Albania</asp:ListItem>
                        <asp:ListItem>Algeria</asp:ListItem>
                        <asp:ListItem>American Samoa</asp:ListItem>
                        <asp:ListItem>Andorra</asp:ListItem>
                        <asp:ListItem>Angola</asp:ListItem>
                        <asp:ListItem>Anguilla</asp:ListItem>
                        <asp:ListItem>Antarctica</asp:ListItem>
                        <asp:ListItem>Antigua And Barbuda</asp:ListItem>
                        <asp:ListItem>Argentina</asp:ListItem>
                        <asp:ListItem>Armenia</asp:ListItem>
                        <asp:ListItem>Aruba</asp:ListItem>
                        <asp:ListItem>Australia</asp:ListItem>
                        <asp:ListItem>Austria</asp:ListItem>
                        <asp:ListItem>Azerbaijan</asp:ListItem>
                        <asp:ListItem>Bahamas</asp:ListItem>
                        <asp:ListItem>Bahrain</asp:ListItem>
                        <asp:ListItem>Bangladesh</asp:ListItem>
                        <asp:ListItem>Barbados</asp:ListItem>
                        <asp:ListItem>Belarus</asp:ListItem>
                        <asp:ListItem>Belgium</asp:ListItem>
                        <asp:ListItem>Belize</asp:ListItem>
                        <asp:ListItem>Benin</asp:ListItem>
                        <asp:ListItem>Bermuda</asp:ListItem>
                        <asp:ListItem>Bhutan</asp:ListItem>
                        <asp:ListItem>Bolivia</asp:ListItem>
                        <asp:ListItem>Bosnia And Herzegowina</asp:ListItem>
                        <asp:ListItem>Botswana</asp:ListItem>
                        <asp:ListItem>Bouvet Island</asp:ListItem>
                        <asp:ListItem>Brazil</asp:ListItem>
                        <asp:ListItem>British Indian Ocean Territory</asp:ListItem>
                        <asp:ListItem>Brunei Darussalam</asp:ListItem>
                        <asp:ListItem>Bulgaria</asp:ListItem>
                        <asp:ListItem>Burkina Faso</asp:ListItem>
                        <asp:ListItem>Burundi</asp:ListItem>
                        <asp:ListItem>Cambodia</asp:ListItem>
                        <asp:ListItem>Cameroon</asp:ListItem>
                        <asp:ListItem>Canada</asp:ListItem>
                        <asp:ListItem>Cape Verde</asp:ListItem>
                        <asp:ListItem>Cayman Islands</asp:ListItem>
                        <asp:ListItem>Central African Republic</asp:ListItem>
                        <asp:ListItem>Chad</asp:ListItem>
                        <asp:ListItem>Chile</asp:ListItem>
                        <asp:ListItem>China</asp:ListItem>
                        <asp:ListItem>Colombia</asp:ListItem>
                        <asp:ListItem>Comoros</asp:ListItem>
                        <asp:ListItem>Congo</asp:ListItem>
                        <asp:ListItem>Cook Islands</asp:ListItem>
                        <asp:ListItem>Costa Rica</asp:ListItem>
                        <asp:ListItem>Cote D'Ivoire</asp:ListItem>
                        <asp:ListItem>Croatia</asp:ListItem>
                        <asp:ListItem>Cuba</asp:ListItem>
                        <asp:ListItem>Cyprus</asp:ListItem>
                        <asp:ListItem>Czech Republic</asp:ListItem>
                        <asp:ListItem>Denmark</asp:ListItem>
                        <asp:ListItem>Djibouti</asp:ListItem>
                        <asp:ListItem>Dominica</asp:ListItem>
                        <asp:ListItem>Dominican Republic</asp:ListItem>
                        <asp:ListItem>East Timor</asp:ListItem>
                        <asp:ListItem>Ecuador</asp:ListItem>
                        <asp:ListItem>Egypt</asp:ListItem>
                        <asp:ListItem>El Salvador</asp:ListItem>
                        <asp:ListItem>Equatorial Guinea</asp:ListItem>
                        <asp:ListItem>Eritrea</asp:ListItem>
                        <asp:ListItem>Estonia</asp:ListItem>
                        <asp:ListItem>Ethiopia</asp:ListItem>
                        <asp:ListItem>Falkland Islands (Malvinas)</asp:ListItem>
                        <asp:ListItem>Faroe Islands</asp:ListItem>
                        <asp:ListItem>Fiji</asp:ListItem>
                        <asp:ListItem>Finland</asp:ListItem>
                        <asp:ListItem>France</asp:ListItem>
                        <asp:ListItem>French Guiana</asp:ListItem>
                        <asp:ListItem>French Polynesia</asp:ListItem>
                        <asp:ListItem>French Southern Territories</asp:ListItem>
                        <asp:ListItem>Gabon</asp:ListItem>
                        <asp:ListItem>Gambia</asp:ListItem>
                        <asp:ListItem>Georgia</asp:ListItem>
                        <asp:ListItem>Germany</asp:ListItem>
                        <asp:ListItem>Ghana</asp:ListItem>
                        <asp:ListItem>Gibraltar</asp:ListItem>
                        <asp:ListItem>Greece</asp:ListItem>
                        <asp:ListItem>Greenland</asp:ListItem>
                        <asp:ListItem>Grenada</asp:ListItem>
                        <asp:ListItem>Guadeloupe</asp:ListItem>
                        <asp:ListItem>Guam</asp:ListItem>
                        <asp:ListItem>Guatemala</asp:ListItem>
                        <asp:ListItem>Guinea</asp:ListItem>
                        <asp:ListItem>Guinea-Bissau</asp:ListItem>
                        <asp:ListItem>Guyana</asp:ListItem>
                        <asp:ListItem>Haiti</asp:ListItem>
                        <asp:ListItem>Honduras</asp:ListItem>
                        <asp:ListItem>Hong Kong</asp:ListItem>
                        <asp:ListItem>Hungary</asp:ListItem>
                        <asp:ListItem>Icel And</asp:ListItem>
                        <asp:ListItem>Indonesia</asp:ListItem>
                        <asp:ListItem>Iran</asp:ListItem>
                        <asp:ListItem>Iraq</asp:ListItem>
                        <asp:ListItem>Ireland</asp:ListItem>
                        <asp:ListItem>Israel</asp:ListItem>
                        <asp:ListItem>Italy</asp:ListItem>
                        <asp:ListItem>Jamaica</asp:ListItem>
                        <asp:ListItem>Japan</asp:ListItem>
                        <asp:ListItem>Jordan</asp:ListItem>
                        <asp:ListItem>Kazakhstan</asp:ListItem>
                        <asp:ListItem>Kenya</asp:ListItem>
                        <asp:ListItem>Kiribati</asp:ListItem>
                        <asp:ListItem>Korea</asp:ListItem>
                        <asp:ListItem>Kuwait</asp:ListItem>
                        <asp:ListItem>Kyrgyzstan</asp:ListItem>
                        <asp:ListItem>Latvia</asp:ListItem>
                        <asp:ListItem>Lebanon</asp:ListItem>
                        <asp:ListItem>Lesotho</asp:ListItem>
                        <asp:ListItem>Liberia</asp:ListItem>
                        <asp:ListItem>Libyan</asp:ListItem>
                        <asp:ListItem>Liechtenstein</asp:ListItem>
                        <asp:ListItem>Lithuania</asp:ListItem>
                        <asp:ListItem>Luxembourg</asp:ListItem>
                        <asp:ListItem>Macau</asp:ListItem>
                        <asp:ListItem>Macedonia</asp:ListItem>
                        <asp:ListItem>Madagascar</asp:ListItem>
                        <asp:ListItem>Malawi</asp:ListItem>
                        <asp:ListItem>Malaysia</asp:ListItem>
                        <asp:ListItem>Maldives</asp:ListItem>
                        <asp:ListItem>Mali</asp:ListItem>
                        <asp:ListItem>Malta</asp:ListItem>
                        <asp:ListItem>Marshall Islands</asp:ListItem>
                        <asp:ListItem>Martinique</asp:ListItem>
                        <asp:ListItem>Mauritania</asp:ListItem>
                        <asp:ListItem>Mauritius</asp:ListItem>
                        <asp:ListItem>Mayotte</asp:ListItem>
                        <asp:ListItem>Mexico</asp:ListItem>
                        <asp:ListItem>Micronesia, Federated States</asp:ListItem>
                        <asp:ListItem>Moldova, Republic Of</asp:ListItem>
                        <asp:ListItem>Monaco</asp:ListItem>
                        <asp:ListItem>Mongolia</asp:ListItem>
                        <asp:ListItem>Montserrat</asp:ListItem>
                        <asp:ListItem>Morocco</asp:ListItem>
                        <asp:ListItem>Mozambique</asp:ListItem>
                        <asp:ListItem>Myanmar</asp:ListItem>
                        <asp:ListItem>Namibia</asp:ListItem>
                        <asp:ListItem>Nauru</asp:ListItem>
                        <asp:ListItem>Nepal</asp:ListItem>
                        <asp:ListItem>Netherlands</asp:ListItem>
                        <asp:ListItem>Netherlands Ant Illes</asp:ListItem>
                        <asp:ListItem>New Caledonia</asp:ListItem>
                        <asp:ListItem>New Zealand</asp:ListItem>
                        <asp:ListItem>Nicaragua</asp:ListItem>
                        <asp:ListItem>Niger</asp:ListItem>
                        <asp:ListItem>Nigeria</asp:ListItem>
                        <asp:ListItem>Niue</asp:ListItem>
                        <asp:ListItem>Norfolk Island</asp:ListItem>
                        <asp:ListItem>Northern Mariana Islands</asp:ListItem>
                        <asp:ListItem>Norway</asp:ListItem>
                        <asp:ListItem>Oman</asp:ListItem>
                        <asp:ListItem>Pakistan</asp:ListItem>
                        <asp:ListItem>Palau</asp:ListItem>
                        <asp:ListItem>Panama</asp:ListItem>
                        <asp:ListItem>Papua New Guinea</asp:ListItem>
                        <asp:ListItem>Paraguay</asp:ListItem>
                        <asp:ListItem>Peru</asp:ListItem>
                        <asp:ListItem>Philippines</asp:ListItem>
                        <asp:ListItem>Pitcairn</asp:ListItem>
                        <asp:ListItem>Poland</asp:ListItem>
                        <asp:ListItem>Portugal</asp:ListItem>
                        <asp:ListItem>Puerto Rico</asp:ListItem>
                        <asp:ListItem>Qatar</asp:ListItem>
                        <asp:ListItem>Reunion</asp:ListItem>
                        <asp:ListItem>Romania</asp:ListItem>
                        <asp:ListItem>Rwanda</asp:ListItem>
                        <asp:ListItem>Saint K Itts And Nevis</asp:ListItem>
                        <asp:ListItem>Saint Lucia</asp:ListItem>
                        <asp:ListItem>Saint Vincent, The Grenadines</asp:ListItem>
                        <asp:ListItem>Samoa</asp:ListItem>
                        <asp:ListItem>San Marino</asp:ListItem>
                        <asp:ListItem>Sao Tome And Principe</asp:ListItem>
                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                        <asp:ListItem>Senegal</asp:ListItem>
                        <asp:ListItem>Seychelles</asp:ListItem>
                        <asp:ListItem>Sierra Leone</asp:ListItem>
                        <asp:ListItem>Singapore</asp:ListItem>
                        <asp:ListItem>Slovakia (Slovak Republic)</asp:ListItem>
                        <asp:ListItem>Slovenia</asp:ListItem>
                        <asp:ListItem>Solomon Islands</asp:ListItem>
                        <asp:ListItem>Somalia</asp:ListItem>
                        <asp:ListItem>South Africa</asp:ListItem>
                        <asp:ListItem>South Georgia</asp:ListItem>
                        <asp:ListItem>Spain</asp:ListItem>
                        <asp:ListItem>Sri Lanka</asp:ListItem>
                        <asp:ListItem>St. Helena</asp:ListItem>
                        <asp:ListItem>St. Pierre And Miquelon</asp:ListItem>
                        <asp:ListItem>Sudan</asp:ListItem>
                        <asp:ListItem>Suriname</asp:ListItem>
                        <asp:ListItem>Svalbard, Jan Mayen Islands</asp:ListItem>
                        <asp:ListItem>Sw Aziland</asp:ListItem>
                        <asp:ListItem>Sweden</asp:ListItem>
                        <asp:ListItem>Switzerland</asp:ListItem>
                        <asp:ListItem>Syrian Arab Republic</asp:ListItem>
                        <asp:ListItem>Taiwan</asp:ListItem>
                        <asp:ListItem>Tajikistan</asp:ListItem>
                        <asp:ListItem>Tanzania, United Republic Of</asp:ListItem>
                        <asp:ListItem>Thailand</asp:ListItem>
                        <asp:ListItem>Togo</asp:ListItem>
                        <asp:ListItem>Tokelau</asp:ListItem>
                        <asp:ListItem>Tonga</asp:ListItem>
                        <asp:ListItem>Trinidad And Tobago</asp:ListItem>
                        <asp:ListItem>Tunisia</asp:ListItem>
                        <asp:ListItem>Turkey</asp:ListItem>
                        <asp:ListItem>Turkmenistan</asp:ListItem>
                        <asp:ListItem>Turks And Caicos Islands</asp:ListItem>
                        <asp:ListItem>Tuvalu</asp:ListItem>
                        <asp:ListItem>Uganda</asp:ListItem>
                        <asp:ListItem>Ukraine</asp:ListItem>
                        <asp:ListItem>United Arab Emirates</asp:ListItem>
                        <asp:ListItem>United Kingdom</asp:ListItem>
                        <asp:ListItem>Uruguay</asp:ListItem>
                        <asp:ListItem>Uzbekistan</asp:ListItem>
                        <asp:ListItem>Vanuatu</asp:ListItem>
                        <asp:ListItem>Venezuela</asp:ListItem>
                        <asp:ListItem>Viet Nam</asp:ListItem>
                        <asp:ListItem>Virgin Islands (British)</asp:ListItem>
                        <asp:ListItem>Virgin Islands (U.S.)</asp:ListItem>
                        <asp:ListItem>Wallis And Futuna Islands</asp:ListItem>
                        <asp:ListItem>Western Sahara</asp:ListItem>
                        <asp:ListItem>Yemen</asp:ListItem>
                        <asp:ListItem>Yugoslavia</asp:ListItem>
                        <asp:ListItem>Zaire</asp:ListItem>
                        <asp:ListItem>Zambia</asp:ListItem>
                        <asp:ListItem>Zimbabwe</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredNationalityValidator" Style="color: Red;
                        font-family: 'Comic Sans MS'; font-size: small;" runat="server" ErrorMessage="  Please select nationality"
                        ControlToValidate="DropDownList4" ValidationGroup="selectDropDownList" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="label6" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
	                    Font-Size="Large" Style="color: #000000; text-align: center;" Text="Reason for participating:" 
	                    Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="22px" Width="148px">
	                    <asp:ListItem>-- select one --</asp:ListItem>
	                    <asp:ListItem>I am at work and I have spare time</asp:ListItem>
	                    <asp:ListItem>My primary work is Amazon Turk</asp:ListItem>
	                    <asp:ListItem>I need to "burn" free time</asp:ListItem>
	                    <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredReasonValidator" Style="color: Red; font-family: 'Comic Sans MS';
	                    font-size: small;" runat="server" ErrorMessage="Please select your reason" ControlToValidate="DropDownList5"
	                    ValidationGroup="selectDropDownList" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>

            </asp:Panel>
            <br />

            <p>Press the "Next" button to try out the game (training).</p>
                <asp:Button ID="btnNextGeneralData" runat="server" onclick="btnNextGD_Click" Text="OK" 
                    ValidationGroup="selectDropDownList" />

                <asp:HiddenField ID="windowWidth0" runat="server" value=""  />
                <asp:HiddenField ID="windowHeight0" runat="server" value=""  />

        </asp:View>

         <asp:View ID="training_view" runat="server">

            
             <script src="https://sarnelab.cs.biu.ac.il/Investment Game/Scripts/site_script.js" type="text/javascript"></script>
            <!-- <script src="http://localhost:52667/Scripts/site_script.js" type="text/javascript"></script> -->

          <script src="https://sarnelab.cs.biu.ac.il/Investment Game/Scripts/training_script.js" type="text/javascript"></script>
            <!-- <script src="http://localhost:52667/Scripts/training_script.js" type="text/javascript"></script> -->


            <div class="DataDiv">
                <p class="WaitTime"><%= Session["WaitTime"]%></p>
                <p class="MoneyData"><%= Session["Money"] %></p>
                <p class="isMinTrainingDone"><%=Session["isMinTrainingDone"] %></p>
            </div>
             
             <h1>Training</h1>
            <div class="RoundData">
                <h2> Round <%= Session["TrainingRound"]%></h2>
                <p>You Have: <span> $<%= Session["Money"]%> </span></p>
                <p>Enter the amount of money you want to give the agent to invest in this round:</p>
                <asp:TextBox ID="TrainingMoneyInput" runat="server" autocomplete="off" PlaceHolder="Enter Your Investment" CssClass="MoneyInput"> </asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Invest" onclick="btnNext1_Click" class="FakeInvestButton"/>
                <div class="EndTrainingDiv">
                    <p>You have now completed <%=Session["MinTrainigRounds"] %> training rounds.</p>
                    <p>You can proceed to the game or keep training.</p>
                    <p>Click on this button at any time to proceed to the game.</p>
                    <asp:Button ID="Button3" runat="server" Text="Continue to the game" onclick="goToGame" class="EndTrainingButton"/>
                </div>
                <h1 class="WrongInput"></h1>
            </div>
            <asp:Button ID="Button2" runat="server" Text="Invest" OnClick="nextTraining" class="InvestButton"/>
            <asp:Image ID="Image1" runat="server" ImageUrl="http://sarnelab.cs.biu.ac.il/Investment Game/Images/loading_spinner.gif" class="WaitGif" />
            <asp:Image ID="Image2" runat="server" ImageUrl="http://sarnelab.cs.biu.ac.il/Investment Game/Images/investment.jpg" class="Image"/>

            <!-- <asp:Image ID="Image3" runat="server" ImageUrl="http://localhost:52667/Images/loading_spinner.gif" class="WaitGif" />
            <asp:Image ID="Image4" runat="server" ImageUrl="http://localhost:52667/Images/investment.jpg" class="Image"/> -->
        </asp:View>

         <asp:View ID="investment_view" runat="server">

            
           <!-- <script src="https://sarnelab.cs.biu.ac.il/Investment Game/Scripts/site_script.js" type="text/javascript"></script> -->
           <script src="http://localhost:52667/Scripts/site_script.js" type="text/javascript"></script>

            <div class="DataDiv">
                <p class="WaitTime"><%= Session["WaitTime"]%></p>
                <p class="MoneyData"><%= Session["Money"] %></p>
            </div>

            <div class="RoundData">
                <h2> Round <%= Session["Round"]%> / <%= Session["MaxRounds"] %></h2>
                <p>You Have: $<span> <%= Session["Money"]%> </span></p>
                <p>Enter the amount of money you want to give the agent to invest in this round:</p>
                <asp:TextBox ID="MoneyInput" runat="server" autocomplete="off" PlaceHolder="Enter Your Investment" CssClass="MoneyInput"> </asp:TextBox>
                <asp:Button ID="fakeBtnNext1" runat="server" Text="Invest" onclick="btnNext1_Click" class="FakeInvestButton"/>
                <h1 class="WrongInput"></h1>
            </div>
            <asp:Button ID="btnNext1" runat="server" Text="Invest" OnClick="btnNext1_Click" class="InvestButton"/>
            <asp:Image ID="WaitingGif" runat="server" ImageUrl="https://sarnelab.cs.biu.ac.il/Investment Game/Images/loading_spinner.gif" class="WaitGif" />
            <asp:Image ID="InvestmentImage" runat="server" ImageUrl="https://sarnelab.cs.biu.ac.il/Investment Game/Images/investment.jpg" class="Image"/>

        </asp:View>

        <asp:View ID="investment_message_view" runat="server">
            <p><%= Session["InvestmentMessage"] %></p>
            <p><%= Session["InvestmentMessageInvestedMoney"] %></p>
            <p><%= Session["InvestmentMessageEarning"] %></p>
            <p><%= Session["InvestmentMessageCommission"] %></p>
            <p><%= Session["InvestmentMessageFinal"] %></p>
            <p>Click this button to procced to the next round.</p>
            <asp:Button ID="btnNext2" runat="server" Text="Next" OnClick="btnNext2_Click" class="NextButton"/>
        </asp:View>

      
      
        <asp:View ID="no_money_view" runat="server">

            <h2>End Game</h2>

            <h3> Sorry! You lost all your money :( </h3>
        </asp:View>

        <asp:View ID="end_game_view" runat="server" >
            <h2> Thank you! </h2>
            <h3>You have $<%= Session["Money"] %> and your bonus will be <%= Session["Bonus"] %> cents </h3>
            <h2>Please give us some feedback about this HIT (answer honestly, your payment and bonus is already guranteed).</h2>
            <br />

           
                       
        <asp:Panel ID="panel2" runat="server" style="text-align: left; margin-top: 0px;">
            <asp:Label ID="label7" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" Text="Overall, how satisfied were you with this HIT?" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList7" runat="server" Height="22px" Width="148px">
                        <asp:ListItem>-- select one --</asp:ListItem>
                        <asp:ListItem>Not satisfied at all</asp:ListItem>
                        <asp:ListItem>Somewhat satisfied</asp:ListItem>
                        <asp:ListItem>Generally satisfied</asp:ListItem>
                        <asp:ListItem>Very satisfied</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredHitValidator7" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="Please select satisfaction level" ControlToValidate="DropDownList7"
                        ValidationGroup="selectDropDownList1" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
					<br />
		
                    <asp:Label ID="label8" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" Text="How satisfied were you with the investment agent?" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList8" runat="server" Height="22px" Width="148px">
                        <asp:ListItem>-- select one --</asp:ListItem>
                        <asp:ListItem>Not satisfied at all</asp:ListItem>
                        <asp:ListItem>Somewhat satisfied</asp:ListItem>
                        <asp:ListItem>Generally satisfied</asp:ListItem>
                        <asp:ListItem>Very satisfied</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredHitValidator8" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="Please select attention level" ControlToValidate="DropDownList8"
                        ValidationGroup="selectDropDownList1" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
					<br />
					
                    <asp:Label ID="label9" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" Text="Would you recommended this agent to a friend?" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList9" runat="server" Height="22px" Width="148px">
                        <asp:ListItem>-- select one --</asp:ListItem>
						<asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredHitValidator9" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="Please answer the question" ControlToValidate="DropDownList9"
                        ValidationGroup="selectDropDownList1" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="label14" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                        Font-Size="Large" Style="color: #000000; text-align: center;" Text="Would you use this agent again (if you could)?" 
                        Width="400px"></asp:Label>
                    <asp:DropDownList ID="DropDownList10" runat="server" Height="22px" Width="148px">
                        <asp:ListItem>-- select one --</asp:ListItem>
						<asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredHitValidator10" Style="color: Red; font-family: 'Comic Sans MS';
                        font-size: small;" runat="server" ErrorMessage="Please answer the question" ControlToValidate="DropDownList10"
                        ValidationGroup="selectDropDownList1" InitialValue="-- select one --">
                    </asp:RequiredFieldValidator>
            </asp:Panel>
                    <br />
					<br />
            
             <h3>Comments:</h3>
             <asp:TextBox id="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" />
             <br />
             
            <br />
            <div>Please click the button below to submit the HIT and collect your reward</div>
            <asp:Button ID="btnNext6" runat="server" Text="Collect your reward" 
                 onclick="btnNext6_Click" ValidationGroup="selectDropDownList1" />
        </asp:View>       

    </asp:MultiView>

  </asp:Content>  
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <link href="https://sarnelab.cs.biu.ac.il/Investment%20Game/Styles/Site.css" rel="stylesheet" type="text/css" />
       <!-- <link href="http://localhost:52667/Styles/Site.css" rel="Stylesheet" type="text/css" />  -->
</asp:Content>
  
