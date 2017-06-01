/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：About.cs
      * 文件功能描述：关于界面
      *
      * 创建人：付中华
      * 创建时间：2009-02-14
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DasherStation
{
    partial class About : common.BaseForm 
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("关于 {0}", AssemblyTitle);
            this.product.Text = AssemblyProduct;
            this.version.Text = String.Format("版本 {0} ", AssemblyVersion);
            this.copyright.Text = AssemblyCopyright;
            this.company.Text = AssemblyCompany;

            //string path = Application.StartupPath + "\\AboutUs.txt";
            //System.IO.StreamReader reader = new System.IO.StreamReader(path, System.Text.Encoding.Default);
            //this.txtAboutUs.Text = reader.ReadToEnd();
            //reader.Close();
            this.txtAboutUs.Text = "   中百科技有限公司是一家以计算机软件技术为核心的高科技企业，多年来始终致力于行业管理软件开发、数字化出版物制作、计算机网络系统综合应用以及行业电子商务网站开发领域，涉及生产管理、控制、仓储、物流、营销、服务等行业。公司拥有软件开发和项目实施方面的资深专家和学习型技术团队，多年来积累了丰富的技术文档和学习资料，公司的开发团队不仅是开拓进取的技术实践者，更致力于成为技术的普及和传播者。" +

                        //"\n" + "  公司网址：http://www.zoby.cn" +
                     "\n"+ " 联系电话：024-84978981或024-84978982" +
                   "\n"+"联系地址：辽宁省沈阳市文萃路81号";
        }
        //属性访问
        public string AssemblyTitle
        {
            get
            {
                object[] title = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                AssemblyTitleAttribute titleA=(AssemblyTitleAttribute)title[0];
                return titleA.Title;
             }
        }
        public string AssemblyProduct
        {
            get
            {
                object[] product = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                AssemblyProductAttribute productA = (AssemblyProductAttribute)product[0];
                
                return productA.Product;
            }
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string AssemblyCopyright
        {
            get
            {
                object[] copyright = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                AssemblyCopyrightAttribute copyrightA = (AssemblyCopyrightAttribute)copyright[0];
                
                return copyrightA.Copyright;
            }
        }
        public string AssemblyCompany
        {
            get
            {
                object[] company = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                AssemblyCompanyAttribute companyA = (AssemblyCompanyAttribute)company[0];
                
                return companyA.Company;
            }
        }

        

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    
    }
}
