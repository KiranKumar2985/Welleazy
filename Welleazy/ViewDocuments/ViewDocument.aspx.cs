using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Welleazy.ViewDocuments
{
    public partial class ViewDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //string directory = "";
                string FilePath = Session["FilePath"].ToString();

                //if (Session["InterpretationCaseId"]!=null)
                //{
                //    string InterpretationCaseId = Session["InterpretationCaseId"].ToString();
                //    directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                //    FilePath = directory + "InterpretationReports" + "\\" + Filename;
                //}
                //else
                //{
                //    directory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                //    FilePath = directory + "AppointmentReports" + "\\" + Filename;
                //}
                //string FilePath = @"E:\Welleazy\Welleazy\AppointmentReports\" + Filename;              
                                
                //string FilePath = @"E:\Welleazy\Welleazy\InterpretationReports\" + Filename;

                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(FilePath);
                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                }
                

                //string Filename = "RadGridExport.pdf";
                //string FilePath = @"E:\Welleazy\Welleazy\AppointmentReports\" + Filename ;
                ////File.WriteAllBytes(FilePath, FileData);
                ////string filePath = (sender as LinkButton).CommandArgument;
                //Response.ContentType = "application/pdf";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(Filename));
                //Response.WriteFile(FilePath);
                //Response.End();

            }
            //Session["InterpretationCaseId"] = null;
        }
    }
}