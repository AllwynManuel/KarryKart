using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ParentCatgoriesClass
{
    public class FileUploads
    {
        public int ImgId { get; set; }
        public IFormFile files { get; set; }
        public string Imgname { get; set; }
    }
}
