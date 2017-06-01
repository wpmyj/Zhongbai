using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using System.Net;
using System.IO;

namespace DasherStation.quality
{
    public partial class FrmQualitySystemFiles : BaseForm
    {
        string ftpServerIP;

        string ftpUserID;

        string ftpPassword;

        FtpWebRequest reqFTP;

        Icon fileIcon;


        public FrmQualitySystemFiles()
        {
            InitializeComponent();
        }

        private void FrmQualitySystemFiles_Load(object sender, EventArgs e)
        {
            this.ftpServerIP = "192.168.1.202";

            this.ftpUserID = "upload";

            this.ftpPassword = "upload";

            string[] FileList = GetFileList("ftp://" + ftpServerIP, WebRequestMethods.Ftp.ListDirectory);

            foreach (string str in FileList)
            {
                lvDetail.Items.Add(str);
            }
        }
        /*
       * 方法名称：GetFileList
       * 方法功能描述：示例了如何从ftp服务器上获得文件列表
       *
       * 创建人：夏阳明
       * 创建时间：200903011
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        private string[] GetFileList(string path, string WRMethods)
        {


            StringBuilder result = new StringBuilder();

            Connect(path);

            reqFTP.Method = WRMethods;

            WebResponse response = reqFTP.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);//中文文件名



            string line = reader.ReadLine();

            while (line != null)
            {

                result.Append(line);

                result.Append(" ");

                line = reader.ReadLine();

            }

            // to remove the trailing '' '' 

            result.Remove(result.ToString().LastIndexOf(' '), 1);

            reader.Close();

            response.Close();

            return result.ToString().Split(' ');


        }
        /*
       * 方法名称：Connect
       * 方法功能描述：连接ftp
       *
       * 创建人：夏阳明
       * 创建时间：200903011
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        private void Connect(String path)//
        {

            // 根据uri创建FtpWebRequest对象

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));

            // 指定数据传输类型

            reqFTP.UseBinary = true;

            // ftp用户名和密码

            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

        }

        /*
       * 方法名称：Upload
       * 方法功能描述：上传到ftp服务器指定目录下
       *
       * 创建人：夏阳明
       * 创建时间：200903011
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        private void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;

            Connect(uri);//连接          

            // 默认为true，连接不会被关闭

            // 在一个命令之后被执行

            reqFTP.KeepAlive = false;

            // 指定执行什么命令

            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // 上传文件时通知服务器文件的大小

            reqFTP.ContentLength = fileInf.Length;

            // 缓冲大小设置为kb 

            int buffLength = 2048;

            byte[] buff = new byte[buffLength];

            int contentLen;

            try
            {
                // 打开一个文件流(System.IO.FileStream) 去读上传的文件
                FileStream fs = fileInf.OpenRead();

                // 把上传的文件写入流

                Stream strm = reqFTP.GetRequestStream();

                // 每次读文件流的kb 

                contentLen = fs.Read(buff, 0, buffLength);

                // 流内容没有结束

                while (contentLen != 0)
                {
                    // 把内容从file stream 写入upload stream 

                    strm.Write(buff, 0, contentLen);

                    contentLen = fs.Read(buff, 0, buffLength);

                }
                // 关闭两个流

                strm.Close();

                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }

        }

        /*
         * 方法名称：Download
         * 方法功能描述：从ftp服务器下载到用户指定目录下
         *
         * 创建人：夏阳明
         * 创建时间：200903011
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool Download(string filePath, string fileName, out string errorinfo)
        {

            try
            {

                String onlyFileName = Path.GetFileName(fileName);

                string newFileName = filePath + "\\" + fileName;

                //if (File.Exists(newFileName))
                //{

                //    errorinfo = string.Format("本地文件{0}已存在,无法下载", newFileName);

                //    return false;

                //}

                string url = "ftp://" + ftpServerIP + "/" + fileName;

                Connect(url);//连接  

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                Stream ftpStream = response.GetResponseStream();

                long cl = response.ContentLength;

                int bufferSize = 2048;

                int readCount;

                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);

              //  MessageBox.Show(newFileName);

                FileStream outputStream = new FileStream(newFileName, FileMode.Create);

                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();

                outputStream.Close();

                response.Close();

                errorinfo = "";

                return true;

            }

            catch (Exception ex)
            {

                errorinfo = string.Format("因{0},无法下载", ex.Message);

                return false;

            }

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
                MessageBox.Show("上传文件为：" + openFileDialog1.FileName);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            this.Upload(this.textBox1.Text);
            lvDetail.Items.Clear();
            string[] FileList = GetFileList("ftp://" + ftpServerIP, WebRequestMethods.Ftp.ListDirectory);

            foreach (string str in FileList)
            {
                lvDetail.Items.Add(str);
            }
            this.textBox1.Text = "";
            MessageBox.Show("文件上传完毕！");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process Proc;

            //设置外部程序名
           // Info.FileName = "winword.exe";

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string errorinfo = "";

                Download(folderBrowserDialog1.SelectedPath, this.lvDetail.Text, out errorinfo);
                //建立Word类的实例,缺点:不能正确读取表格,图片等等的显示
                //Microsoft.Office.Interop.Word.ApplicationClass app = new Microsoft.Office.Interop.Word.ApplicationClass();
                //Microsoft.Office.Interop.Word.Document doc = null;
                //object missing = System.Reflection.Missing.Value;
                //object missing = Type.Missing;

                string FileName = folderBrowserDialog1.SelectedPath + "\\" + lvDetail.Text;
                Info.FileName = FileName;

                //object readOnly = false;
                //object isVisible = true;
                //object index = 0;
                //object savename = "C:\\";
                //设置外部程序的启动参数（命令行参数）为test.txt
                Info.Arguments = FileName.ToString();
                //设置外部程序工作目录为 C:\
                Info.WorkingDirectory = "C:\\";
                try
                {
                    Proc = System.Diagnostics.Process.Start(Info);
                    while (!Proc.HasExited)
                    {
                    }
                    Upload(FileName.ToString());
                    MessageBox.Show("文件已上传！");
                }
                finally
                {
                }
                //MessageBox.Show(errorinfo);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
    }
}
