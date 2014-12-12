using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AzureStorageRouter.Web.Models
{
    public class Document
    {
        [Key]
        public string FileName { get; set; }

    }
}