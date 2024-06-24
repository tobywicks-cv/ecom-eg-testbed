using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azure;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace EcomEgTestBed
{
    public partial class TestFileShareConnectivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetFilesIn_Click(object sender, EventArgs e)
        {
            var directoryClient = GetDirectoryClient();

            // Get files and directories
            Pageable<ShareFileItem> fileItems = directoryClient.GetFilesAndDirectories();

            fileItems.ToList();

            List<string> filesInDirectory = new List<string>();

            // Iterate over the items and print out the file names
            foreach (ShareFileItem fileItem in fileItems)
            {
                if (fileItem.IsDirectory)
                {

                }
                else
                {
                    // Print out file names
                    //Console.WriteLine($"File: {fileItem.Name}");
                    filesInDirectory.Add(fileItem.Name);
                }
            }

            ListViewFilesInDirectory.DataSource = filesInDirectory;
            ListViewFilesInDirectory.DataBind();
            divShowResult.Visible = true;
        }

        protected void ButtonGetFile_OnClick(object sender, EventArgs e)
        {
            divError.Visible = false;
            try
            {
                var directoryClient = GetDirectoryClient();

                var fileName = (sender as Button).Text;

                // Get the ShareFileClient for the specific file
                ShareFileClient fileClient = directoryClient.GetFileClient(fileName);

                // Download the file
                ShareFileDownloadInfo download = fileClient.Download();

                // Initiate the download
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName}");

                using (Stream fileStream = download.Content)
                {
                    fileStream.CopyTo(Response.OutputStream);
                    Response.Flush();
                }

                Response.End();
            }
            catch (Exception ex)
            {
                divError.InnerHtml = $"An error occured. {ex.Message}";
                divError.Visible = true;
            }

        }

        private ShareDirectoryClient GetDirectoryClient()
        {
            var info = GetShareFileInfo();

            ShareServiceClient serviceClient = new ShareServiceClient(
                new Uri(info.ServiceUri),
                new StorageSharedKeyCredential(info.AccountName, info.AccountKey)
            );

            // Get the ShareClient for the specified share
            ShareClient shareClient = serviceClient.GetShareClient(info.ShareName);

            // Get the ShareDirectoryClient for the specified directory
            return shareClient.GetDirectoryClient(info.DirectoryName);
        }

        private ShareFileInfo GetShareFileInfo()
        {
            ShareFileInfo info
                = new ShareFileInfo(txtAccountKey.Text.Trim(),
                    txtShareName.Text.Trim(),
                    txtAccountName.Text.Trim(),
                    txtDirectoryName.Text.Trim(),
                    "");
            return info;
        }


    }


    public class ShareFileInfo
    {
        public string AccountKey { get; set; }
        public string ShareName { get; set; }
        public string AccountName { get; set; }
        public string DirectoryName { get; set; }
        public string FileName { get; set; }
        public string ServiceUri { get; set; }

        public ShareFileInfo(string accountKey, string shareName, string accountName, string directoryName, string fileName)
        {
            AccountKey = accountKey;
            ShareName = shareName;
            AccountName = accountName;
            DirectoryName = directoryName;
            FileName = fileName;
            ServiceUri = $"https://{accountName}.file.core.windows.net";
        }
    }

}