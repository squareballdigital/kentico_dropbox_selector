<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Dropbox.ascx.cs" Inherits="CMSFormControls_SquareBall_CloudFileSelectors_Dropbox" %>

<link rel="stylesheet" href='<%= URLHelper.GetAbsoluteUrl("~/CMSFormControls/SquareballDigital/CloudFileSelectors/Dropbox/css/styles.css")%>'>
<div class="cloud-control dropbox">
    <button runat="server" id="btnPicker">Dropbox <sup>TM</sup></button>        
    <div class="file-info">
        <asp:HyperLink runat="server" ID="txtFile"></asp:HyperLink>
        <asp:Label runat="server" ID="lblErrorMessage" ForeColor="Red" Visible="false"></asp:Label>
    </div>
    <input type="hidden" id="fileName" runat="server" clientidmode="Static"/>
    <input type="hidden" id="fileUrl" runat="server" clientidmode="Static"/>
    
</div>

<script type="text/javascript" src='<%= URLHelper.GetAbsoluteUrl("~/CMSFormControls/SquareballDigital/CloudFileSelectors/Dropbox/scripts/libs/jquery-1.7.js")%>'></script> 
<script type="text/javascript" src="https://www.dropbox.com/static/api/2/dropins.js" id="dropboxjs" data-app-key="<%= DropboxAppKey %>"></script>    
<!-- Add Drop-ins domains in your Dropbox app's settings https://www.dropbox.com/developers/apps/ -->
<script type="text/javascript" src='<%= URLHelper.GetAbsoluteUrl("~/CMSFormControls/SquareballDigital/CloudFileSelectors/Dropbox/scripts/cloud-control.js")%>'></script> 
<script type="text/javascript" src='<%= URLHelper.GetAbsoluteUrl("~/CMSFormControls/SquareballDigital/CloudFileSelectors/Dropbox/scripts/pickers/dropbox.js")%>'></script> 
   
<script>
//Dropbox cloud control initialization
$('.dropbox').cloudControl({
    picker: new window.DropboxPicker()
});
</script>
    