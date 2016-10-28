using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace A15_Ex03
{
    public partial class FacebookApplication : Form
    {
        private User m_LoggedInUser;
        private LogicApp m_logicApp = LogicApp.getLogicApp();
        private Context m_Context = new Context();
        private IStrategy m_Strategy;

        private void setStrategy()
        {
            m_Strategy = m_Context.getStrategy();
        }

        public FacebookApplication()
        {
            InitializeComponent();
            disableControls();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void loginAndInit()
        {
            LoginResult result = FacebookService.Login("801621103232694", "user_friends");

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }

            picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            fillOptionCombobox();
            enableControls();
        }

        private void fillOptionCombobox()
        {
            optionsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] i_Genders = new string[] { "Movies", "Books", "Music" };
            optionsComboBox.Items.AddRange(i_Genders);
        }

        private void enableControls()
        {
            dataListBox.Enabled = true;
            optionsComboBox.Enabled = true;
            optionButton.Enabled = true;
            SimpleCalculationButton.Enabled = true;
            AccurateCalculationButton.Enabled = true;
            logoutbutton.Enabled = true;
            buttonLogin.Enabled = false;
        }

        private void disableControls()
        {
            dataListBox.Enabled = false;
            optionsComboBox.Enabled = false;
            optionButton.Enabled = false;
            SimpleCalculationButton.Enabled = false;
            AccurateCalculationButton.Enabled = false;
            logoutbutton.Enabled = false;
            buttonLogin.Enabled = true;
        }

        private void listBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedItem();
        }

        private void displaySelectedItem()
        {
            if (dataListBox.SelectedItems.Count == 1)
            {
                Page selectedData = dataListBox.SelectedItem as Page;
                FacebookObjectCollection<Album> url = selectedData.Albums;
                if (url != null)
                {
                    pictureBox1.LoadAsync(url[2].PictureAlbumURL);
                }
                else
                {
                    picture_smallPictureBox.Image = picture_smallPictureBox.ErrorImage;
                }
            }
        }

        private void SearchOkButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            dataListBox.Items.Clear();
            String typeOfData = optionsComboBox.SelectedItem as String;
            getSharedData(typeOfData);
        }

        private void getSharedData(String typeOfData)
        {
            dataListBox.DisplayMember = "Name";
            m_logicApp.fetchFriends(m_LoggedInUser);

            FacebookObjectCollection<Page> userLogInData = FacebookService.GetCollection<Page>(typeOfData, m_LoggedInUser.Id);

            foreach (User friend in m_logicApp.getListOfFriends())
            {
                FacebookObjectCollection<Page> friendData = FacebookService.GetCollection<Page>(typeOfData, friend.Id);
                foreach (Page userDt in userLogInData)
                {
                    foreach (Page friendDt in friendData)
                    {
                        if (friendDt.Name == userDt.Name && !dataListBox.Items.Contains(friendDt.Name))
                        {
                            dataListBox.Items.Add(friendDt);
                        }
                    }
                }
            }
        }

        private void checkRatio()
        {
            if (m_logicApp.getListOfFriends().Count == 0)
            {
                resultMessageTextBox.Text = "You are poor ,get a life!!";

                return;
            }

            string genderOfLoggedInUser = UsefulMethods.getGender(m_LoggedInUser);
            float resultOfCalculation = m_Strategy.RatioOfBoysFromTotal(m_LoggedInUser, m_logicApp);
            resultMessageTextBox.Text = Message.BuilderMessage(genderOfLoggedInUser, resultOfCalculation, ref picture_smallPictureBox);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            clear();
            disableControls();
        }

        private void clear()
        {
            picture_smallPictureBox.Image = null;
            pictureBox1.Image = null;
            dataListBox.Items.Clear();
            optionsComboBox.Items.Clear();
            resultMessageTextBox.Text = null;
        }

        private void SimpleCalculationButton_Click(object sender, EventArgs e)
        {
            m_Context.setSimpleCalculationStrategy();
            checkRatio();
        }

        private void AccurateCalculationButton_Click(object sender, EventArgs e)
        {
            m_Context.setAccuratCalculatiinStrategy();
            checkRatio();
        }
    }
}

