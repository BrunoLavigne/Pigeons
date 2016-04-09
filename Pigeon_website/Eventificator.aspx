<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Eventificator.aspx.cs" Inherits="Eventificator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="jumbotron">
            <h1>E v e n t i f i c a t o r</h1>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <div class="container">
                    <div class="row">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" DayHeaderStyle-BackColor="White" TodayDayStyle-BackColor="#339966" TitleStyle-BackColor="#333333" ShowGridLines="False" SelectedDayStyle-BackColor="#FF9900" TitleStyle-Height="50" DayStyle-Height="50" DayStyle-Width="50" OtherMonthDayStyle-ForeColor="#CCCCCC" TitleStyle-ForeColor="White" TitleStyle-HorizontalAlign="Center" TitleStyle-VerticalAlign="Middle" TitleStyle-Width="50" CellPadding="5" DayHeaderStyle-HorizontalAlign="Center" DayHeaderStyle-VerticalAlign="Middle" SelectionMode="Day" WeekendDayStyle-BackColor="#F4F4F4"></asp:Calendar>
                    </div>
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" Runat="Server">
</asp:Content>

