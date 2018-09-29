using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using MD5Encrypt;

namespace MD5加密
{
    public partial class Form_ConfView : Form
    {

        #region 初始化

        string path = "";     //程序基目录
        string xmlpath = "";  //xml文件路径

        public Form_ConfView()
        {
            InitializeComponent();

            MD5Encrypt.DES.instance().sendLog += new delegateMD5SengLog(Form_ConfView_sendLog);
          
        }

        private void Form_ConfView_Load(object sender, EventArgs e)
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
            string[] rootFiles = Directory.GetFiles(path);    //当前目录下的文件
            try
            {
                foreach (string fileName in rootFiles)
                {
                    FileInfo file = new FileInfo(fileName);
                    try
                    {
                        if (file.Extension.Equals(".xml"))
                        {
                            xmlpath = fileName;
                            string[] s = xmlpath.Split(Path.DirectorySeparatorChar);
                            this.txtFileName.Text = s[s.Length - 1];
                            LoadFile(xmlpath);
                            break;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region 选择文件
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML文件(*.xml)|*.xml";
            ofd.Title = "请选择要查看的文件";
            ofd.DefaultExt = "xml";
            //ofd.InitialDirectory = path;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    xmlpath = ofd.FileName;
                    string[] s = xmlpath.Split(Path.DirectorySeparatorChar);
                    this.txtFileName.Text = s[s.Length - 1];
                    LoadFile(xmlpath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        #region 加密文件
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (this.txtFileName.Text == "")
                return;
            int count = Convert.ToInt32(this.numericUpDown1.Value);
            try
            {
                this.txtContent.Text = MD5Encrypt.DES.instance().EncryptXML(xmlpath, count);

                MD5Encrypt.DES.instance().SaveXml(xmlpath, this.txtContent.Text); //加密过后保存
                
                MessageBox.Show("加密文件成功!", "提示");
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("加密文件失败,请查看日志!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string exepath = AppDomain.CurrentDomain.BaseDirectory + "MD5_log.txt";

                    System.Diagnostics.Process.Start(exepath);
                }
            }
        }

        #endregion

        #region 解密文件

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (this.txtFileName.Text == "")
                return;
            int count = Convert.ToInt32(this.numericUpDown1.Value);

            try
            {
                this.txtContent.Text = MD5Encrypt.DES.instance().DecryptXML(xmlpath, count);

                //MessageBox.Show("解密文件成功!", "提示");
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("解密文件失败,请查看日志!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string exepath = AppDomain.CurrentDomain.BaseDirectory + "MD5_log.txt";

                    System.Diagnostics.Process.Start(exepath);
                }
            }
        }

        #endregion

        #region 保存修改
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtFileName.Text == "")
                return;
            try
            {

                MD5Encrypt.DES.instance().SaveXml(xmlpath, this.txtContent.Text);

                MessageBox.Show("保存文件成功!", "提示");
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("保存文件失败,请查看日志!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string exepath = AppDomain.CurrentDomain.BaseDirectory + "MD5_log.txt";

                    System.Diagnostics.Process.Start(exepath);
                }
            }
        }

        #endregion

        #region 打开文件
        private void LoadFile(string filepath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filepath, Encoding.UTF8))
                {
                    this.txtContent.Text = sr.ReadToEnd();

                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 写日志

        void Form_ConfView_sendLog(string strlog)
        {
                    string path_log = AppDomain.CurrentDomain.BaseDirectory + "MD5_log.txt";

            DateTime now = DateTime.Now;
            try
            {
                string log = now.ToString() + "\t" + strlog + Environment.NewLine;
                if (!File.Exists(path_log))
                {
                    using (StreamWriter sw = File.CreateText(path_log))
                    {
                        sw.Write(log);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path_log))
                    {
                        sw.Write(log);
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}