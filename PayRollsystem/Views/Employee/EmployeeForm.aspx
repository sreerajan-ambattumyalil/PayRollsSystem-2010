<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PayRollSystem.Models.EmployeeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EmployeeForm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm()) { %>
    <table id="customerForm_customer-fields" class="employee_form">
        <tbody>
            <tr class="employee_form_field_wrapper hideme">
                <td>
                    <label>Employee Id</label>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.Employee.EmployeeId.Value, new { @id = "EmployeeId", @maxlength = 6 }) %>
                </td>
            </tr>
            <tr class="employee_form_field_wrapper" >
                <td>
                    <label>Employee Code</label>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.Employee.EmployeeCode.Value, new { @id = "EmployeeCode", @maxlength = 6 }) %>
                    <%if (Model.Employee != null && !string.IsNullOrEmpty(Model.Employee.EmployeeCode.Error))
                    { %>
                        <span class="error"><%: Model.Employee.EmployeeCode.Error%></span>
                    <% }%>
                </td>
            </tr>
            <tr class="employee_form_field_wrapper">
                <td>
                    <label>Employee Name</label>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.Employee.EmployeeName.Value, new { @id = "EmployeeName", @maxlength = 70 }) %>
                    <%if (Model.Employee != null && !string.IsNullOrEmpty(Model.Employee.EmployeeName.Error))
                    { %>
                        <span class="error"><%: Model.Employee.EmployeeName.Error%></span>
                    <% }%>
                </td>
            </tr>
            <tr class="employee_form_field_wrapper">
                <td>
                    <label>Address</label>
                </td>
                <td>
                    <%: Html.TextAreaFor(m => m.Employee.Address.Value, new { @id = "Address", @maxlength = 200 })%>
                    <%if (Model.Employee != null && !string.IsNullOrEmpty(Model.Employee.Address.Error))
                    {%>
                        <span class="error"><%: Model.Employee.Address.Error%></span>
                    <% }%>
                </td>
            </tr>
            <tr class="employee_form_field_wrapper">
                <td>
                    <label>Post Code</label>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.Employee.PostCode.Value, new { @id = "PostCode", @maxlength = 10 })%>
                    <%if (Model.Employee != null && !string.IsNullOrEmpty(Model.Employee.PostCode.Error))
                    {%>
                        <span class="error"><%: Model.Employee.PostCode.Error%></span>
                    <% }%>
                </td>
            </tr>
            <tr class="employee_form_field_wrapper">
                <td>
                    <label>Salary</label>
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.Employee.Salary.Value, new { @id = "Salary",@maxlength = 15 })%>
                    <%if (Model.Employee != null && !string.IsNullOrEmpty(Model.Employee.Salary.Error))
                    {%>
                        <span class="error"><%: Model.Employee.Salary.Error%></span>
                    <% }%>
                </td>
            </tr>
            <tr class="employee_form_field_wrapper">
                <td>
                </td>
                <td>
                    <input name="button" type="submit" value="Save" />
                    <input name="button" type="submit" value="Cancel" />
                </td>
            </tr>
        </tbody>
    </table>
    <%} %>

</asp:Content>
