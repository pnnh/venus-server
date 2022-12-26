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

    [Table("picture_files")]
    [PrimaryKey(nameof(Pk))]
    public class PictureFileModel
    {
        [Column("pk")]
        public string Pk { get; set; } = ""; 
        [Column("create_time")]
        public DateTime CreateTime { get; set; } = DateTime.MinValue;
        [Column("update_time")]
        public DateTime UpdateTime { get; set; } = DateTime.MinValue;
        [Column("creator")]
        public string Creator { get; set; } = "";

        [Column("status")]
        public int Status { get; set; } = 0;
    }
}
