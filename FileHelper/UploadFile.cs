using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.FileHelper
{
    public class UploadFile
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(folder))
           
            {
                return false;
            }
            try 
            {
                string path = string.Empty;
                if (file != null)
                {
                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                    file.SaveAs(path);
                    using(MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }




                }
                return true;
                
            
            }
        catch
            {
                return false;
            }
        }
    }
}