using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OPC_DA_Proxy.Models
{
    public class PicturesRepository
    {

        public static string[] getBrowsablePictures()
        {
            var server = HttpContext.Current.Server;
            var picturesPath = server.MapPath("~/pictures");

            DirectoryInfo d = new DirectoryInfo(picturesPath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.svg"); //Getting Text files
            string[] files = new string[Files.Length];
            for (int j = 0; j < Files.Length; j++)
            {
                files[j] = Files[j].Name.Replace(".svg", "");
            }
            return files;
        }

        public static string getPictureForName(string pictureName)
        {
            try
            {
                var server = HttpContext.Current.Server;
                var picturesPath = server.MapPath("~/pictures");
               // var filePath = Path.Combine(picturesPath,id);
                var filePath = Path.Combine(picturesPath, $"{pictureName}.svg");
                var svg = File.ReadAllText(filePath);
                return svg;
            }
            catch (Exception fileNotFoundException)
            {
                return $"{pictureName} could not be found.";
            }
        }
    
    }     
}