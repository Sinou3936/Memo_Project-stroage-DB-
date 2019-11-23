using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebStreamApi
{
    public partial class FormStorage : System.Web.UI.Page
    {
        private string StringValue;
        private string msg, title;
        private string pathDir, pathfile;
        private string filename;
        private string new_data;
        protected void Page_Load(object sender, EventArgs e)
        {
            Exit.PostBackUrl = "~/FormMenu.aspx";
        }

        protected void Stream_TextChanged(object sender, EventArgs e)
        {
            StringValue = Stream.Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Stream.Text = null;
            filename = "Memo.txt";
            pathDir = Server.MapPath("가상 경로");
            pathfile = Server.MapPath("가상 경로" + filename);
            DirectoryInfo dirinfo = new DirectoryInfo(pathfile);
            string[] filecon = File.ReadAllLines(pathfile);

            if((StringValue !=null) && (StringValue.Length != 0))
            {
                if (dirinfo.Exists) { dirinfo.Create();}

                if (!File.Exists(pathfile))
                {
                    using (StreamWriter sw = File.CreateText(pathfile))
                    {
                        new_data = StringValue;
                        sw.WriteLine(new_data);
                        sw.Close();

                        msg = "저장되었습니다.";
                        title = "저장";
                        MessageBox.Show(msg, title);
                    }
                }
                else
                {
                    using(StreamWriter sw = File.AppendText(pathfile))
                    {
                        if(filecon.Length != 0)
                        {
                            for(int i=0; i<filecon.Length; i++)
                            {
                                if(StringValue == filecon[i])
                                {
                                    StringValue = string.Empty;
                                }
                            }
                            new_data = StringValue;
                            sw.WriteLine(new_data);
                            sw.Close();
                            if(StringValue == "")
                            {
                                msg = "동일한 값이 있습니다.";
                                title = "경고";
                                MessageBox.Show(msg, title);
                            }
                            else
                            {
                                msg = "새로운 값이 추가되었습니다.";
                                title = "추가";
                                MessageBox.Show(msg, title);
                            }
                        }
                        else
                        {
                            new_data = StringValue;
                            sw.WriteLine(new_data);
                            sw.Close();
                            msg = "추가되었습니다.";
                            title = "추가";
                            MessageBox.Show(msg, title);
                        }
                    }
                }
            }
            else
            {
                msg = "스캔이 필요합니다.";
                title = "경고";
                MessageBox.Show(msg, title);
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFile.Items.Clear();
            pathDir = Server.MapPath("~/DataStorage");

            DirectoryInfo di = new DirectoryInfo(pathDir);
            foreach(FileInfo fi in di.GetFiles())
            {
                if (fi.Extension.ToLower().CompareTo(".txt") == 0)
                {
                    string FileNmOnly = fi.Name.Substring(0, fi.Name.Length - 4);
                    LoadFile.Items.Add(FileNmOnly);
                }
            }
            msg = "폴더 안의 파일들을 불러왔습니다.";
            title = "불러오기";
            MessageBox.Show(msg, title);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if((StringValue !=null) && (StringValue.Length != 0))
            {
                if (IsPostBack)
                {
                    Stream.Text = null;
                    msg = "삭제되었습니다.";
                    title = "삭제";
                    MessageBox.Show(msg, title);
                }
                else
                {
                    msg = "삭제할 내용이 없습니다.";
                    title = "경고";
                    MessageBox.Show(msg, title);
                }
            }
        }

        protected void LoadFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            filename = LoadFile.SelectedValue.ToString();
        }

        protected void LoadContent_Click(object sender, EventArgs e)
        {
            Content.Items.Clear();
            pathDir = Server.MapPath("~/DataStorage");
            string[] filecon = Directory.GetFiles(pathDir, "*.txt");

            for(int i=0; i<filecon.Length; i++)
            {
                if (LoadFile.Items[i].Selected)
                {
                    StreamReader sr = new StreamReader(filecon[i]);
                    foreach(string str in sr.ReadToEnd().Split('\n'))
                    {
                        Content.Items.Add(str.Replace('\r', ' '));
                        sr.Close();
                    }
                }
            }
            msg = "선택된 파일의 내용을 불러옵니다.";
            title = "불러오기";
            MessageBox.Show(msg, title);
        }

        protected void AllClear_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LoadFile.Items.Clear();
                Content.Items.Clear();
            }

        }

        protected void Exit_Click(object sender, EventArgs e)
        {

        }
    }
}