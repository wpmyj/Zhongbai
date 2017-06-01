using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmProjectNameUpdate : BaseForm
    {
        public FrmProjectNameUpdate()
        {
            InitializeComponent();
        }

        private projectName model;

        public projectName Model
        {
            get { return model; }
            set { model = value; }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (new FormHelper().inputCheck(this.groupBox1))
            {
                Model.itemProject = this.txt_itemProject.Text.Trim();

                Model.name = this.txt_name.Text.Trim();

                Model.no = this.txt_no.Text.Trim();

                Model.position = this.txt_position.Text.Trim();

                Model.subsectionProject = this.txt_subsectionProject.Text.Trim();

                Model.unitProject = this.txt_unitProject.Text.Trim();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmProjectNameUpdate_Load(object sender, EventArgs e)
        {
            if (Model != null)
            {
                this.txt_itemProject.Text= Model.itemProject;

                this.txt_name.Text=Model.name;

                this.txt_no.Text = Model.no;

                this.txt_position.Text=Model.position;

                this.txt_subsectionProject.Text=Model.subsectionProject;

                this.txt_unitProject.Text=Model.unitProject;
            }
        }


    }
}
