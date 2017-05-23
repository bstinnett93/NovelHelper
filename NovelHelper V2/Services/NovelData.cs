using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelHelper_V2.Models;

namespace NovelHelper_V2.Services
{
    public interface INovelData
    {
        IEnumerable<Novel> GetAll();
    }

    public class InMemoryNovelData : INovelData
    {
        public InMemoryNovelData()
        {
            _novels = new List<Novel>
            {
                new Novel {NovelId = 1, Title = "The Tower of Eden", Synopsis = "SciFi"},
                new Novel {NovelId = 2, Title = "The __ of the Light", Synopsis = "Fantasy"},
                new Novel {NovelId = 3, Title = "Future Novel", Synopsis = "Unknown"}
            };
        }

        public IEnumerable<Novel> GetAll()
        {
            return _novels;
        }

        private List<Novel> _novels;
    }
}