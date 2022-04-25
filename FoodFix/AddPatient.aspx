<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="FoodFix.AddPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add patient</title>
    
    <style>
        .input {
            width: 120px ;
        }

        #form1 {
            padding: 10px;
            margin: 10px;
        }

        input {
            margin: 2px;
        }

        label {
            text-align: left !important;
        }
    </style>
</head>
<body>
    <center>

    <form id="form1" runat="server">
        <div>
                 <h1>Add New Patient</h1>
                <h2>FoodFix</h2>    
                <hr />
                <label>ID: </label> <br />
                <input name="ID" type="number" placeholder="123" min="1" class="input" required=""/><br />
                <label>Name: </label><br />
                <input name="Name" type="text" placeholder ="Avi"/ required="" class="input" /> <br />
                <label>SurName: </label><br />
                <input name="SurName" type="text" placeholder="Cohen" required="" class="input"/><br />
                <label>Height: </label><br />
                <input name="Height" type="number" placeholder="167.8CM" step="0.01" min="1" max="250" required="" class="input"/><br />
                <label>Weight: </label><br />
                <input name="Weight" type="number" placeholder="75.4KG"  step="0.01" min="1" max="300" required="" class="input"/><br />
                <asp:Button ID="AddPat" runat="server" Text="Add Patient" OnClick="AddPatientToDb" />
        </div>
    </form>
    <footer>
            <a href="Default.aspx" class="PatientsList">Go To Patients List</a>
        </footer>
    </center>
</body>
</html>
