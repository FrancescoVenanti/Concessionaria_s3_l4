<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Concessionaria_s3_l4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div id="container">
            <p id="Error" runat="server"></p>
            <h3>Seleziona un'auto</h3>
            <asp:DropDownList ID="carDrop" runat="server"></asp:DropDownList>
            <div id="Accessori" class="mt-3">
                <h3>Seleziona gli optional</h3>
                <asp:CheckBoxList ID="accessori" runat="server"></asp:CheckBoxList>
            </div>
            <div>
                <asp:TextBox ID="garanzia" runat="server" placeholder="Anni di garanzia"></asp:TextBox>
            </div>
            <asp:Button ID="calcolaPrev" runat="server" Text="Calcola preventivo" OnClick="calcolaPrev_Click" />
            <div runat="server">
                <p>Totale spesa: <span id="Preventivo" runat="server"></span></p>
            </div>
        </div>
     </div>
</asp:Content>
