﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register TagPrefix="uc" TagName="ConnectModal" Src="~/Partials/ConnectModal.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- place homepage animation script here -->
    <link rel="stylesheet" href="Resources/css/Homepage.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container Home-page">

        <div class="Home-logo-container">
            <img id="" src="Resources/img/pigeon.svg" alt="Pigeon logo" class="logo" />
        </div>

        <div class="description">

             <div class="inner-wrapper">
                <div class="main-title">Pigeon</div>
                 <hr />
                <p>Pigeon est un site pour faciliter la collaboration, l’entraide, whatever pour les projets de petite et grande envergures. Que votre projet dure 1 journée ou s’étende sur un an, Pigeon aide à regrouper toute l’information nécessaire à la réalisation du projet :)</p>
             </div>

        </div>

        <div class="features">
            <div class="row">
                <div class="col-sm-4">
                    <div class="feature equal">
                        <span class="glyphicon glyphicon-envelope"></span>
                        <div class="content">Communication amusante</div>
                    </div>
                </div>
            
                <div class="col-sm-4">
                    <div class="feature equal">
                        <span class="glyphicon glyphicon-calendar"></span>
                        <div class="content">Évènements en un coup d'oeil</div>
                    </div>
                </div>
            
                <div class="col-sm-4">
                    <div class="feature equal">
                        <span class="glyphicon glyphicon-paperclip"></span>
                        <div class="content">Partagez vos fichiers importants</div>
                    </div>
                </div>
            </div>


        </div>
    </div>

    <!-- Connection modal -->
    <uc:ConnectModal runat="server" ID="connectModal"></uc:ConnectModal>
    <script type="text/javascript" src="Resources/js/animations/homepage.js"></script>
</asp:Content>