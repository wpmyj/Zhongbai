/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：Login.cs
      * 文件功能描述：拌合站信息管理系统登录界面
      *
      * 创建人：付中华
      * 创建时间：2009-02-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
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
using DasherStation;
using DasherStation.common;
using System.Reflection;

namespace DaxherStation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Assembly a;

        DataSet dsUserPurview;

        DataSet dsUserBtn;

        Index mainform;

        private void button1_Click(object sender, EventArgs e)
        {
           

            dsUserPurview = new SqlHelper().QueryForDateSet("select m.id,m.name,controlName,visible from menu m,userPopedomCorresponding up,usersInfo ui where m.type=1 and m.id=up.mid and up.uiid=ui.id and ui.username='admin'");

            mainform = new Index();

            SetPurview(mainform);

            this.Hide();

            DialogResult result = mainform.ShowDialog();
           
        }

        private void SetPurview(Form frm)
        {
            foreach (object obj in frm.Controls)
            {
                MenuStrip msp = obj as MenuStrip;
                if (msp != null)
                {
                    foreach (ToolStripMenuItem tmi in msp.Items)
                    {
                        GetItem(tmi);

                    }
                }
            }
        }

        private void GetItem(ToolStripMenuItem Tm)
        {
            Tm.Click += new System.EventHandler(OpenFrm);
            if (dsUserPurview.Tables[0].Select("controlName='" +Tm.Name+"'").Count() > 0)
            {
                Tm.Visible = true;
                Tm.Enabled = true;
            }
            else
            {
                //Tm.Visible = false;
                Tm.Enabled = true;
                //默认菜单可见
               
            }
            foreach (object obj in Tm.DropDownItems)
            {
                ToolStripMenuItem tmi = obj as ToolStripMenuItem;
                if (tmi != null)
                {
                    GetItem(tmi);
                }
            }
        }

        private void OpenFrm(object sender, EventArgs e)
        {
            ToolStripMenuItem tmi = sender as ToolStripMenuItem;
            dsUserBtn = new SqlHelper().QueryForDateSet("select m.id,m.name,controlName,visible from menu m,userPopedomCorresponding up,usersInfo ui where m.type=2 and m.id=up.mid and up.uiid=ui.id and parentId=(select top 1 id from menu where controlName='" + tmi.Name + "')");
            if(tmi!=null&&tmi.Tag!=null&&!string.IsNullOrEmpty(tmi.Tag.ToString()))
            {
                OpenFrm(tmi.Tag.ToString(),mainform);
                
            }
        }

        private void OpenFrm(string formName, Form parentForm)
        {
            a = Assembly.GetExecutingAssembly();
            Type frmType = GetFrmType(formName);

            BaseForm frm = Activator.CreateInstance(frmType) as BaseForm;

            if (frm != null)
            {

                frm.UserName = "Test";
                //在父窗口中查找是否已经打开与待打开的窗体相同的窗体
                foreach (BaseForm f in parentForm.MdiChildren)
                {
                    //如果存在，则销毁新建的窗体，引用已经打开的窗体引用
                    if (f.Name == frm.Name)
                    {
                        frm.Dispose();
                        frm = f;
                        break;
                    }
                }

                GetControls(frm);

                //调整显示效果
                frm.MdiParent = parentForm;
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
                frm.Show();
            }

        }

        private Type GetFrmType(string FrmName)
        {
            foreach (Type t in a.GetTypes())
            {
                if (t.Name.ToLower().ToString() == FrmName.ToLower())
                    return t;
            }
            return null;
        }

        private void GetControls(object obj)
        {
            Form frm = obj as Form;
            if (frm != null)
            {
                foreach (object inFrmObj in frm.Controls)
                {
                    GetControls(inFrmObj);
                }         
            }

            Button btn = obj as Button;
            if (btn != null)
            {
                CheckBtn(btn);
            }

            GroupBox gbx = obj as GroupBox;
            if (gbx != null)
            {
                foreach (object inGbxObj in gbx.Controls)
                {
                    GetControls(inGbxObj);
                }
            }

            Panel pal = obj as Panel;
            if (pal != null)
            {
                foreach (object inPalObj in pal.Controls)
                {
                    GetControls(inPalObj);
                }
            }

            TabControl tcl = obj as TabControl;
            if (tcl != null)
            {
                foreach (TabPage tp in tcl.TabPages)
                {
                    foreach (object inTpObj in tp.Controls)
                    {
                        GetControls(inTpObj);
                    }
                }
            }
        }

        private void CheckBtn(Button btn)
        {
            if (dsUserBtn.Tables[0].Select("controlName='" + btn.Name + "'").Count() > 0)
            {
                btn.Visible = true;
                btn.Enabled = true;
            }
            else
            {
                //btn.Visible = false;
                btn.Enabled = true;
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        
        
    }
}
