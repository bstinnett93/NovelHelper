﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NovelHelper_V2.Models
{
    [Table("Setting")]
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Novel")]
        public int NovelId { get; set; }

        public virtual Novel Novel { get; set; }
    }
}