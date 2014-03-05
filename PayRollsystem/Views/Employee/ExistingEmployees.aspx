<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PayRollSystem.Models.EmployeeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ExistingEmployees
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
    <tbody>
        <%foreach (var employee in Model.ExistingEmployees)
          {%>
            <tr style="padding-left: 10px; padding-right: 10px; border: 2px solid;">
                <td style="padding-left: 10px; padding-right: 10px;">
                    <a id="display_<%: employee.Value %>" href="/Employee/UpdateEmployee?employeeCode=<%: employee.Key %>"><%: employee.Value %></a>

                </td>
            </tr>   
        <% }%>
    </tbody>
</table>


</asp:Content>
