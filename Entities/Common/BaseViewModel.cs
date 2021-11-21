using Common.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Common
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public long ObjectId { get; set; }
        public string Title { get; set; }
        public byte ObjectTypeId { get; set; }
        public int? Type { get; set; }
        public byte? Status { get; set; }
        public int? Mode { get; set; }
        public byte? Version { get; set; }
        public string ImageSizeCode { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public string ImageSourceFileName = string.Empty;
        public string ImageUrl
        {
            get
            {
                try
                {
                    var url = string.Empty;
                    if (!string.IsNullOrEmpty(ImageSourceFileName))
                    {
                        if (string.IsNullOrEmpty(ImageSizeCode))
                        {
                            url = BasicConfiguration.ImagesStorageUrl() + ImageSourceFileName;
                        }
                        else
                        {
                            var extIndex = ImageSourceFileName.LastIndexOf(".");
                            url = BasicConfiguration.ImagesStorageUrl() + ImageSourceFileName.Substring(0, extIndex < 0 ? ImageSourceFileName.Length : extIndex) + "-" + ImageSizeCode + "." + "jpeg";
                        }
                    }

                    return url;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

        public DateTime? PublishedDateTime { get; set; }

        public DateTime? ExpirationDateTime { get; set; }
      
        public int CultureId { get; set; }
        public int? ListOrder { get; set; }
    }
}
