using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Host;

namespace Student
{
    public partial class StudentRegistrationForm : Form
    {
        public StudentRegistrationForm()
        {
            InitializeComponent();
        }

        //This method for load and display
        private void StudentRegistrationForm_Load(object sender, EventArgs e)
        {
            load();
            LoadStates();
        }

        private void LoadStates()
        {
            State ss = new State();
            StateInput.DisplayMember = "StateName";
            StateInput.ValueMember = "StateId";
            StateInput.DataSource = ss.getStates().Tables[0];
             

        }

        //This method is used to display onthe gridview box
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(GridViewStudent.Rows[e.RowIndex].Cells[0].Value.ToString());
            DisplayScreen(Id);
        }

        //Add Button.......
        private void Addbutton_Click(object sender, EventArgs e)
        {
            Hub hubobj = new Hub();
            hubobj.RollNo1 = Convert.ToInt32(SRNINPUT.Text);
            hubobj.Name1 = SNINPUT.Text;
            hubobj.Age1 = Convert.ToInt32(SAINPUT.Text);
            hubobj.Branch1 = SBINPUT.Text;
            hubobj.College1 = SCINPUT.Text;
            hubobj.Email1 = Email.Text;
            hubobj.State1 = Convert.ToInt32(StateInput.SelectedValue);
            
            string gender = "";
            string status = "";

            if(MaleradioButton.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            hubobj.Gender1 = gender;

            if (MarriedradioButton.Checked)
            {
                status = "Married";
            }
            else
            {
                status = "Unmarried";
            }
            hubobj.Status1 = status; 

            hubobj.adding();
            load();
            clearData();
        }

        //Update Button......
        private void Updatebutton_Click(object sender, EventArgs e)
        {
            Hub ho = new Hub();

            int RollNo = Convert.ToInt32(SRNINPUT.Text);
            string Name = SNINPUT.Text;
            int age = Convert.ToInt32(SAINPUT.Text);
            string branch = SBINPUT.Text;
            string Collage = SCINPUT.Text;
            string email = Email.Text;
            int State = Convert.ToInt32(StateInput.SelectedValue);

            string gender = "";
            string status = "";
            if (MaleradioButton.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
           // hubobj.Gender1 = GenderGroupbox.Text;

            if (MarriedradioButton.Checked)
            {
                status = "Married";
            }
            else
            {
                status = "Unmarried";
            }
            // hubobj.Status1 = StatusgroupBox.Text;
            ho.Name1 = Name;
            ho.Age1 = age;
            ho.Branch1 = branch;
            ho.College1 = Collage;
            ho.Gender1 = gender;
            ho.Status1 = status;
            ho.RollNo1 = RollNo;
            ho.Email1 = email;
            ho.State1 = State;
            ho.updating();
            load();
            clearData();
        }

        //Delete Button......
        private void Deletebutton_Click(object sender, EventArgs e)
        {
            Hub hubobj = new Hub();
            hubobj.Name1 = SNINPUT.Text;
            hubobj.deleting();
            load();
            clearData();
        }

        //This method is for Display on the Screen
        public void DisplayScreen(int student)
        {
            Hub hubobj = new Hub();
            DataSet datasetobj = hubobj.searchDetails(student);

            //int RollNo    = Convert.ToInt32( datasetobj.Tables[0].Rows[0][0].ToString());
            string Name   = datasetobj.Tables[0].Rows[0][1].ToString();
            int Age       = Convert.ToInt32(datasetobj.Tables[0].Rows[0][2].ToString());
            string Branch = datasetobj.Tables[0].Rows[0][3].ToString();
            string College= datasetobj.Tables[0].Rows[0][4].ToString();
            string Gender = datasetobj.Tables[0].Rows[0][5].ToString();
            string Status = datasetobj.Tables[0].Rows[0][6].ToString();
            string email = datasetobj.Tables[0].Rows[0][7].ToString();
            int State = Convert.ToInt32(datasetobj.Tables[0].Rows[0][8].ToString());


            SRNINPUT.Text = student.ToString();
            SNINPUT.Text = Name;
            SAINPUT.Text = Age.ToString();
            SBINPUT.Text = Branch;
            SCINPUT.Text = College;
            Email.Text = email;
            StateInput.SelectedValue = State.ToString();

           
            if (Gender=="Male")
            {
                MaleradioButton.Checked = true;
            }
            else
            {
                FemaleradioButton.Checked = true;
            }
            
            if (Status=="Married")
            {
                MarriedradioButton.Checked = true;
            }
            else
            {
                UnmarriedradioButton.Checked = true;
            }
            //StatusgroupBox.Text = Status;
        }


        private void SA_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
        //This method is used to load the details
        private void load()
        {
            Hub hubobj = new Hub();
            GridViewStudent.DataSource = hubobj.displayDeatils().Tables[0];
        }
            
        //This method will crear all the data in a table
        private void clearData()
        {
            SRNINPUT.Text = "";
            SNINPUT.Text = "";
            SAINPUT.Text = "";
            SBINPUT.Text = "";
            SCINPUT.Text = "";
            Email.Text = "";
            StateInput.SelectedIndex = 0;
            MaleradioButton.Checked = false;
            FemaleradioButton.Checked = false;
            MarriedradioButton.Checked = false;
            UnmarriedradioButton.Checked = false;


        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
