namespace RecordMedical.Utility
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class FileUploadUtility
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileUploadUtility(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadFileAsync(IFormFile file,string fileTitle)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file. Please provide a valid file.");
            }

            Console.WriteLine("hello here");

            // Get the uploads folder path
            var uploadsFolderPath = Path.Combine("C:\\Users\\ArijitPanda\\source\\repos\\RecordMedical\\RecordMedical", "uploads");
            Console.WriteLine("hello here part 1");
            // Ensure the uploads folder exists
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }
            Console.WriteLine("hello here part 2");
            // Validate file type (optional, adjust as needed)
            var allowedExtensions = new[] { ".pdf", ".jpeg", ".jpg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName)?.ToLower();

            if (!string.IsNullOrEmpty(fileExtension) && !allowedExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file type. Only PDF, JPEG, JPG, and PNG files are allowed.");
            }

            // Generate a unique file name
            var fileName =  fileTitle+"-"+Guid.NewGuid().ToString() + fileExtension;

            // Combine the path and file name to get the full path
            var filePath = Path.Combine(uploadsFolderPath, fileName);
            Console.WriteLine("hello here part 3");
            // Save the file to disk
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }


            // Return the uploaded file name (optional, adjust as needed)
            return filePath;
        }
    }

}
