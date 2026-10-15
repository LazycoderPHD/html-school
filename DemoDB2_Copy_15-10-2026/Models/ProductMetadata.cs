using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDB2.Models
{
    public partial class Product
    {
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}