using Gliese.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Markdig;
using Gliese.Utils;

namespace Gliese.Models {
 
    public class PictureViewModel
    {
        [Column("pk")]
        public string Pk { get; set; } = ""; 
        [Column("views")]
        public int? Views { get; set; } = 0; 

    }
}
