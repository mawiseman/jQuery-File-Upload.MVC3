using System;
using System.IO;
using System.Web;

namespace jQuery_File_Upload.MVC3.Upload
{
    /// <summary>
    /// https://github.com/maxpavlov/jQuery-File-Upload.MVC3
    /// </summary>
    public class FilesStatus
    {
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string deleteUrl { get; set; }
        public string deleteType { get; set; }

        public FilesStatus() { }

        public FilesStatus(FileInfo fileInfo) { SetValues(fileInfo.Name, (int)fileInfo.Length, fileInfo.FullName); }

        public FilesStatus(string fileName, int fileLength, string fullPath) { SetValues(fileName, fileLength, fullPath); }

        private void SetValues(string fileName, int fileLength, string fullPath)
        {
            name = fileName;
            type = "image/png";
            size = fileLength;
            url = UploadHandler + "?f=" + fileName;
            deleteUrl = UploadHandler + "?f=" + fileName;
            deleteType = "DELETE";

            var ext = Path.GetExtension(fullPath);

            var fileSize = ConvertBytesToMegabytes(new FileInfo(fullPath).Length);
            if (fileSize > 3 || !IsImage(ext)) thumbnailUrl = VirtualPathUtility.ToAbsolute("~/Content/img/generalFile.png");
            else thumbnailUrl = @"data:image/png;base64," + EncodeFile(fullPath);
        }

        private bool IsImage(string ext)
        {
            return ext == ".gif" || ext == ".jpg" || ext == ".png";
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static string UploadHandler
        {
            get
            {
                return VirtualPathUtility.ToAbsolute("~/Upload/UploadHandler.ashx");
            }
        }
    }
}