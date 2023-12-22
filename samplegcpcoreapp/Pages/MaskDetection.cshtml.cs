using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.AIPlatform.V1;
using Google.Api.Gax.ResourceNames;
using Google.Api.Gax;
using System;
using Google.Apis.Bigquery.v2.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Google.Api;
using Google;
using System.Web.Helpers;

namespace samplegcpcoreapp.Pages
{
    public class MaskDetectionModel : PageModel
    {
        public bool hasData = false;
        public string datasetname = "";
        private readonly IWebHostEnvironment webHostEnvironment;
        //private readonly ApplicationDbContext dbContext;
        public IFormFile newImage { get; set; }
        public string imageName = "";
        WebImage photo = null;
        string newFileName = "";
        public string imagePath = "";

        /*public MaskDetectionModel(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }
        */
        public void OnGet()
        {
        }

        public void OnPost()
        {
            hasData = true;
            string projectId = "samplegcpapp-381218";
            string region = "us-central1";

            DatasetServiceClient client = new DatasetServiceClientBuilder
            {
                Endpoint = $"{region}-aiplatform.googleapis.com"
            }.Build();

            LocationName location = new LocationName(projectId, region);
            PagedEnumerable<ListDatasetsResponse, Google.Cloud.AIPlatform.V1.Dataset> datasets = client.ListDatasets(location);
            foreach (Google.Cloud.AIPlatform.V1.Dataset dataset in datasets)
            {
                datasetname = dataset.Name;
            }

            

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);
                imagePath = @"images\" + newFileName;

                photo.Save(@"~\" + imagePath);
            } 
            /*
            string uniqueFileName = null;

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + newImage.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                newImage.CopyTo(fileStream); 
            }
            imageName = newImage.Name;*/

        }
    }
}
