<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormMenu.aspx.cs" Inherits="WebStreamApi.FormMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>메인메뉴</title>
    <style>
        #Local,#DBConnect,#Server_Storage,#Exit{height:10vh;}
        table{
            width: 100%;
            height: 50vh;
        }
        table, th{
            border: 1px solid black;
        }
        th,td{
            text-align : center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            <table>
                <thead>
                    <th><h1>MainMenu</h1></th>
                </thead>
               <tbody>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Local" runat="server" Text="로컬저장소" width="100%" Font-Size="Large"/>
                    </td>
                </tr>
                   <tr>
                    <td colspan="2">
                        <asp:Button ID="DBConnect" runat="server" Text="DB저장소" width="100%" Font-Size="Large"/>
                    </td>
                </tr>
                   <tr>
                    <td colspan="2" >
                        <asp:Button ID="Exit" runat="server" Text="종료" width="100%"  Font-Size="Large" OnClick="Exit_Click" />
                    </td>
                </tr>
               </tbody>   
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
