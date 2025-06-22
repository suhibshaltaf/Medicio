namespace landing.PL.Helpers
{
    public class FileSettings
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {

            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\images", FolderName);
            string fileName=$"{Guid.NewGuid()}{file.FileName}";
            string filepath = Path.Combine (folderpath, fileName);
            var filestrem=new FileStream(filepath,FileMode.Create);
            file.CopyTo(filestrem);
            filestrem.Close();

            return fileName;
        }
        public static void DeleteFile(string filename, string FolderName)
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\images", FolderName,filename);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }


        }

    }
}
