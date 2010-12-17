<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="SharpArch.Web" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Dummy</title>
</head>
<body>
    <div>
        <%= Html.RenderAction() %>
    </div>
</body>
</html>
