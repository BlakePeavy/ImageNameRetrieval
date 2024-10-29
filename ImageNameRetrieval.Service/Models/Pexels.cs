using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNameRetrieval.Service.Models
{
    // Format from
    // https://www.pexels.com/api/documentation/?language=csharp#photos-search

    /// <summary>
    /// Pexels API response
    /// </summary>
    public class Pexels
    {
        public int TotalResults { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<Photo> Photos { get; set; }
        public string NextPage { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Photographer { get; set; }
        public string PhotographerUrl { get; set; }
        public int PhotographerId { get; set; }
        public string AvgColor { get; set; }
        public Src Src { get; set; }
        public bool Liked { get; set; }
        public string Alt { get; set; }
    }

    public class Src
    {
        public string Original { get; set; }
        public string Large2x { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Portrait { get; set; }
        public string Landscape { get; set; }
        public string Tiny { get; set; }
    }
}
