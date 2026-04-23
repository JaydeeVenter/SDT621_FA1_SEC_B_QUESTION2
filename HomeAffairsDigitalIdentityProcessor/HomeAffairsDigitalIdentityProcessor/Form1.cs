using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeAffairsDigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //this block of code will run once the user clicks on the Validate ID button
        private void ValidateIDbtn_Click(object sender, EventArgs e)
        {
            //the code below creates a new user profile:
            //.Trim() is added t insure no errors happen because of spaces
            CitizenProfile userProfile = new CitizenProfile(usrName.Text.Trim(), usrID.Text.Trim(), usrCitizenship.Text.Trim());

            //this displays the result in the label:
            ValidatedIDLbl.Text = userProfile.ValidateID();
        }

        private void generateProfileBtn_Click(object sender, EventArgs e)
        {
            //recreates the user profile again incase it cannot find
            CitizenProfile userProfile = new CitizenProfile(usrName.Text, usrID.Text, usrCitizenship.Text);

            //this creates the user profile summary:
            string userProfileSummary = $"==== DIGITAL CITIZEN SUMMARY ====\r\n" +
                                        $"Name: {userProfile.FullName}\r\n" +
                                        $"ID Number: {userProfile.IDNumber}\r\n" +
                                        $"Age: {userProfile.Age}\r\n" +
                                        $"Citizenship: {userProfile.CitizenshipStatus}\r\n" +
                                        $"Validation: {userProfile.ValidateID()}\r\n" +
                                        "Processed at: Home Affairs Service Desk\r\n" +
                                        $"Timestamp: {DateTime.Now:yyy/MM/dd HH:mm:ss}";
            //this displays the summary in the relevant textbox
            textBox4.Text = userProfileSummary;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Green;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
