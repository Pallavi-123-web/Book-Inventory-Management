<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        h4
        {
            
            font-weight:500;
            
            }
        .add
        {
            width:100%;
            text-align:center;
            border-bottom:1px solid #000;
            padding-top:10px;
            padding-bottom:10px;
            }
        .op
        {
           
            padding-top:10px;
            
            }
        .books
        {
           width:100%;
            text-align:center;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div class="books">
        <div class="add">
            <h4>Book Inventory Management</h4>
          
        </div>
         <div class="add">
             <span class="op">Select Operation : <asp:DropDownList ID="ddlOperation" runat="server">
               <asp:ListItem>Add New</asp:ListItem>
               <asp:ListItem>Modify</asp:ListItem>
             </asp:DropDownList></span> 
         </div>
         <asp:Label ID="lblmsg" runat="server" BackColor="Yellow" Font-Size="14px" Visible="false"></asp:Label>
        <asp:Panel ID="Panel1" runat="server" >
            <div >
            <h4>Book Fields</h4>
            Title : <asp:TextBox ID="txtTitle" runat="server" ></asp:TextBox><br /><br />
            Author : <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br /><br />
            ISBN : <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox><br /><br />
            Publisher : <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox><br /><br />
            Year : <asp:TextBox ID="txtYear" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnSave" runat="server" Text="Do it" onclick="btnSave_Click" /> 
            <asp:Button ID="btnModify" runat="server" Text="Modify" Visible="false" 
                    onclick="btnModify_Click"/>
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" onclick="btnCancel_Click" 
                   />
         </div>
        </asp:Panel>
          <hr />       
       <asp:Panel ID="Panel2" runat="server" >
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                onrowcommand="GridView1_RowCommand1" onrowdeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.No.">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("slno") %>'></asp:HiddenField>
                            <%#Container.DisplayIndex +1 %>
                        </ItemTemplate>                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author">
                        <ItemTemplate>
                            <asp:Label ID="lblAuthor" runat="server" Text='<%#Eval("author") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ISBN">
                        <ItemTemplate>
                            <asp:Label ID="lblIsbn" runat="server" Text='<%#Eval("isbn") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Publisher">
                        <ItemTemplate>
                            <asp:Label ID="lblPublisher" runat="server" Text='<%#Eval("publisher") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Year">
                        <ItemTemplate>
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("year") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:ButtonField CommandName="Add" Text="Edit" ButtonType="Link" ItemStyle-Height="6px" ItemStyle-Width="6px">
                                        <ItemStyle Height="6px" Width="6px" />
                    </asp:ButtonField>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Link" DeleteText="Delete" ItemStyle-Height="10px" ItemStyle-Width="10px" />
                </Columns>
            </asp:GridView>
       </asp:Panel>

    </div>
    
    </form>
</body>
</html>
