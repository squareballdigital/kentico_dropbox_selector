using System;
using CMS.DataEngine;
using CMS.FormControls;
using CMS.Helpers;
using CMS.MacroEngine;
using CMS.PortalEngine;
using System.Xml;
using CMS.EventLog;

public partial class CMSFormControls_SquareBall_CloudFileSelectors_Dropbox : FormEngineUserControl
{
    #region "Private properties"
    //Return value format of the control
    private const string ControleValueFormat = "<file><fileName>{0}</fileName><fileUrl>{1}</fileUrl></file>";
    #endregion

    #region "Protected properties"

    /// <summary>
    ///     Gets Dropbox App Key value    
    /// </summary>
    protected string DropboxAppKey
    {
        get
        {
            //Get control setting 
            string dropboxAppKey = ValidationHelper.GetString(GetValue("DropboxAppKey"), "");            
            
            return MacroResolver.Resolve(dropboxAppKey);
        }
    }

    #endregion

    #region "Public properties"
    

    /// <summary>
    ///     Gets or sets the value of this control.
    ///     Returns a value with XML format: <file><fileName>{0}</fileName><fileUrl>{1}</fileUrl></file>
    /// </summary>
    public override object Value
    {
        get
        {
            if (string.IsNullOrWhiteSpace(fileName.Value) && string.IsNullOrWhiteSpace(fileUrl.Value)) return "";

            return string.Format(ControleValueFormat, HTMLHelper.HTMLEncode(fileName.Value), HTMLHelper.HTMLEncode(fileUrl.Value));
        }
        set
        {
            //Check if it is in Editing mode
            if (PortalContext.ViewMode.IsLiveSite())
            {
                if (!string.IsNullOrWhiteSpace(ValidationHelper.GetString(value, "")))
                {
                    try
                    {
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(ValidationHelper.GetString(value, ""));

                        XmlNode node = document.SelectSingleNode("file");

                        if (node != null)
                        {
                            txtFile.Text = HTMLHelper.HTMLDecode(node.SelectSingleNode("fileName").InnerText);
                            txtFile.NavigateUrl = HTMLHelper.HTMLDecode(node.SelectSingleNode("fileUrl").InnerText);
                        }
                    }
                    catch (XmlException ex)
                    {
                        EventLogProvider.LogEvent(EventType.ERROR, "Dropbox file selector", "LoadCustomFormControl", eventDescription: "Wrong value format.");                        
                    }
                }

            }
        }
    }  

    #endregion

    #region "Protected event handlers"

    protected void Page_Load(object sender, EventArgs e)
    {
        //Check Dropbox App Key
        // -> Display error message when the ID is missing
        // -> Hide picker button
        if (PortalContext.ViewMode.IsLiveSite() && string.IsNullOrWhiteSpace(DropboxAppKey))
        {
            lblErrorMessage.Text = "[Error: Dropbox App Key is missing. Please add the App Key in form field settings (Dropbox App Key).]";
            lblErrorMessage.Visible = true;
            btnPicker.Visible = false;
        }
        else
        {
            lblErrorMessage.Visible = false;
        }
        
    }    

    #endregion
}