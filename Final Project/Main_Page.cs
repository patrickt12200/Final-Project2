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


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medsDataSet.GenMed' table. You can move, or remove it, as needed.
            this.genMedTableAdapter.Fill(this.medsDataSet.GenMed);
            // TODO: This line of code loads data into the 'medsDataSet.Selection' table. You can move, or remove it, as needed.
            this.selectionTableAdapter.Fill(this.medsDataSet.Selection);
            // TODO: This line of code loads data into the 'medsDataSet.Allergies' table. You can move, or remove it, as needed.
            this.allergiesTableAdapter.Fill(this.medsDataSet.Allergies);
            

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
            GenMedTable.Visible = false;
            AllergyTable.Visible = false;

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
            TimeLbl2.Text = time;
            TimeLbl3.Text = time;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

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
                
                var AdmitReason = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[2].Value));
                AdmissionRichBox.Text = AdmitReason;

                var MaritalStatus = (Convert.ToString(GenMedTable.Rows[RowIndex].Cells[3].Value));
                MaritalBox.Text = MaritalStatus;

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
                MedsBox.Text = (Convert.ToString(AllergyTable.Rows[RowIndex].Cells[1].Value));
                FoodsBox.Text = (Convert.ToString(AllergyTable.Rows[RowIndex].Cells[2].Value));
                AllergenCommentBox.Text = (Convert.ToString(AllergyTable.Rows[RowIndex].Cells[3].Value));

                if(GenMedTable.Rows[RowIndex].Cells[2].Value == null)
                {
                    GenMedTable.Rows.Add(RowIndex);
                }


            }
            catch(Exception error)
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

        private void Patient_IdLbl_Click(object sender, EventArgs e)
        {

        }

        private void Gen_Hist_Tb_Click(object sender, EventArgs e)
        {

        }

        private void ModifyBtn_Click(object sender, EventArgs e)
        {

            AdmissionRichBox.ReadOnly = false;
            AdmissionRichBox.Enabled = true;

            MaritalBox.ReadOnly = false;
            MaritalBox.Enabled = true;

            HeightBox.ReadOnly = false;
            HeightBox.Enabled = true;

            WeightBox.ReadOnly = false;
            WeightBox.Enabled = true;

            SmokerBox.ReadOnly = false;
            SmokerBox.Enabled = true;

            BloodBox.ReadOnly = false;
            BloodBox.Enabled = true;

            PressBox.ReadOnly = false;
            PressBox.Enabled = true;

            TobaccoBox.ReadOnly = false;
            TobaccoBox.Enabled = true;

            HeartBox.ReadOnly = false;
            HeartBox.Enabled = true;

            BreathBox.ReadOnly = false;
            BreathBox.Enabled = true;

            SurgRichBox.ReadOnly = false;
            SurgRichBox.Enabled = true;

            BehaveBox.ReadOnly = false;
            BehaveBox.Enabled = true;

            DrugBox.ReadOnly = false;
            DrugBox.Enabled = true;

            PregBox.ReadOnly = false;
            PregBox.Enabled = true;

            AlcoholBox.ReadOnly = false;
            AlcoholBox.Enabled = true;
        }

        private void Main_save_Click(object sender, EventArgs e)
        {
            try
            {
                this.selectionTableAdapter.Update(this.medsDataSet.Selection);
                //this.genMedTableAdapter.Update(this.medsDataSet.GenMed);

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medsDataSet.Allergies' table. You can move, or remove it, as needed.
            this.allergiesTableAdapter.Fill(this.medsDataSet.Allergies);
            // TODO: This line of code loads data into the 'medsDataSet.GenMed' table. You can move, or remove it, as needed.
            this.genMedTableAdapter.Fill(this.medsDataSet.GenMed);
            // TODO: This line of code loads data into the 'medsDataSet.Selection' table. You can move, or remove it, as needed.
            this.selectionTableAdapter.Fill(this.medsDataSet.Selection);
            this.New_PatientTb.TabPages.Remove(Gen_Hist_Tb);
            this.New_PatientTb.TabPages.Remove(tabAllergies);



        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
           while( i != 30)
            {
                genMedTableAdapter.Update(medsDataSet.GenMed);

                selectionTableAdapter.Update(medsDataSet.Selection);

                allergiesTableAdapter.Update(medsDataSet.Allergies);
                i += 1;
            } 
           

        }

        private void GenMedSave_Click(object sender, EventArgs e)
        {

            try
            {
                //Will save to DataBase 
                int RowIndex = Select_box.CurrentCell.RowIndex;
                GenMedTable.Rows[RowIndex].Cells[2].Value = AdmissionRichBox.Text;
                //MessageBox.Show(RowIndex + AdmissionRichBox.Text);
                GenMedTable.Rows[RowIndex].Cells[3].Value = MaritalBox.Text;
                GenMedTable.Rows[RowIndex].Cells[4].Value = HeightBox.Text;
                GenMedTable.Rows[RowIndex].Cells[5].Value = WeightBox.Text;
                GenMedTable.Rows[RowIndex].Cells[6].Value = SmokerBox.Text;
                GenMedTable.Rows[RowIndex].Cells[7].Value = BloodBox.Text;
                GenMedTable.Rows[RowIndex].Cells[8].Value = PressBox.Text;
                GenMedTable.Rows[RowIndex].Cells[9].Value = TobaccoBox.Text;
                GenMedTable.Rows[RowIndex].Cells[10].Value = HeartBox.Text;
                GenMedTable.Rows[RowIndex].Cells[11].Value = BreathBox.Text;
                GenMedTable.Rows[RowIndex].Cells[12].Value = SurgRichBox.Text;
                GenMedTable.Rows[RowIndex].Cells[13].Value = BehaveBox.Text;
                GenMedTable.Rows[RowIndex].Cells[14].Value = DrugBox.Text;
                GenMedTable.Rows[RowIndex].Cells[15].Value = PregBox.Text;
                GenMedTable.Rows[RowIndex].Cells[16].Value = AlcoholBox.Text;


                //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                int i = 0;
                while ( i!= 30)
                {
                    genMedTableAdapter.Update(medsDataSet.GenMed);
                    i += 1;
                }
                
       




            }

            catch (Exception error)
            {
                MessageBox.Show("Update failed");
                MessageBox.Show(Convert.ToString(error.Message));
            }
        }

        private void Allergy_Save_Click(object sender, EventArgs e)
        {
            int RowIndex = Select_box.CurrentCell.RowIndex;

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
            this.AllergyTable.Rows[RowIndex].Cells[1].Value = MedsBox.Text;
            this.AllergyTable.Rows[RowIndex].Cells[2].Value = FoodsBox.Text;
            this.AllergyTable.Rows[RowIndex].Cells[3].Value = AllergenCommentBox.Text;

            //allergiesTableAdapter.Update(medsDataSet.Allergies);
            //allergiesTableAdapter.Update(medsDataSet.Allergies);
            //allergiesTableAdapter.Update(medsDataSet.Allergies);
            //allergiesTableAdapter.Update(medsDataSet.Allergies);
            //allergiesTableAdapter.Update(medsDataSet.Allergies);
            //allergiesTableAdapter.Update(medsDataSet.Allergies);

            int i = 0;
            while (i != 30)
            {
                allergiesTableAdapter.Update(medsDataSet.Allergies);
                i += 1;
            }

        }

        private void Search_Click(object sender, EventArgs e)
        {
            string IdENT = ID_Search.Text;

            bool checkedPassed1 = false;
            bool checkedPassed2 = false;
            string Existing_Patient = "";

            //MessageBox.Show(Convert.ToString(IdENT));

            if (Convert.ToInt32(IdENT) <= (Select_box.Rows.Count -2))
            {
                if (checkedPassed1 != true)
                {
                    for (int i = 0; i <= Select_box.Rows.Count;)
                    {

                        //MessageBox.Show(Select_box.Rows[i].Cells[j].Value.ToString());
                        try
                        {
                            if (IdENT == Select_box.Rows[i].Cells[3].Value.ToString())
                            {
                                Existing_Patient += Select_box.Rows[i].Cells[3].Value.ToString();
                                MessageBox.Show("Found Patient:" + Existing_Patient);
                                Select_box.ClearSelection();
                                Select_box.Rows[i].Selected = true;

                                checkedPassed1 = true;
                                break;
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("ID: " + IdENT + " Does not exist");
                            //MessageBox.Show(Convert.ToString(err.Message));
                            break;
                        }
                        i++;

                        //}
                        //for (int i = 0; i < Select_box.Rows.Count; i++)
                        //{
                        //    for (int j = 0; i < Select_box.Columns.Count; j++)
                        //    {
                        //        if (Select_box.Rows[i].Cells[j].Value != null && LastNameENT == Select_box.Rows[i].Cells[j].Value.ToString())
                        //        {
                        //            MessageBox.Show("The value already existed in DataGridView.");
                        //        }
                        //    }
                    }

                }
                else
                {
                    MessageBox.Show("ID does not exist!");
                }
            }
            else
            {
                MessageBox.Show("That Value is too high or is not a valid character!");
            }
           
        }
    }
}
