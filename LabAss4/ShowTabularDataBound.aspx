<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTabularDataBound.aspx.cs" Inherits="LabAss4.ShowTabularDataBound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>GridView<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                </Columns>
                </asp:GridView>
            </h1>
        </div>
        <div>
            <h1>DataList<asp:DataList ID="DataList1" runat="server" DataKeyField="UserName" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    UserName:
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                    <br />
                    Password:
                    <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
                    <br />
<br />
                </ItemTemplate>
                </asp:DataList>
            </h1>           
        </div>
        <div>
            <h1>DetailsView<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserName" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                </Fields>
                </asp:DetailsView>
            </h1>
        </div>
        <div>
            <h1>FormView<asp:FormView ID="FormView1" runat="server" DataKeyNames="UserName" DataSourceID="SqlDataSource1">
                <EditItemTemplate>
                    UserName:
                    <asp:Label ID="UserNameLabel1" runat="server" Text='<%# Eval("UserName") %>' />
                    <br />
                    Password:
                    <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    UserName:
                    <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                    <br />
                    Password:
                    <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    UserName:
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                    <br />
                    Password:
                    <asp:Label ID="PasswordLabel" runat="server" Text='<%# Bind("Password") %>' />
                    <br />

                </ItemTemplate>
                </asp:FormView>
            </h1>            
        </div>
        <div>
            <h1>Repeater<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand">
              <ItemTemplate>
                  <%#Eval("Username") %>
                  <i>--y</i>
                  <%#Eval("password") %>
              </ItemTemplate>  
            </asp:Repeater>
            </h1>        
        </div>
        <div>
            <h1>ListView<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
                 <ItemTemplate>
                  <%#Eval("Username") %>
                  <i>--</i>
                  <%#Eval("password") %>
              </ItemTemplate>  
            </asp:ListView>
            </h1>        
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SampleDatebaseConnectionString2 %>" SelectCommand="SELECT [UserName], [Password] FROM [Logon]"></asp:SqlDataSource>
    </form>
</body>
</html>
