using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NovelHelper_V2.Models
{
    [Table("Novels")]
    public class Novel : IEnumerable
    {
        [Key]
        public int NovelId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime DateAccessed { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}