using System.Collections.Generic;

namespace WebApplicationBasic.Models
{
    public class SavedImage
    {
        public int SavedImageId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public IList<SavedImageTag> Tags { get; set; }
        public string StorageUrl { get; set; }
    }

    public class SavedImageTag
    {
        public int SavedImageTagId { get; set; }
        public int SavedImageId { get; set; }
        public string Tag { get; set; }
    }
}
