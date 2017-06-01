using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using System.Collections;

namespace DasherStation.costCount
{
    public partial class FrmDirectnessManOption : BaseForm
    {
        private ArrayList nameFields = new ArrayList();


        public ArrayList NameFields
        {
            get { return this.nameFields; }
            set { this.nameFields = value; }
        }

      
        public FrmDirectnessManOption()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nameFields.Clear();
            this.DialogResult = DialogResult.Cancel;
        }
        private void FormInit()
        {
            ManExpenditureLogic logic = new ManExpenditureLogic();
            DataTable dt = new DataTable();

            dt = logic.SetProduceTeam();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString() + "_" + dt.Rows[i]["id"].ToString());
            }
            

        }

        private void FrmDirectnessManOption_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nameFields.Clear();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                nameFields.Add(checkedListBox1.CheckedItems[i].ToString());
            }          
            this.DialogResult = DialogResult.OK; 
        }

        
    }
}
