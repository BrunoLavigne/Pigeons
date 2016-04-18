<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PigeonsFAQ.aspx.cs" Inherits="PigeonsFAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .section-header {
            background-color: lightgray;
        }

        .faq-header {
            font-weight: bold;
        }

        .faq-desc {
            padding-left: 10px;
        }

        p {
            padding-left: 10px;
        }
    </style>

    <div class="container">
        <div class="col-md-8">

            <!---------------------------------------------
            // Fonctions de bases
            ----------------------------------------------->

            <div class="row">
                <h2 class="section-header">Fonctions de bases</h2>
            </div>

            <!--- inscription --->

            <div class="row">
                <h4 class="faq-header" data-id="1">Inscription</h4>
                <p class="faq-desc" data-id="1">
                    L'inscription est gratuite (et &ccedil;a le restera toujours) !<br />
                    Vous n'avez qu'&agrave; inscrire les informations demand&eacute;es et en quelque seconde, vous serez pr&ecirc;t &agrave; commencer votre premier projet d'&eacute;quipe. Bienvenu parmi les Pigeons !
                </p>
            </div>

            <hr />

            <!--- création groupe --->

            <div class="row">
                <h4 class="faq-header" data-id="2">Cr&eacute;ation d'un groupe</h4>
                <p class="faq-desc" data-id="2">
                    Vous pouvez facilement cr&eacute;er un groupe d&egrave;s que vous avez cr&eacute;&eacute; un compte.
                    Il vous suffit de cliquer sur le bouton au centre de votre page d'accueil et d'inscrire les informations demand&eacute;es et le tour est jou&eacute;!
                </p>
            </div>

            <hr />

            <!--- joindre groupe --->

            <div class="row">
                <h4 class="faq-header" data-id="3">Joindre un groupe</h4>
                <p class="faq-desc" data-id="3">
                    Afin de joindre une &eacute;quipe, le cr&eacute;ateur d'un groupe doit vous ajouter &agrave; celui-ci. Comme c'est un site de collaboration avec des personnes que vous connaissez d&eacute;j&agrave;, il n'est pas possible de faire la demande de joindre un groupe particulier. Seul un administrateur peut vous y ajouter.
                </p>
            </div>

            <hr />

            <!---------------------------------------------
            // Créateur du groupe
            ----------------------------------------------->

            <div class="row">
                <h2 class="section-header">Cr&eacute;ateur du groupe</h2>
            </div>

            <!--- modification groupe --->

            <div class="row">
                <h4 class="faq-header" data-id="4">Modifier un groupe</h4>
                <p class="faq-desc" data-id="4">
                    Si vous avez cr&eacute;&eacute; un groupe, il vous est possible de changer son nom, sa description et son image. Un simple clique sur le bouton 'modification' et il vous sera possible de faire les changements que vous voulez !<br />
                    En tant qu'administrateur du groupe, vous avez aussi le pouvoir d'ajouter des personnes &agrave; celui-ci. En cliquant sur ' + ' il vous sera possible de rechercher une personne par son nom ou son adresse courriel. Par la suite vous n'avez qu'&agrave; la s&eacute;lectionner et l'ajouter.<br />
                    De la m&ecirc;me fa&ccedil;on, en appuyant sur ' - ', il vous est possible de retirer une personne de votre groupe &agrave; tout moment.
                </p>
            </div>

            <hr />

            <!--- effacer groupe --->

            <div class="row">
                <h4 class="faq-header" data-id="5">Effacer un groupe</h4>
                <p class="faq-desc" data-id="5">
                    Si votre projet ou votre travail est termin&eacute; (f&eacute;licitation !), en tant qu'administrateur, vous pouvez maintenant fermer votre groupe. Il ne sera donc plus visible dans votre liste de groupe actif et pour les autres membres de votre groupe non plus.
                </p>
            </div>

            <hr />

            <!---------------------------------------------
            // Membre d'un groupe
            ----------------------------------------------->

            <div class="row">
                <h2 class="section-header">Membre d'un groupe</h2>
            </div>

            <!--- page groupes vs page groupe --->

            <div class="row">
                <h4 class="faq-header" data-id="6">Page des groupes / Page d'un groupe</h4>
                <p class="faq-desc" data-id="6">

                    <p style="font-style: italic">Page groupes :</p>

                    <p>Cette page affiche tous les groupes auxquels vous participez pour le moment. De cette page, vous pouvez cliquer sur n&rsquo;importe quelle d'entre eux et y acc&eacute;der afin de consulter ou d'ajouter de l'information.</p>
                    <p>C'est aussi &agrave; partir de cette page que vous pouvez entrer en contact avec les membres de vos groupes. Dans la barre &agrave; gauche, il vous est possible de s&eacute;lectionner un groupe et de bavarder en temps r&eacute;el avec les membres qui sont connect&eacute;s.</p>

                    <p style="font-style: italic">Page groupe :</p>

                    <p>C'est l'endroit o&ugrave; se retrouvent toutes les informations et les documents importants &agrave; votre projet. Vous y retrouver un calendrier des &eacute;v&egrave;nements qui s'en viennent, un tableau de messages important que les autres membres ou vous avez laiss&eacute;, une liste des t&acirc;ches &agrave; accomplir et tous les fichiers qui ont &eacute;t&eacute; t&eacute;l&eacute;vers&eacute;s.</p>
                </p>
            </div>

            <hr />

            <!--- création évènement --->

            <div class="row">
                <h4 class="faq-header" data-id="7">Créer un évènement</h4>
                <p class="faq-desc" data-id="7">
                    &Agrave; tout moment, vous pouvez cr&eacute;er un &eacute;v&egrave;nement que vous voulez. Un simple clic sur l'ic&ocirc;ne &agrave; droite du calendrier vous permettra d'inscrire une courte description aussi que la date de celui-ci. Cet &eacute;v&egrave;nement sera par la suite visible dans le calendrier de tous les autres membres du groupe. Un &eacute;v&egrave;nement compl&eacute;t&eacute; peut aussi &ecirc;tre enlev&eacute; en le s&eacute;lectionnant dans le tableau et en cliquant sur 'compl&eacute;t&eacute;'.
                </p>
            </div>

            <hr />

            <!--- création task --->

            <div class="row">
                <h4 class="faq-header" data-id="8">Cr&eacute;ation d'une tâche</h4>
                <p class="faq-desc" data-id="8">
                    Un t&acirc;che doit &ecirc;tre ex&eacute;cut&eacute; ou faite par quelqu'un du groupe. Un clic et c'est r&eacute;gl&eacute; ! Une t&acirc;che peut aussi &ecirc;tre inscrite comme &eacute;tant important et sera ainsi afficher avec une plus grande importance. &Agrave; tout moment il vous est aussi possible d'inscrire une t&acirc;che comme &eacute;tant compl&eacute;t&eacute; et m&ecirc;me l'effacer si vous ne voulez plus la voir.
                </p>
            </div>

            <hr />

            <!--- création message --->

            <div class="row">
                <h4 class="faq-header" data-id="9">Cr&eacute;ation d'un message</h4>
                <p class="faq-desc" data-id="9">
                    <p>
                        Si vous avez un messages &agrave; envoyer &agrave; tout le monde dans le groupe, le mieux est de l'inscrire sur le tableau de message. Il sera donc plus facile &agrave; retrouver par la suite que s'il a &eacute;t&eacute; envoy&eacute; en message instantan&eacute;.
                 L'outil fourni vous permet d'ins&eacute;rer des images, du texte et de le formatter comme bon vous semble. Il sera ensuite visible par tout les membres du groupe. Il vous est aussi possible d'effacer un message que vous avez envoy&eacute; ou bien de le modifier
                    </p>
            </div>

            <hr />

            <!--- chat --->

            <div class="row">
                <h4 class="faq-header" data-id="10">Discussion avec les membres du groupe</h4>
                <p class="faq-desc" data-id="10">
                    Il est possible de discuter en temps r&eacute;el avec n&rsquo;importe quel membre de vos groupes. Dans la barre &agrave; gauche de l'&eacute;cran se retrouve une liste de tous les groupes avec lesquels vous travailler. Un clic sur un groupe ouvrira une fen&ecirc;tre de clavardage afin de discuter avec tous les membres connecter en ce moment. Une personne non connect&eacute;e aura aussi acc&egrave;s aux messages qui ont &eacute;t&eacute; envoy&eacute;s alors qu'il n'&eacute;tait pas l&agrave;.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="Server">
</asp:Content>