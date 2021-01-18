<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Project_SE.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"  />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" ></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <style>
           body{
             background-image:url('bg.jpg');
           background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
           }
        .id{
           padding-top:50px;
       }
    </style>
  
</head>
    
<body>
    <div> <nav class="navbar navbar-expand-lg navbar-light bg-dark">
  <a class="navbar-brand text-light" href="Home.aspx">Final Year Project Manager</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav ml-auto">
        <li class="nav-item ">
        <a class="nav-link text-light active" href="Home.aspx">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item ">
        <a class="nav-link text-light" href="https://localhost:44320/WebForm1.aspx">Category <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item ">
        <a class="nav-link text-light" href="https://localhost:44320/WebForm2.aspx">Person</a>
      </li>
         <li class="nav-item ">
        <a class="nav-link text-light" href="https://localhost:44320/WebForm3.aspx">Project</a>
      </li>
          <li class="nav-item ">
        <a class="nav-link text-light" href="https://localhost:44320/WebForm4.aspx">Evaluation</a>
      </li>
          <li class="nav-item ">
        <a class="nav-link text-light" href="https://localhost:44320/WebForm4.aspx">Report</a>
      </li>
      
      
    </ul>
      <form class="form-inline my-2 my-lg-0">
      <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
      <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
    </form>
    
  </div>
       
</nav>
       </div>
    <form id="form1" runat="server">
        <div class="id">
            <center>
            <table>
                <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Category Name"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="127px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
                </td>
                </tr>

                <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Name"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                </tr>

                <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Contact"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                </tr>

                <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Rank"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                </tr>

                <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Registration Number"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                </tr>

                <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Degree Program"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Category Id"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Supervisor Id"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                    
                        <td>
                            <asp:Button class="btn btn-primary"  ID="add" runat="server" Text="Add" OnClick="add_Click" BorderStyle="Double" Font-Italic="True" Width="75px" />

                        </td>
                      <td>
                            <asp:Button class="btn btn-danger" ID="delete" runat="server" Text="Delete" OnClick="delete_Click" BorderStyle="Double" Width="75px" />

                        </td>
                    <td>
                            <asp:Button class="btn btn-primary" ID="update" runat="server" Text="Update" OnClick="update_Click" BorderStyle="Double" Width="75px" />

                        </td>
                        
                                   
                </tr>



                </table>
            <asp:GridView ID="GridView1" CssClass="text-light border-light bg-dark" runat="server">
            </asp:GridView>
            <br/>
            <br/>
            <table>
                <tr>
                <td >
                          <asp:Button class="btn-dark" ID="Button1" runat="server" Text="Back" OnClick="back_Click" BorderStyle="Double" CssClass="auto-style2" Width="75px" style="margin-left: 0px" />
                            </td>
                      <td >
                            <asp:Button class="btn-dark" ID="next" runat="server" Text="Next" OnClick="next_Click" BorderStyle="Double" CssClass="auto-style2" Width="75px" style="margin-left: 148px; margin-bottom: 0px" />
                          </td>
                    </tr>
              
                </table>
                </center>
        </div>
    </form>
</body>
</html>
