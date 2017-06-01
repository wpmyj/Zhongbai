using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.quality
{
    public partial class FrmInspectingfrequencyUpdate : common.BaseForm
    {
        MaterialTestGuidelineClass MTGDC;

        QualityLogic qualityLogic = new QualityLogic();

        public MaterialTestGuidelineClass MTGDC1
        {
            get { return MTGDC; }
            set { MTGDC = value; }
        }

        public FrmInspectingfrequencyUpdate()
        {
            InitializeComponent();
        }

        private void FrmInspectingfrequencyUpdate_Load(object sender, EventArgs e)
        {
            cbxKinds.Text = MTGDC.Sort;
            cbxName.Text = MTGDC.Name;
            cbxModel.Text = MTGDC.Model;
            cbxTestGuideline.Text = MTGDC.TestGuideline;

            qualityLogic.InitialcbxFrequency(cbxFrequency);
            cbxFrequency.DisplayMember = "frequency";
            cbxFrequency.SelectedIndex = -1;

            qualityLogic.InitialcbxGuideline(cbxGuideline);
            cbxGuideline.DisplayMember = "eligibilityGuideline";
            cbxGuideline.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MTGDC.Remark = txtRemark.Text;
            MTGDC.Guideline = cbxGuideline.Text;
            MTGDC.Frequency = cbxFrequency.Text;

            if (qualityLogic.FrmInspectingfrequencyUpdateSave(MTGDC))
            {
                this.Close();
                MessageBox.Show("更新成功");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
