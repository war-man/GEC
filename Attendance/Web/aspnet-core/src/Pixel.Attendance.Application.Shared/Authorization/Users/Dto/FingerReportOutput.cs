﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel.Attendance.Authorization.Users.Dto
{
    public class FingerReportOutput
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string UserName { get; set; }
        public long? UserId { get; set; }
        public string Scan1 { get; set; }
        public string Scan2 { get; set; }
        public string Scan3 { get; set; }
        
        public string Scan4 { get; set; }
        public string Scan5 { get; set; }
        public string Scan6 { get; set; }
    }
}
