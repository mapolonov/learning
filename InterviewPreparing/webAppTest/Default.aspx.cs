using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAppTest
{
    public partial class _Default : System.Web.UI.Page, ICallbackEventHandler
    {
        private string _callbackResult = null;

        protected void Page_Load(object sender, EventArgs e)
        {
          Button1.Click += new EventHandler(Button1_Click);
          Button1.Command += new CommandEventHandler(Buttonasdf_Command);
          
            Label1.Text = "IsPostBack: " + IsPostBack.ToString() + 
                "<br />   Callback: " + IsCallback.ToString() +
                "<br />   SupportsXmlHTTP: " + Page.Request.Browser.SupportsXmlHttp.ToString();
            
            Label3.Text = ClientScript.GetPostBackEventReference(LinkButton1, null);
            string cbReference = Page.ClientScript.GetCallbackEventReference(this,
                                                    "arg", "GetRandomNumberFromServer", "context");
            string cbScript = "function UseCallback(arg, context)" +
            "{" + cbReference + ";" + "}";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"UseCallback", cbScript, true);

            //HttpContext.Current.ApplicationInstance.
          
            
        }

        

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = "The sent text: " + TextBox1.Text;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Label2.Text = "The sent text: " + TextBox1.Text;
        }

        protected void Buttonasdf_Command(object sender, CommandEventArgs e)
        {
            Label2.Text += "The sent text: By Button1_Command";
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        #region ICallbackEventHandler Members

        public string GetCallbackResult()
        {
            return _callbackResult;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            Random rnd = new Random();
            _callbackResult = rnd.Next().ToString();
        }

        #endregion
    }
}
