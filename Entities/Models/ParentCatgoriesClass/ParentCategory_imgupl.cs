using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ParentCatgoriesClass
{
    public class ParentCategory_imgupl
    {
        public FileUploads fileUploads { get; set; }
        public Parent_Catg parent_Catg { get; set; }
        public List<Parent_Catg> parent_CatgList { get; set; }
    }
}
