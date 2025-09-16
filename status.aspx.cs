using System;
using System.IO;
using System.Web.UI;

public partial class status : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the page is being loaded for the first time
        if (!IsPostBack)
        {
            // Get the value of the "status" query string parameter
            string statusParam = Request.QueryString["status"];

            // Check if the parameter has a value
            if (!string.IsNullOrEmpty(statusParam))
            {
                string fileName = statusParam;

                // Construct the file path using string concatenation
                string filePath = Server.MapPath("~/status/" + fileName);

                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Read and write the file content to the response
                    string content = File.ReadAllText(filePath);
                    Response.Write(content);
                }
                else
                {
                    // If the file does not exist, provide an error message
                    Response.Write("File not found.");
                }
            }
        }
    }
}
