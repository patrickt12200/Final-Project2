using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Main_Page : Form
    {
        public Main_Page()
        {
            InitializeComponent();
        }

        private void Patient_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To be removed
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medsDataSet1.Allergies' table. You can move, or remove it, as needed.
            this.allergiesTableAdapter.Fill(this.medsDataSet1.Allergies);
            // TODO: This line of code loads data into the 'medsDataSet1.GenMed' table. You can move, or remove it, as needed.
            this.genMedTableAdapter.Fill(this.medsDataSet1.GenMed);
            // TODO: This line of code loads data into the 'medsDataSet1.Selection' table. You can move, or remove it, as needed.
            this.selectionTableAdapter.Fill(this.medsDataSet1.Selection);

            AdmissionRichBox.Enabled = false;
            MaritalBox.Enabled = false;
            HeightBox.Enabled = false;
            WeightBox.Enabled = false;
            SmokerBox.Enabled = false;
            BloodBox.Enabled = false;
            PressBox.Enabled = false;
            TobaccoBox.Enabled = false;
            HeartBox.Enabled = false;
            BreathBox.Enabled = false;
            SurgRichBox.Enabled = false;
            BehaveBox.Enabled = false;
            DrugBox.Enabled = false;
            PregBox.Enabled = false;
            AlcoholBox.Enabled = false;



            var tab1 = Gen_Hist_Tb;
            var tab2 = tabAllergies;
            this.New_PatientTb.TabPages.Remove(Gen_Hist_Tb);
            this.New_PatientTb.TabPages.Remove(tabAllergies);

            Gen_Hist_Tb.Visible = false;
            //Patient_Selection.Items.AddRange(MedsDataSet.SelectionDataTable)

            //Starts Clock
            timer1.Tick += new EventHandler(this.t_Tick);
            timer1.Start();

        }

        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            TimeLbl.Text = time;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //to be removed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Will save to DataBase 
                this.selectionTableAdapter.Update(this.medsDataSet1.Selection);
            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error.Message));
            }
          
        }

        private void Select_Pt_Click(object sender, EventArgs e)
        {
            //Select any cell in the row and it will auto select the ID of the patient 
            int RowIndex = Select_box.CurrentCell.RowIndex;

            // This is a proof of concept to pick what ID is selected to bring up information for the Patient on other pages.
            MessageBox.Show(Convert.ToString(Select_box.Rows[RowIndex].Cells[2].Value)); // messagebox for debug
        }

        private void Undo_btn_F1_Click(object sender, EventArgs e)
        {
            //Will reload the table from the database, erasing unsaved edits.
            this.selectionTableAdapter.Fill(this.medsDataSet1.Selection);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    //Will save to DataBase 
            //    this.genMedTableAdapter.Update(this.medsDataSet.GenMed);
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show(Convert.ToString(error.Message));
            //}
        }

        private void Select_Pt_Click_1(object sender, EventArgs e)
        {
            //Select any cell in the row and it will auto select the ID of the patient 
            int RowIndex = Select_box.CurrentCell.RowIndex;

            // This is a proof of concept to pick what ID is selected to bring up information for the Patient on other pages.
            MessageBox.Show(Convert.ToString(Select_box.Rows[RowIndex].Cells[2].Value)); // messagebox for debug
            var patientID = (Convert.ToString(Select_box.Rows[RowIndex].Cells[3].Value));
            var FirstName = (Convert.ToString(Select_box.Rows[RowIndex].Cells[2].Value));
            var LastName = (Convert.ToString(Select_box.Rows[RowIndex].Cells[1].Value));

            try
            {
                //Deselects prievious stuff
                //Sets Gen hist tab
                if (New_PatientTb.TabPages.Contains(Gen_Hist_Tb) == true)
                {
                    New_PatientTb.SelectedTab = Gen_Hist_Tb;
                }
                else
                {
                    this.New_PatientTb.TabPages.Add(Gen_Hist_Tb);  //re-adds tab
                    New_PatientTb.SelectedTab = Gen_Hist_Tb;
                    New_PatientTb.TabPages.Add(tabAllergies);
                }

                //Updates Top Name And ID Labels
                Patient_IdLbl.Text = "Patient ID: " + patientID;
                NameLbl1.Text = LastName + ",";
                NameLbl2.Text = FirstName;
                Patient_IDlbl2.Text = "Patient ID: " + patientID;
                Namelbl3.Text = LastName + ",";
                Namelbl4.Text = FirstName;

                // Inserts Data Into General Medical Table

                var MaritalStatus = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[3].Value));
                MaritalBox.Text = MaritalStatus;
                var AdmitReason = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[2].Value));
                AdmissionRichBox.Text = AdmitReason;
                var Height = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[4].Value));
                HeightBox.Text = Height;
                var Weight = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[5].Value));
                WeightBox.Text = Weight;
                var Smoker = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[6].Value));
                SmokerBox.Text = Smoker;
                var BloodType = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[7].Value));
                BloodBox.Text = BloodType;
                var BP = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[8].Value));
                PressBox.Text = BP;
                var Tobacco = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[9].Value));
                TobaccoBox.Text = Tobacco;
                var HR = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[10].Value));
                HeartBox.Text = HR;
                var Breathing = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[11].Value));
                BreathBox.Text = Breathing;
                var SurgHx = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[12].Value));
                SurgRichBox.Text = SurgHx;
                var behave = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[13].Value));
                BehaveBox.Text = behave;
                var drug = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[14].Value));
                DrugBox.Text = drug;
                var preg = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[15].Value));
                PregBox.Text = preg;
                var alcohol = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[16].Value));
                AlcoholBox.Text = alcohol;

                //Insert Data into Allergy Tab
                MedsBox.Text = (Convert.ToString(AllergyTable.Rows[RowIndex].Cells[2].Value));


            }
            catch(Exception error)
            {
                MessageBox.Show(Convert.ToString(error.Message));
            }
        }

        private void Save_Button_F1_Click(object sender, EventArgs e)
        {
            try
            {
                //Will save to DataBase 
                this.selectionTableAdapter.Update(this.medsDataSet1.Selection);
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error.Message));
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        ////private void CheckBtn_Click(object sender, EventArgs e)
        ////{
        ////    //TODO: Check if name exists, produce warning. check if ID exist, if it does do not unlock button and produce warning.

        ////    string FirstNameENT = FrstNmBx.Text;
        ////    string LastNameENT = LstNmBx.Text;
        ////    string IdENT = PtIdBx.Text;
        ////    int RowIndex = Select_box.CurrentCell.RowIndex;
        ////    bool checkedPassed1 = false;
        ////    bool checkedPassed2 = false;
        ////    string Existing_Patient = "";

        ////    if (checkedPassed1 != true)
        ////    {
        ////        for (int i = 0; i < Select_box.Rows.Count; i++)
        ////        {
                    
        ////            for (int j = 0; i < Select_box.Columns.Count; j++)
        ////            {
        ////                //MessageBox.Show(Select_box.Rows[i].Cells[j].Value.ToString());
        ////                Existing_Patient += Select_box.Rows[i].Cells[j].Value.ToString();
        ////                MessageBox.Show(Existing_Patient + " Fullstring");
        ////                if (Select_box.Rows[i].Cells[j].Value != null && FirstNameENT == Select_box.Rows[i].Cells[j].Value.ToString())
        ////                {
        ////                    MessageBox.Show("The value already existed in DataGridView.");
        ////                }
        ////            }
        ////        //}
        ////        //for (int i = 0; i < Select_box.Rows.Count; i++)
        ////        //{
        ////        //    for (int j = 0; i < Select_box.Columns.Count; j++)
        ////        //    {
        ////        //        if (Select_box.Rows[i].Cells[j].Value != null && LastNameENT == Select_box.Rows[i].Cells[j].Value.ToString())
        ////        //        {
        ////        //            MessageBox.Show("The value already existed in DataGridView.");
        ////        //        }
        ////        //    }
        ////        }

        ////    }




        ////        UpdateBtn.Enabled = true; //leave as last operation
        ////}

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void Patient_IdLbl_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void Gen_Hist_Tb_Click(object sender, EventArgs e)
        {

        }

        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            AdmissionRichBox.Enabled = true;
            MaritalBox.Enabled = true;
            HeightBox.Enabled = true;
            WeightBox.Enabled = true;
            SmokerBox.Enabled = true;
            BloodBox.Enabled = true;
            PressBox.Enabled = true;
            TobaccoBox.Enabled = true;
            HeartBox.Enabled = true;
            BreathBox.Enabled = true;
            SurgRichBox.Enabled = true;
            BehaveBox.Enabled = true;
            DrugBox.Enabled = true;
            PregBox.Enabled = true;
            AlcoholBox.Enabled = true;
        }

        private void Main_save_Click(object sender, EventArgs e)
        {
            this.selectionTableAdapter.Update(this.medsDataSet1.Selection);
        }
    }
}
