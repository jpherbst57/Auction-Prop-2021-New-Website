using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class FileController : Controller
    {

        //public static string uri = "https://auctionpropfiles.blob.core.windows.net/";
        public static string uri = "http://sellers.auction-prop.com/";

        [HttpPost]
        public static string PostFile(HttpPostedFileBase file, string filePath, string uriExtension)
        {
            /*
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(filePath, Path.GetFileName(file.FileName));
                file.SaveAs(path);
                string Patth = uri + uriExtension + "/" + Path.GetFileName(file.FileName);


                //SaveToStorage(file.InputStream, Path.GetFileName(file.FileName), uriExtension);
                return Patth;
            }
            return "error";*/



            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/uploads/" + uriExtension),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string Patth = uri + "/uploads/" + uriExtension + "/" + file.FileName;

                    return Patth;
                }
                catch (Exception ex)
                {
                    return "ERROR:" + ex.Message.ToString();
                }
            else
            {
                return "You have not specified a file.";
            }



        }

        /*  private static CloudBlobContainer GetContainer(string uriExtension)
          {
              var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageAccount"]);
              var blobClient = storageAccount.CreateCloudBlobClient();
              var container = blobClient.GetContainerReference(ConfigurationManager.AppSettings[uriExtension +"Container"]);
              return container;
          }
        /*  [HttpPost]
          public ActionResult UploadFile()
          {
              if (Request.Files.Count > 0)
              {
                  var file = Request.Files[0];
                  if (file != null && file.ContentLength > 0)
                      SaveToStorage(file.InputStream, file.FileName,uriExtension);
              }
              return View();
          }

          public static void SaveToStorage(Stream inputStream, string fileName, string uriExtension)
          {
              var container = GetContainer(uriExtension);
              var blob = container.GetBlockBlobReference(fileName);

              using (inputStream)
                  blob.UploadFromStream(inputStream);
          }*/
    }
}