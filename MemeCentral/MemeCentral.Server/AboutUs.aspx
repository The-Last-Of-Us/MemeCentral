<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="MemeCentral.Server.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <h1 class="text-center"><strong>Who are we?</strong></h1>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-6">
                <img src="images/1.png" class="aboutUsImg"/>
            </div>
            <div class="col-md-6 aboutUsName">
                <h2>Elisey Chaylev</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <img src="images/2.png" class="aboutUsImg"/>
            </div>
            <div class="col-md-6 aboutUsName">
                <h2>Ivo Rankov</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <img src="images/3.png" class="aboutUsImg"/>
            </div>
            <div class="col-md-6 aboutUsName">
                <h2>Kiril Borisov</h2>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <strong>Our GitHub repository: <a href="https://github.com/The-Last-Of-Us/MemeCentral/" target="_blank">The last of us - MemeCentral</a></strong>
        </div>
        <br />
        <br />
        <br />
        <div class="row">
            <h2 class="text-center"><i>We are minions! We learned WebForms!</i></h2>
        </div>
    </div>
</asp:Content>
