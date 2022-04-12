//using iTextSharp.text;

//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web;
using System.Web.UI;
using System.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;
using PdfSharp;

namespace Welleazy.Case
{
    public partial class TestPDFDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuestionnaire();
            }
    }


public void LoadQuestionnaire()
{
    Bal BusinessAccessLayer = new Bal();
    DataTable dtQuestionnaire = new DataTable();
    dtQuestionnaire = BusinessAccessLayer.LoadQuestionnaire();

    if (dtQuestionnaire != null && dtQuestionnaire.Rows.Count > 0)
    {
                rgvQuestions.DataSource = dtQuestionnaire;
                rgvQuestions.DataBind();
    }
    else
    {
                rgvQuestions.DataSource = new object[] { };
                rgvQuestions.DataBind();
    }


}

protected void rgvQuestions_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
{

}

protected void rgvQuestions_DataBound(object sender, EventArgs e)
{

}

protected void rgvQuestions_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
{

}

protected void rgvQuestions_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
{

}


public override void VerifyRenderingInServerForm(Control control) { }

protected void btnSubmit_Click(object sender, EventArgs e)
{
    try
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //// var example_html = @"<p>This is some sample  text<span style="">!!!</span></p>";
        //var example_html = PrintContent.ToString();
        ////StringWriter stringWriter = new StringWriter();
        ////HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        ////PrintContent.RenderControl(htmlTextWriter);
        //StringReader sr = new StringReader(example_html);
        ////StringReader stringReader = new StringReader(stringWriter.ToString());
        //Document pdfDoc = new Document(PageSize.A4);
        //var writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Employee.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        PrintContent.RenderControl(htmlTextWriter);

                //string html = File.ReadAllText("input.htm");
                PdfDocument pdf = PdfGenerator.GeneratePdf(stringWriter.ToString(), PageSize.A4);
                pdf.Save("document.pdf");

                StringReader stringReader = new StringReader(stringWriter.ToString());
        //Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(Doc);
        //PdfWriter.GetInstance(Doc, Response.OutputStream);

        //Doc.Open();
        //htmlparser.Parse(stringReader);
        //Doc.Close();
        //Response.Write(Doc);
        //Response.End();

        //Response.Write(pdfDoc);
        //Response.End();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter stringWriter = new StringWriter();
        //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        //PrintContent.RenderControl(htmlTextWriter);
        //StringReader stringReader = new StringReader(stringWriter.ToString());
        //Document Doc = new Document(PageSize.A4, 10, 10, 100, 0);

        //// Document doc = new Document()
        //HTMLWorker htmlparser = new HTMLWorker(Doc);
        //PdfWriter.GetInstance(Doc, Response.OutputStream);
        //Doc.Open();
        //htmlparser.Parse(stringReader);
        //Doc.Close();
        //Response.Write(Doc);
        //Response.End();
    }
    catch (Exception ex)
    {

    }
}

protected void LinkButton1_Click(object sender, EventArgs e)
{

}

protected void ddlStatus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
{

}

protected void rgvQuestions_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
{

}
    
}
}