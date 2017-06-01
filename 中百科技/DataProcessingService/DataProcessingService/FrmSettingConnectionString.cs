using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DasherStation.DataProcessingService
{

    public partial class FrmSettingConnectionString : Form
    {
        public string InstallPath;
        public FrmSettingConnectionString()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.txtAddr.Text.Trim() == "" || this.txtUserID.Text.Trim() == "" || this.cboDatabaseName.Text.Trim() =="")
            {
                MessageBox.Show("数据库信息不整!");
                this.DialogResult = DialogResult.None;
                return;
            }
            string strConn = string.Format("server={0};uid={1};pwd={2};database={3}",
                        new string[]{
                        this.txtAddr.Text, 
                        this .txtUserID.Text, 
                        this.txtPwd.Text, 
                        this.cboDatabaseName.Text
                        });
            var appConfig = ConfigurationManager.OpenExeConfiguration(this.InstallPath);
            if (appConfig.ConnectionStrings.ConnectionStrings.OfType<ConnectionStringSettings>().Where(p=>p.Name == "DasherStationSqlConn").Count() ==0)
            {
                appConfig.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("DasherStationSqlConn", strConn));
                appConfig.Save(ConfigurationSaveMode.Modified);
            }
            this.Close();
        }

        private void cboDatabaseName_Enter(object sender, EventArgs e)
        {
            
                string strConn = string.Format("server={0};uid={1};pwd={2};database={3}", new string[] { this.txtAddr.Text, this.txtUserID.Text, this.txtPwd.Text, "master" });
                System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(strConn);
                System.Data.SqlClient.SqlCommand sqlcom = new System.Data.SqlClient.SqlCommand();
                sqlcom.Connection = sqlconn;
                sqlcom.CommandText = "select name from sysdatabases";
                System.Data.DataSet dtsResult = new DataSet();
                System.Data.SqlClient.SqlDataAdapter sqldta = new System.Data.SqlClient.SqlDataAdapter(sqlcom);
                try
                {
                    sqldta.Fill(dtsResult);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    cboDatabaseName.Items.Clear();
                    MessageBox.Show(ex.Message);
                    return;
                }
                cboDatabaseName.Items.Clear();
                foreach (System.Data.DataRow row in dtsResult.Tables[0].Rows)
                {
                    cboDatabaseName.Items.Add(row[0]);
                }
            
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            string strValue = this.cboDatabaseName.SelectedItem == null ? "" : this.cboDatabaseName.SelectedItem.ToString();
            string strConn = string.Format("server={0};uid={1};pwd={2};database={3}", new string[] { this.txtAddr.Text, this.txtUserID.Text, this.txtPwd.Text, "master"});
            System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(strConn);
            try
            {
                sqlconn.Open();
                if (sqlconn.State == System.Data.ConnectionState.Open)
                {
                   
                    string count = new System.Data.SqlClient.SqlCommand("select count(name) from sysdatabases where name= '" + strValue + "'", sqlconn).ExecuteScalar().ToString();
                    if (count != "0")
                    {
                        MessageBox.Show("连接成功!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("指定的数据库不存在!");
                    }
                }
                MessageBox.Show("连接失败!");
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(sqlconn.State != System.Data.ConnectionState.Closed)
                {
                    sqlconn.Close();
                }
            }
        }
    }
}
