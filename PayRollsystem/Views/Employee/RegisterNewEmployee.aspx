<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PayRollSystem.Models.EmployeeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RegisterNewEmployee
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="employee_list_container">
    <%: Html.Partial("ExistingEmployees")%>
</div>

<div class="employee_form_container">
    <%: Html.Partial("EmployeeForm")%>
</div>


</asp:Content>
