using Azure.Storage.Files.Shares.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcomEgTestBed
{
    public partial class MountAccessTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetFilesIn_Click(object sender, EventArgs e)
        {
            ClearOutput();
            try
            {
                var combinedNetworkPath = GetFilePath();

                if (Directory.Exists(combinedNetworkPath))
                {
                    var files = Directory.GetFiles(combinedNetworkPath);

                    List<string> filesInDirectory = new List<string>();

                    // Iterate over the items and print out the file names
                    foreach (var file in files)
                    {
                        filesInDirectory.Add(file);
                    }

                    ListViewFilesInDirectory.DataSource = filesInDirectory;
                    ListViewFilesInDirectory.DataBind();
                    divShowResult.Visible = true;
                }
                else
                {
                    divError.InnerHtml = $"FAILURE: Could not find the network path. ";
                    divError.Visible = true;
                }
            }
            catch (Exception exception)
            {
                divError.InnerHtml = $"FAILURE: {exception.Message}";
                divError.Visible = true;
            }
        }

        protected void ButtonGetFile_OnClick(object sender, EventArgs e)
        {
            ClearOutput();
            try
            {
                string sharedFilePath = (sender as Button).Text;


                // Check if the file exists
                if (File.Exists(sharedFilePath))
                {
                    // Get the file info
                    FileInfo fileInfo = new FileInfo(sharedFilePath);

                    // Clear the response
                    Response.Clear();

                    // Set the content type based on the file extension
                    Response.ContentType = MimeMapping.GetMimeMapping(fileInfo.Name);

                    // Add the content-disposition header to force download
                    Response.AddHeader("Content-Disposition", $"attachment; filename={fileInfo.Name}");

                    // Write the file to the response
                    Response.TransmitFile(fileInfo.FullName);

                    // End the response
                    Response.End();
                }
                else
                {
                    // Handle the case where the file doesn't exist
                    divError.InnerHtml = $"FAILURE: File not found at {sharedFilePath}";
                    divError.Visible = true;
                }

            }
            catch (Exception exception)
            {
                divError.InnerHtml = $"FAILURE: {exception.Message}";
                divError.Visible = true;
            }
        }

        private string GetFilePath()
        {
            return txtFolderPath.Text.Trim();
        }

        protected void ButtonWriteToMountShare_OnClick(object sender, EventArgs e)
        {
            ClearOutput();
            try
            {
                //the path
                var combinedNetworkPath = GetFilePath();

                if (!Directory.Exists(combinedNetworkPath))
                {
                    divError.InnerHtml = $"FAILURE to write: Network path does not exist";
                    divError.Visible = true;
                    return;
                }

                var filePath = combinedNetworkPath + @"\MountShare-" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss") + ".txt";

                File.WriteAllText(filePath,
                    $"{DateTime.Now.ToLongTimeString()} - Bob is bob");

                btnGetFilesIn_Click(sender, e);
            }
            catch (Exception exception)
            {
                divError.InnerHtml = $"FAILURE to write: {exception.Message}";
                divError.Visible = true;
            }
        }

        private void ClearOutput()
        {
            divError.Visible = false;
            divError.InnerHtml = "";
            ListViewFilesInDirectory.Items.Clear();
        }
    }
}