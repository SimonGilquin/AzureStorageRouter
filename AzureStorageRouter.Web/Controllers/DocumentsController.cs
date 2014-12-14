using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageRouter.Web.Controllers
{
    [Authorize]
    public class DocumentsController : ApiController
    {
        private readonly CloudBlobClient client;
        private CloudBlobContainer container;

        public DocumentsController()
        {
            var account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["DocumentStoreConnectionString"]);
            client = account.CreateCloudBlobClient();
            container = client.GetContainerReference("documents");
        }

        // GET: api/Documents
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Documents/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Documents
        [Route("api/documents", Order = 1)]
        public async Task<IEnumerable<string>> Post()
        {
            /* Only process multipart content */
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var document = await Request.Content.ReadAsMultipartAsync();
            await container.CreateIfNotExistsAsync();

            var paths = new List<string>();
            foreach (var httpContent in document.Contents)
            {
                var name = httpContent.Headers.ContentDisposition.FileName ?? Guid.NewGuid().ToString();
                name = name.Trim('\"'); // Encoded filename will have double quotes around the name
                var blob = container.GetBlockBlobReference(name);
                await blob.UploadFromStreamAsync(await httpContent.ReadAsStreamAsync());
                if (httpContent.Headers.ContentType.MediaType != null)
                {
                    blob.Properties.ContentType = httpContent.Headers.ContentType.MediaType;
                    await blob.SetPropertiesAsync();
                }

                paths.Add(blob.Uri.ToString());
            }

            return paths;
        }

        // PUT: api/Documents/path/to/document
        [Route("api/documents/{*path}")]
        public async Task<string> Put(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var documentStream = await Request.Content.ReadAsStreamAsync();
            if (documentStream.Length == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlockBlobReference(path);
            await blob.UploadFromStreamAsync(documentStream);
            return blob.Uri.ToString();
        }

        // DELETE: api/Documents/5
        public void Delete(int id)
        {
        }
    }
}
