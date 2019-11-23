using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace WebStreamApi
{
    public partial class FormDB : System.Web.UI.Page
    {
        private string msg, title;
        private string strconn =
                "Data Source= 서버 이름, DB 이름; 서버 아이디 비밀번호";
                            
        SqlConnection conn; // sql 연결 변수 생성
        private string pathDir;
        private string fileNm;
        protected void Page_Load(object sender, EventArgs e)
        {
           
             //메인 메뉴로 돌아가는 버튼
            Back.PostBackUrl = "~/FormMenu.aspx";
        }

       
        //데이터베이스와 프로젝트가 연결되었는지 확인하는 방법
        protected void Conn_btn_Click(object sender, EventArgs e)
        {
           using(conn = new SqlConnection(strconn))
            {
                //위의 using 부분에서 null 이 아니면 
                if (conn != null)
                {
                    conn.Open();
                    msg += "연결되었습니다.";
                    title = "연결";
                    MessageBox.Show(msg, title);
                }
                //null 일 경우
                else
                {
                    conn.Close();
                    msg += "연결되지 않았습니다.";
                    title = "연결";
                    MessageBox.Show(msg, title);
                }
            }
        }


        //FormStream.apsx.cs 부분 참조
        protected void Local_Data_Click(object sender, EventArgs e)
        {
            FileUpLoad.Items.Clear();
            pathDir = Server.MapPath("가상 경로");
            DirectoryInfo di = new DirectoryInfo(pathDir);
            foreach(FileInfo fi in di.GetFiles())
            {
                if (fi.Exists)
                {
                    string FileNm = fi.Name.Substring(0, fi.Name.Length - 4);
                    FileUpLoad.Items.Add(FileNm);
                }
                else
                {
                    msg += "파일이 존재하지 않습니다.";
                    title = "경고";
                    MessageBox.Show(msg, title);
                }
            }

        }

        protected void FileUpLoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //리스트박스에서 선택한 값을 문자열로 변수 지정
           fileNm = FileUpLoad.SelectedValue.ToString();
         }

        //파일 경로에 있는 파일들을 데이터베이스로 저장하기
        protected void Save_DB_Data_Click(object sender, EventArgs e)
        {
            pathDir = Server.MapPath("가상 경로"); //상대 경로
            conn = new SqlConnection(strconn);  //SQL 연결
            string[] files = Directory.GetFiles(pathDir); // 경로 안의 파일을 배열로 생성

            try
            {
                SqlCommand sqlcmd = new SqlCommand(); // SQL 커맨드 설정 
                sqlcmd.Connection = conn; //SQL 커맨드 연결
                conn.Open();

                foreach (string filename in files)
                {
                    // 파일의 정보를 찾아줌
                    FileInfo fi = new FileInfo(filename);

                   
                    //쿼리문 작성시 컴퓨터 시간이 AM,PM으로 인해 작동이 안되어서 컴퓨터 시간 변경후 사용
                    sqlcmd.CommandText = "INSERT INTO LocalData(";
                    sqlcmd.CommandText += " [FileNm] , [FileCrd], [FileLwd] )";
                    sqlcmd.CommandText += "VALUES('" +
                                        fi.Name.Substring(0, fi.Name.Length - 4) + "','"
                                        + fi.CreationTime.ToString() + "','"
                                        + fi.LastWriteTime.ToString() + "')";
                  

                    //쿼리문을 데이터베이스로 연결함
                    sqlcmd.ExecuteNonQuery();
                }
                msg += "저장되었습니다.";
                title = "저장";
                MessageBox.Show(msg, title);
                conn.Close();
            }
            catch
            {
                msg += "저장된 데이터를 불러오지 못했습니다.\n" +
                   " 데이터베이스를 확인해주셨으면 합니다.";
                title = "경고";
                MessageBox.Show(msg, title);
                conn.Dispose();
               
            }
         }

        //저장되어진 DB 테이블 불러오기
        protected void Load_DB_Data_Click(object sender, EventArgs e)
        {
            //쿼리문 작성한 변수 생성, SQL 데이터 읽어오는 변수 지정
            string qurey = "Select * from LocalData ";
            SqlDataReader sqldr;
            try
            {
                //conn 으로 연결
                conn = new SqlConnection(strconn);
                conn.Open();
                //지정된 연결, 작성, 읽은 변수 생성
                SqlCommand Loadcmd = new SqlCommand();
                Loadcmd.Connection = conn;
                Loadcmd.CommandText = qurey;
                //데이터 형식은 텍스트 형식으로
                Loadcmd.CommandType = CommandType.Text;
                sqldr = Loadcmd.ExecuteReader();

                //데이터 바인드를 해준다. 소스하고 겹쳐지기 때문에 하나만 쓴다.
                // 시작할때 안보이게 한다.
                /*this.GridView1.DataSource = sqldr;*/
                this.GridView1.DataBind();
                this.GridView1.Visible = true;

                msg += "저장된 데이터 불러왔습니다.";
                title = "불러오기";
                MessageBox.Show(msg, title);

                conn.Close();
            }
            catch
            {
                msg += "저장된 데이터를 불러오지 못했습니다.\n" +
                    " 데이터베이스를 확인해주셨으면 합니다.";
                title = "경고";
                MessageBox.Show(msg, title);
                conn.Dispose();
            }
        }

        protected void Add_Data_Click(object sender, EventArgs e)
        {
            
            pathDir = Server.MapPath("가상 경로"); //상대 경로 
            string[] pathfileAdd = Directory.GetFiles(pathDir, "*.txt"); //string 배열롤 생성
            FileInfo finfo = new FileInfo(fileNm); // 파일 정보 불러오는 변수 생성
            
            try
            {
                //SQL 연결, SQLCMD 연결
                conn = new SqlConnection(strconn);
                SqlCommand sqlcmdAdd = new SqlCommand();
                sqlcmdAdd.Connection = conn;;
                conn.Open();

                sqlcmdAdd.Connection = conn;
                //배열 만큼 for문 사용
                for(int i=0; i<pathfileAdd.Length; i++)
                {
                    //리스트 박스에서 선택시
                    if (FileUpLoad.Items[i].Selected)
                    {
                       //선택한 값을 불러온다
                      foreach(string addfile in pathfileAdd)
                        {
                            sqlcmdAdd.CommandText = "insert into LocalData( [FileNm], [Nowtime] )" +
                                "Values ('" + finfo.Name + "','"+DateTime.Now.ToString()+ "')";
                        }
                        sqlcmdAdd.ExecuteNonQuery();
                    }
                }
                msg += "테이블에 파일 하나 저장되었습니다.";
                title = "추가";
                MessageBox.Show(msg, title);
                GridView1.DataBind();
                conn.Close();
            }
            catch
            {

                msg += "테이블에 저장되어 있지 않습니다.\n" +
                   " 데이터베이스를 확인해주셨으면 합니다. ";
                title = "경고";
                MessageBox.Show(msg, title);
                GridView1.DataBind();
                conn.Dispose();
            }
        }

        protected void Modifiy_Click(object sender, EventArgs e)
        {
            try
            {
                //sql 연결 
                conn = new SqlConnection(strconn);
                //sql 커멘드 설정, 커멘드 연결
                SqlCommand sqlMod = new SqlCommand();
                sqlMod.Connection = conn;
                conn.Open();

                //그리드뷰의 열 만큼 카운터를 센다.
                for(int i=0; i<GridView1.Rows.Count; i++)
                {   //체크박스를 설정해줌
                   CheckBox cbmod = (CheckBox)GridView1.Rows[i].Cells[6].FindControl("Checkedbox");
                    //true 이면 id 값을 설정한 기준으로 이름과 수정날짜를 표기
                    if (cbmod.Checked)
                   {
                        //Modekey 는 id 값을 문자열을 int32롤 변환해주는 방식
                       int Modkey = Convert.ToInt32(GridView1.DataKeys[i].Value) ;
                       sqlMod.CommandText = "Update LocalData set FileNm='" + Content.Text
                                             + "',modifiy ='" + DateTime.Now.ToString() +
                                               "'where id='" + Modkey.ToString() + "'";

                       sqlMod.ExecuteNonQuery();
                    }
                    
                }
                msg += "테이블 파일이름 변경되었습니다.";
                title = "수정하기";
                MessageBox.Show(msg, title);
                GridView1.DataBind(); // 실행되고 나서 페이지 리로딩 될때 화면에 바로 띄어줌.
                conn.Close();
            }
            catch
            {
                msg += "테이블에 저장되어 있지 않습니다.\n" +
                  " 데이터베이스를 확인해주셨으면 합니다. ";
                title = "경고";
                MessageBox.Show(msg, title);
                GridView1.DataBind();
                conn.Dispose();
            }            
            
        }

        protected void Delete_DB_Data_Click(object sender, EventArgs e)
        {
             
            try
            {   //sql 연결
                conn = new SqlConnection(strconn);
                SqlCommand sqlDel = new SqlCommand(); //sql 커멘드 설정
                sqlDel.Connection = conn; // sql 커맨드 sql연결
                conn.Open();

                //modifiy 와 용도는 같지만 다른 문장을 사용
                foreach (GridViewRow rowDel in GridView1.Rows)
                {
                    //체크박스 설정
                    CheckBox cbDel = (CheckBox)rowDel.FindControl("checkedbox");
                    //cbDel이 null이 아니고
                    if (cbDel != null)
                    {
                        //cbDel이 체크한게 true이면 쿼리문 실행 
                       if (cbDel.Checked == true)
                       {
                            //Delkey는 id를 문자열을 숫자로 변환해주는 방식.
                            int Delkey = Convert.ToInt32(GridView1.DataKeys[rowDel.RowIndex].Value);
                            sqlDel.CommandText = "Delete from LocalData where id ='" + Delkey.ToString() + "'";
                            sqlDel.ExecuteNonQuery();

                        }
                        
                    }
                   
                }
                msg += "테이블의 열을 지웠습니다.";
                title = "삭제하기";
                MessageBox.Show(msg, title);
                GridView1.DataBind(); //페이지 리로딩 될때 지워지 데이터를 제외한 나머지 데이터 불러온다.
                conn.Close();
            }
            catch
            {
                msg += "테이블에 저장되어 있지 않습니다.\n" +
                  " 데이터베이스를 확인해주셨으면 합니다. ";
                title = "경고";
                MessageBox.Show(msg, title);
                GridView1.DataBind();
                conn.Dispose();
            }
         }
    }

}