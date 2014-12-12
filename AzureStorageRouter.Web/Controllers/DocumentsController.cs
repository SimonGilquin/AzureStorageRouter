using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using AzureStorageRouter.Web.Models;
using Microsoft.Data.OData;

namespace AzureStorageRouter.Web.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AzureStorageRouter.Web.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Document>("Documents");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DocumentsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Documents
        public async Task<IHttpActionResult> GetDocuments(ODataQueryOptions<Document> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Document>>(documents);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Documents(5)
        public async Task<IHttpActionResult> GetDocument([FromODataUri] string key, ODataQueryOptions<Document> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Document>(document);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Documents(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<Document> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(document);

            // TODO: Save the patched entity.

            // return Updated(document);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Documents
        public async Task<IHttpActionResult> Post(Document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(document);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Documents(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Document> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(document);

            // TODO: Save the patched entity.

            // return Updated(document);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Documents(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
