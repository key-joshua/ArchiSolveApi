﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public List<Microsoft.AspNetCore.Http.IFormFile> Attachments { get; set; }
    }
}
