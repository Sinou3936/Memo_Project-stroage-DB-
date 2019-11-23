<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormDB.aspx.cs" Inherits="WebStreamApi.FormDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DBStorage</title>
    
    <style>
        #Save_DB_Data{width:100%; height:12vh;}
        #Local_Data,#Add_Data{width:100%; height:10vh;}
        #Load_DB_Data,#Delete_DB_Data{width:100%; height:5vh;}
        #Modifiy,#Content{width:100%; height:12vh;}

        #FileUpLoad{width:100%;}
        #GridView1{text-align:center; 
                   margin-left :auto;
                   margin-right:auto;
        }
        table{
            width: 100%;
           
            
        }
        table,th,td{
            border : 3px solid black;
        }
     
        
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
           <!-- <center>
                <asp:Label ID="Connect" runat="server" Text="DB Connecting? Y/N" Font-Size="Large"></asp:Label>
            </center>
            <center>
                <asp:Button ID="Conn_btn" runat="server" Text="연결" Font-Size="Large" OnClick="Conn_btn_Click"></asp:Button>
                <asp:Label ID="Reuslt" runat="server" Text="" Font-Size="Large"></asp:Label>
            </center>
            <br/>  -->
            <table>
                
                    <thead>
                        <th colspan="2"><h2>DataBase 연동</h2></th>
                            <td width="10%">
                            <asp:Button ID="Save_DB_Data" runat="server" Text="Save_DB" OnClick="Save_DB_Data_Click"/>
                                </td>
                    </thead>

                    <tbody>
                            <tr>
                                <td  width="5%" align="left">
                                    <asp:Button ID="Local_Data" runat="server" Text="Local" OnClick="Local_Data_Click"/>
                                </td>
                                <td>
                                    <asp:ListBox ID="FileUpLoad" runat="server" OnSelectedIndexChanged="FileUpLoad_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
                                </td>
                                <td>

                                    <asp:Button ID="Add_Data" runat="server" Text="Add" OnClick="Add_Data_Click" />

                                </td>
                            </tr>
                        <tr>
                            <td colspan="3"> 
                                <center><h3>DB 목록</h3></center>
                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="Horizontal" Visible="False"  CellSpacing="3" PageSize="5" AllowPaging="True" BorderStyle="Solid" HorizontalAlign="Center">
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" FirstPageText="First" LastPageText="Last" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>

                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:BoundField DataField="FileNm" HeaderText="FileNm" SortExpression="FileNm"  />
                                        <asp:BoundField DataField="FileCrd" HeaderText="FileCrd" SortExpression="FileCrd" />
                                        <asp:BoundField DataField="FileLwd" HeaderText="FileLwd" SortExpression="FileLwd" />
                                        <asp:BoundField DataField="Nowtime" HeaderText="Nowtime" SortExpression="Nowtime" />
                                        <asp:BoundField DataField="modifiy" HeaderText="modifiy" SortExpression="modifiy" />
                                        <asp:TemplateField HeaderText="Checked">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Checkedbox" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" BorderStyle="Groove" VerticalAlign="Bottom" Width="20px" Wrap="False" />
                                    <RowStyle BackColor="#E3EAEB" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataStorageConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [LocalData]" ></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td width="50%" colspan="2">                            
                                <asp:Button ID="Load_DB_Data" runat="server" Text="DB_Load" OnClick="Load_DB_Data_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Delete_DB_Data" runat="server" Text="DB_Delete" OnClick="Delete_DB_Data_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan ="2">
                                <asp:TextBox ID="Content" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Modifiy" runat="server" Text="Modified" OnClick="Modifiy_Click" />
                            </td>
                        </tr>
                    </tbody>
           </table>
            <p align="center">
                <asp:Label ID="ResultValue" runat="server" Text="" Font-Size="Large"></asp:Label>
              </p>
            <p align="right">
                <asp:Button ID="Back" runat="server" Text="돌아가기"></asp:Button>
          </p>      
        </div>
    </form>
</body>
</html>
