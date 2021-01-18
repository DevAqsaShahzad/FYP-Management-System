<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Project_SE.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"  />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" ></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script type="text/javascript">
        function PrintDiv() {
            var divToPrint = document.getElementById('Printdiv');
            var popupWin = window.open('', '_blank', 'width=300,height=400,location=no,left=200px');
            popupWin.document.open();
            popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
            popupWin.document.close();
        }
         </script>
    <style>
           body{
             background-image:url('bg.jpg');
           background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
           }
           .id{
               padding:50px;
           }
        
    </style>
    
    
    
    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }
        .auto-style3 {
            width: 84px;
        }
        .auto-style4 {
            width: 53px;
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
                <td class="auto-style4" >
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Project"></asp:Label>

                </td>
                <td>
                   <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                     </td>
                </tr>

                 <tr>
                <td class="auto-style4" >
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Groups"></asp:Label>

                </td>
                
                </tr>
                </table>
                
                <asp:GridView CssClass="text-light border-light bg-dark" ID="GridView1" runat="server"></asp:GridView>
                    
                <table>
               <tr>
                <td class="auto-style3" >
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Total Marks"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                </tr>
                
                <tr>
                <td class="auto-style3" >
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="Small" Font-Underline="False" ForeColor="White" Text="Obtained Marks"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
                </tr>
             </table>
            
                            <asp:Button class="btn btn-primary" ID="add" runat="server" Text="Evaluate" OnClick="add_Click" BorderStyle="Double" Font-Italic="True" Width="82px" />

            <br/>

                           <br/>
            <table>
                <tr>
                
                      <td class="auto-style1">
                            <asp:Button class="btn btn-dark" ID="next" runat="server" Text="Generate Report" OnClick="next_Click" BorderStyle="Double" Width="130px" style="margin-left: 148px; margin-bottom: 0px" Height="31px" />
                          </td>
                    </tr>
                
                </table>
                    </center>
        </div>
    </form>
</body>
</html>
