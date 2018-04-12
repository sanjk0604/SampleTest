<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>ASP.NET</h1>
		<p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
		<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
	</div>

	<div class="row">
		<div class="col-md-4">
			<h2 runat="server" id="output">Get IP Address: </h2>
			<asp:Button ID="Button1" runat="server" Text="Get IP Address!" OnClick="Button1_Click" />
		</div>
		<div class="col-md-4">
			<h2 runat="server" id="output2" visible="false"> </h2>
			<asp:Button ID="Button2" runat="server" Text="Write to Cookie!" OnClick="Button2_Click" visible="false" />
		</div>
		<div class="col-md-4">
		</div>
	</div>
</asp:Content>
