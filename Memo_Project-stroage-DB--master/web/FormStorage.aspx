<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormStorage.aspx.cs" Inherits="WebStreamApi.FormStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>데이터 저장소</title>
    <style>
        #Stream {height :20vh;}
        #btnSave, #btnLoad, #btnDelete{height: 5vh;}
        #LoadFile, #Content{width:100%; height:12vh;}
        #LoadContent{width:100%; height:12vh}
        #LoadContent {width:100%;}
        #AllClear {width: 100%;}
         table{
            width: 100% ;
        }
        table, th, td {
            border: 1px solid black;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <div align ="center" >
            <asp:Label ID="Label1" runat="server"><h1>데이터저장소</h1></asp:Label>
      <p>
        <asp:TextBox ID="Stream" runat="server" TextMode="MultiLine" width="100%"
            type="text" OnTextChanged="Stream_TextChanged" Font-Size="X-Large"
            Font-Names="Arial"></asp:TextBox>
        </p>
      <p>
        <asp:Button ID="btnSave" runat="server" Text="Save"  Width="20%" OnClick="btnSave_Click"/>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
        <asp:Button ID="btnLoad" runat="server" Text="Load" Width="20%" OnClick="btnLoad_Click"/>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
        <asp:Button ID="btnDel" runat="server" Text="Delete" Width="20%" OnClick="btnDel_Click"/>
       </p>
     <table>
         <thead>
             <th colspan ="2"><h2>DataStorageLoadFile</h2></th>
         </thead>
         <tbody>
             <tr>
                 <td width="70%" align ="Left">
                     <asp:ListBox ID="LoadFile" runat="server" Font-Size="Medium" OnSelectedIndexChanged="LoadFile_SelectedIndexChanged"></asp:ListBox>
                 </td>
                 <td width="10%">
                     <asp:Button ID="LoadContent" runat="server" Text="ReadFile" OnClick="LoadContent_Click" />
                 </td>
             </tr>
             <tr>
                 <td colspan="2">
                     <asp:ListBox ID="Content" runat="server" Font-Size="Medium" Enabled ="false"></asp:ListBox>
                 </td>
             </tr>
             <tr>
                 <td colspan="2">
                     <asp:Button ID="AllClear" runat="server" Text="Clear" OnClick="AllClear_Click" />
                 </td>
             </tr>
         </tbody>
     </table>    
            </div>
        <p align ="right">
            <asp:Button ID="Exit" runat="server" Text="돌아가기" width="30%" OnClick="Exit_Click"/>
        </p>
    </form>
</body>
</html>
