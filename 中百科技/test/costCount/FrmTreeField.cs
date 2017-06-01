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
    public partial class FrmTreeField : BaseForm
    {
        private ArrayList fieldNames = new ArrayList();

        public ArrayList FieldNames
        {
            get { return fieldNames; }
            set { fieldNames = value; }
        }

        public FrmTreeField()
        {
            InitializeComponent();
        }

        private void FrmTreeField_Shown(object sender, EventArgs e)
        {
            for (int i=0;i<fieldNames.Count;i++)
            {
                checkedListBox1.Items.Add(fieldNames[i].ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fieldNames.Clear();
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fieldNames.Clear();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                fieldNames.Add(checkedListBox1.CheckedItems[i].ToString());
 
            }                

            this.DialogResult = DialogResult.Yes;
        }


    }
}
