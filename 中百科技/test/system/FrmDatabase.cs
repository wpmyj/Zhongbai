/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmDatabase.cs
     * 文件功能描述：数据库维护窗体
     *
     * 创建人： 冯雪
     * 创建时间：2009-02-11
     *
     * 修改人：金鹤
     * 修改时间：20090303
     * 修改内容：功能实现
     *
     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace DasherStation.system
{
    public partial class FrmDatabase : common.BaseForm 
    {
        public FrmDatabase()
        {
            InitializeComponent();
        }

        DataBaseBackUp dataBaseBackUp;

        string DBname = "DasherStation";
        string path = @"i:\DasherBackUp\";

        private void btn_save_Click(object sender, EventArgs e)
        {
            string strFileName = DateTime.Now.ToString("yyyyMMddHHmmss")+".bak";
            
           
            this.Pbr.Visible = true;
            
            this.Cursor = Cursors.WaitCursor;
            if (dataBaseBackUp.BackUPDB(DBname, path + strFileName, this.Pbr))
            {
                MessageBox.Show("备份成功");
                listbind();
            }
            this.Cursor = Cursors.Default;
        }

        private void FrmDatabase_Load(object sender, EventArgs e)
        {
            this.Pbr.Visible = false;
            dataBaseBackUp = new DataBaseBackUp("192.168.1.202", "backup", "backup", "sa", "123");
            listbind();
        }

        private void listbind()
        {
            
            string[] FileList = dataBaseBackUp.GetFileList();

            lbx_backup.Items.Clear();
            foreach (string file in FileList)
            {
                this.lbx_backup.Items.Add(file);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {

            if (lbx_backup.SelectedIndex > -1)
            {
                this.Pbr.Visible = true;
                string filename = this.lbx_backup.SelectedItem.ToString();
                this.Cursor = Cursors.WaitCursor;
                if (dataBaseBackUp.RestoreDB(DBname, @"i:\DasherBackUp\" + filename, this.Pbr))
                {
                    MessageBox.Show("还原成功");
                }
            }
            else
            {
                MessageBox.Show("选择要还原的数据库");
            }
            this.Cursor = Cursors.Default;
        }

        private void btn_down_Click(object sender, EventArgs e)
        {

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string errorinfo;

                if (dataBaseBackUp.Download(folderBrowserDialog1.SelectedPath, this.lbx_backup.SelectedItem.ToString(), out errorinfo))
                {
                    MessageBox.Show("文件下载成功");
                }
                else
                {
                    MessageBox.Show(errorinfo);
                }
            }
        }



    }
}
