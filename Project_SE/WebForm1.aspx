<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Project_SE.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project</title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"  />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" ></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
   
    <style>
       .id{
           padding-top:50px;
       }
       body{
           background-image:url("bg.jpg");
           
       }
       hr{
           width:350px;
       }

        .auto-style1 {
            height: 40px;
        }

        .auto-style3 {
            height: 34px;
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
    <form id="form1" runat="server" >
        <div class="id">
            
            <center>
            
           
            <table>
                <tr>
                    <td  >
                        
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Category Name"></asp:Label>

                    </td>
                        <td>
                            <asp:TextBox ID="c_name"  runat="server" Font-Italic="True"></asp:TextBox>
                            


                        </td>
                        
                    
                </tr>
              
                <tr>
                    
                        <td class="auto-style3">
                            <asp:Button  class="btn btn-primary" ID="add" runat="server" Text="Add" OnClick="add_Click" BorderStyle="Double" Font-Italic="True" Width="75px"  />

                        </td>
                      <td class="auto-style3">
                            <asp:Button class="btn btn-danger"  ID="delete" runat="server" Text="Delete" OnClick="delete_Click" BorderStyle="Double" Width="76px" />

                        </td>
                    <td class="auto-style3">
                            <asp:Button class="btn btn-primary" ID="update" runat="server" Text="Update" OnClick="update_Click" BorderStyle="Double" Width="75px" />

                        </td>
                        
                                   
                </tr>


               </table>
                           <br/>
                           <asp:GridView CssClass="text-light border-light bg-dark" ID="GridView1" runat="server">
                </asp:GridView>
                           <br/>
            <table>
                <tr>
                <td class="auto-style1">
                            &nbsp;</td>
                      <td class="auto-style1">
                            <asp:Button class="btn btn-dark" ID="next" runat="server" Text="Next" OnClick="next_Click" BorderStyle="Double" Width="75px" />
                          </td>
                    </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
                </center>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
