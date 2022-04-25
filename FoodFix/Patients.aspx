<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="FoodFix.Patients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <Center>

        <form id="form1" runat="server">
            <div>
                <asp:Panel ID="PatientsPanel" runat="server">
                        <h1>Patients List</h1>
                        <h2>FoodFix</h2>  

                        <hr />
                            <table border="1">
                                <asp:Label ID="Tr" runat="server" Text=""></asp:Label>   
                        </table>
                </asp:Panel>
            </div>
        </form>
        <br />
        <a href="AddPatient.aspx" class="PatientsList">Add New Patient</a>
    </Center>

</body>
</html>
