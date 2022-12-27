
using Venus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Venus.Models
{
    [Table("pictures")]
    [PrimaryKey(nameof(Pk))]
    public class PictureTable
    {
        [Column("pk")]
        public string Pk { get; set; } = "";
        [Column("title")]
        public string Title { get; set; } = "";
        [Column("create_time")]
        public DateTime CreateTime { get; set; } = DateTime.MinValue;
        [Column("update_time")]
        public DateTime UpdateTime { get; set; } = DateTime.MinValue;
        [Column("creator")]
        public string Creator { get; set; } = "";
        [Column("file")]
        public string File { get; set; } = "";
        [Column("status")]
        public int Status { get; set; } = 0;
    }

    public class PictureModel
    {
        public string Pk { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime CreateTime { get; set; } = DateTime.MinValue;
        public DateTime UpdateTime { get; set; } = DateTime.MinValue;
        public string Creator { get; set; } = "";
        public string File { get; set; } = "";
        public int Status { get; set; } = 0;
        public string FilePath { get; set; } = "";
    }
}
