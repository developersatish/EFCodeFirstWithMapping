<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CodeFirstWithMapping.aspx.cs" Inherits="EFCodeFirstWithMapping.CodeFirstWithMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" class="table">
        <tr>
            <td width="50%" valign="top">
                <table>
                    <tr>
                        <td valign="top">
                            <table id="registerTable">
                                <tr>
                                    <td>Name</td>
                                    <td>
                                        <asp:TextBox runat="server" data-bind="value:Name" ID="NameTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Email</td>
                                    <td>
                                        <asp:TextBox  TextMode="Email" data-bind="value:EmailID" runat="server" ID="EmailTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td>
                                        <asp:TextBox runat="server" data-bind="value:Password" TextMode="Password" ID="PasswordTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Address</td>
                                    <td>
                                        <asp:TextBox runat="server" data-bind="value:Address" TextMode="MultiLine" ID="AddressTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" ID="SaveByCode" runat="server" Text="SaveByCode" OnClick="SaveByCode_Click" /></td>
                                    <td>
                                        <input class="btn" type="submit" value="SaveByApi" data-bind="click: regUser" /></td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table id="loginTable">

                                <tr>
                                    <td>Email</td>
                                    <td>
                                        <asp:TextBox  data-bind="value:EmailId" runat="server" ID="LoginIdTextBox" placeholder="email address"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td>
                                        <asp:TextBox runat="server" data-bind="value:Password" ID="LoginPasswordTextBox" TextMode="Password" placeholder="password"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td>
                                        <button type="button" id="loginBtn" class="btn btn-primary" data-loading-text="Loading..." data-bind="click: loginUser">login</button>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">Binding with Code Behind Grid<br />
                            <asp:GridView runat="server" ID="BindGrid"></asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">Binding with API, Knockout js<br />
                            <table id="gvDetails" border="1"></table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%" valign="top">
                <table id="cityTable">
                    <tr>
                        <td>City Name
                        </td>
                        <td>
                            <input type="text" data-bind="value: Name" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="submit" class="btn btn-primary" id="addCityBtn" data-loading-text="Wait..." data-bind="click: saveCity" value="Add City" /></td>
                    </tr>
                    <tr>
                        <td valign="top">All City
                        </td>
                        <td class="container">
                            <select data-bind="options: AllCities, optionsText: 'Name', value: 'ID', optionsCaption: 'Choose...'"></select>
                            <div data-bind="foreach: AllCities">
                                <span data-bind="text: $data.Name"></span>
                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete City" data-bind="click: deleteCity" style="color: red">X</a>
                                <br />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        var loginModel = {
            EmailId: ko.observable(''),
            Password: ko.observable(''),
        };
        var regModel = {
            Name: ko.observable(''),
            Password: ko.observable(''),
            EmailID: ko.observable(''),
            Address: ko.observable(''),
        };
        var cityModel = {
            Name: ko.observable(''),
            AllCities: ko.observableArray([''])
        };

        ko.applyBindings(loginModel, document.getElementById('loginTable'));
        ko.applyBindings(regModel, document.getElementById('registerTable'));
        ko.applyBindings(cityModel, document.getElementById('cityTable'));

        function loginUser() {
            var user = ko.toJS(loginModel);
            setTimeout(function () {
                $.post("/api/login", user, function (item) {
                    $('#loginBtn').button('reset');
                });
            }, 3000);

        }

        function regUser() {
            var user = ko.toJS(regModel);
            $.post("/api/register", user, function () {
                BindGrid();
            });
        }

        function saveCity() {
            var user = ko.toJS(cityModel);
            setTimeout(function () {
                $.post("/api/city", user, function () {
                    loadCity();
                    $('#addCityBtn').button('reset');

                });
            }, 2000);

        }

        function deleteCity(item) {
            console.log(item);
            $.ajax({
                url: "/api/city/" + item.ID,
                type: "Delete",
                success: function () {
                    loadCity();
                },
            });
        }
        function BindGrid() {

            $("#gvDetails").empty();
            $('#gvDetails').append("<tr><th>SN</th>" +
                "<th>Name</th>" +
                "<th>EmailID</th>" +
                "<th>Address</th>" +
                "</tr>");
            $.getJSON("/api/register", function (data) {
                $.each(data, function (index, item) {
                    $("#gvDetails").append("<tr><td>"
                    + item.ID + "</td><td>"
                     + item.Name + "</td><td>"
                     + item.EmailID + "</td><td>"
                     + item.Address + "</td>"
                    + "</tr>");
                });
            });


        }


        function loadCity() {
            cityModel.AllCities.removeAll();
            $.getJSON("/api/city", function (data) {
                $.each(data, function (index, item) {
                    cityModel.AllCities.push(item);
                });
            });


        }
        $(function () {
            loadCity();
            BindGrid();
        });



        $('#loginBtn').click(function () {
            var btn = $(this);
            btn.button('loading');
            /* setTimeout(function() {
                 btn.button('reset');
             }, 3000);*/
        });

        $('#addCityBtn').click(function () {
            $(this).button('loading');
        });
    </script>
</asp:Content>
