using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelHelper_V2.Models
{
    public class AddSetting
    {
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NovelId { get; set; }
        public virtual Novel Novel { get; set; }
    }
}