﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Eventificator.aspx.cs" Inherits="Eventificator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" href="Resources/css/Events-Page.css" />

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

                        <div class="col-lg-4">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" DayHeaderStyle-BackColor="White" TodayDayStyle-BackColor="#339966" TitleStyle-BackColor="#333333" ShowGridLines="False" SelectedDayStyle-BackColor="#339966" OtherMonthDayStyle-ForeColor="#CCCCCC" TitleStyle-ForeColor="White" TitleStyle-HorizontalAlign="Center" TitleStyle-VerticalAlign="Middle" CellPadding="5" DayHeaderStyle-HorizontalAlign="Center" DayHeaderStyle-VerticalAlign="Middle" SelectionMode="Day" WeekendDayStyle-BackColor="#F4F4F4" OnDayRender="Calendar1_DayRender" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="1" DayStyle-Width="50" DayStyle-Height="50" DayHeaderStyle-Height="10" TitleStyle-Height="30"></asp:Calendar>
                        </div>

                        <div class="col-lg-5">
                            <table class="table table-hover">
                                <thead style="background-color:#333333;color:white">
                                    <tr>
                                        <th>
                                            <asp:Label ID="eventDescription" runat="server" Text="Description"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="eventStart" runat="server" Text="Debut"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="eventEnd" runat="server" Text="Fin"></asp:Label>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="eventDesc1" runat="server" Text="Finir de faire ce maudit projet de crotte"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="eventStart1" runat="server" Text="Lundi le 18 avril 2016"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-3">
                            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-default" OnClick="Button1_Click"/>
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="White" DayHeaderStyle-BackColor="White" TodayDayStyle-BackColor="#339966" TitleStyle-BackColor="#333333" ShowGridLines="False" SelectedDayStyle-BackColor="#339966" OtherMonthDayStyle-ForeColor="#CCCCCC" TitleStyle-ForeColor="White" TitleStyle-HorizontalAlign="Center" TitleStyle-VerticalAlign="Middle" CellPadding="5" DayHeaderStyle-HorizontalAlign="Center" DayHeaderStyle-VerticalAlign="Middle" SelectionMode="Day" WeekendDayStyle-BackColor="#F4F4F4" OnDayRender="Calendar1_DayRender" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="1" Visible="false"></asp:Calendar>
                        </div>


                    </div>
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="Server">
</asp:Content>
