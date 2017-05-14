<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="TryMLearning.Web.Client" %>

<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>TryMLearning</title>
    
    <%: Styles.Render("~/content/common-css") %>
</head>
<body data-ng-app="app">
    
    <div data-ui-view></div>
    
    <script type="text/javascript">
        var tryMLearningWebApiSrvUri = '<%= TryMLearningWebApiSrvUri %>';
    </script>

    <%: Scripts.Render("~/content/common-js") %>
    <%: Scripts.Render("~/content/client-js") %>
</body>
</html>
