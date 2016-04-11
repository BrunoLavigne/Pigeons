<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Eventificator.aspx.cs" Inherits="Eventificator" %>

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

                        <div class="col-lg-3">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" DayHeaderStyle-BackColor="White" TodayDayStyle-BackColor="#339966" TitleStyle-BackColor="#333333" ShowGridLines="False" SelectedDayStyle-BackColor="White" OtherMonthDayStyle-ForeColor="#CCCCCC" TitleStyle-ForeColor="White" TitleStyle-HorizontalAlign="Center" TitleStyle-VerticalAlign="Middle" CellPadding="5" DayHeaderStyle-HorizontalAlign="Center" DayHeaderStyle-VerticalAlign="Middle" SelectionMode="Day" WeekendDayStyle-BackColor="#F4F4F4" OnDayRender="Calendar1_DayRender" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="1" DayStyle-Width="30" DayStyle-Height="30" DayHeaderStyle-Height="10" TitleStyle-Height="30" TodayDayStyle-BorderStyle="None" Enabled="True" SelectedDayStyle-ForeColor="Black" CssClass="eventCalendar"></asp:Calendar>
                        </div>

                        <div class="col-lg-4">
                            <asp:Table ID="Table1" runat="server" CssClass="table-hover">
                            </asp:Table>
                        </div>

                        <div class="container">

                            <div class="col-lg-2">

                                <div class="row">
                                    <asp:Button ID="btnNewEvent" runat="server" CssClass="btn btn-default btn-block" Text="+" OnClick="btnNewEvent_Click" />
                                </div>

                                <div id="newEvent" visible="false" runat="server">
                                    <div class="row">
                                        <asp:TextBox ID="txtEventDescription" runat="server" CssClass="form-control" placeHolde="Description"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 10px;">
                                        <asp:TextBox ID="txtEventStart" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-default btn-sm" OnClick="Button1_Click" />
                                        <asp:Calendar OnSelectionChanged="Calendar2_SelectionChanged" ID="Calendar2" runat="server" BackColor="White" DayHeaderStyle-BackColor="White" TodayDayStyle-BackColor="#339966" TitleStyle-BackColor="#333333" ShowGridLines="False" SelectedDayStyle-BackColor="#339966" OtherMonthDayStyle-ForeColor="#CCCCCC" TitleStyle-ForeColor="White" TitleStyle-HorizontalAlign="Center" TitleStyle-VerticalAlign="Middle" CellPadding="5" DayHeaderStyle-HorizontalAlign="Center" DayHeaderStyle-VerticalAlign="Middle" SelectionMode="Day" WeekendDayStyle-BackColor="#F4F4F4" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="1" Visible="false"></asp:Calendar>
                                    </div>
                                    <div class="row" style="padding-top: 10px;">
                                        <asp:TextBox ID="txtEventEnd" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-default btn-sm" OnClick="Button2_Click" />
                                        <asp:Calendar OnSelectionChanged="Calendar3_SelectionChanged" ID="Calendar3" runat="server" BackColor="White" DayHeaderStyle-BackColor="White" TodayDayStyle-BackColor="#339966" TitleStyle-BackColor="#333333" ShowGridLines="False" SelectedDayStyle-BackColor="#339966" OtherMonthDayStyle-ForeColor="#CCCCCC" TitleStyle-ForeColor="White" TitleStyle-HorizontalAlign="Center" TitleStyle-VerticalAlign="Middle" CellPadding="5" DayHeaderStyle-HorizontalAlign="Center" DayHeaderStyle-VerticalAlign="Middle" SelectionMode="Day" WeekendDayStyle-BackColor="#F4F4F4" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="1" Visible="false"></asp:Calendar>
                                    </div>
                                    <div class="row" style="padding-top: 10px;">
                                        <asp:Button ID="btnCreateEvent" runat="server" Text="Créer l'évènement" CssClass="btn btn-primary btn-sm" OnClick="btnCreateEvent_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="Server">
    <script>
        $('.eventRow').hover(function () {
            console.log($(this).data('id'));

            $.each( $('.eventCalendar .day'), function () {
                console.log($(this).data('id'));
            });

        });

        function test(e) {
            alert("bob");
<%--            var id = e;
            <%= highlighter("  bob  ") %>");--%>
        }
    </script>
</asp:Content>