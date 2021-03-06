﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Pixel.Attendance.Operations.Dtos
{
    public class GetUserShiftForViewDto
    {
		public UserShiftDto UserShift { get; set; }

		public string UserName { get; set;}

		public string ShiftNameEn { get; set;}
        [NotMapped]
        public string[] ShiftNames { get; set; }



    }
}