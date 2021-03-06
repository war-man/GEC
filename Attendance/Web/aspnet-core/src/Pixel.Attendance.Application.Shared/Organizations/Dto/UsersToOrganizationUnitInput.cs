﻿using System.ComponentModel.DataAnnotations;

namespace Pixel.Attendance.Organizations.Dto
{
    public class UsersToOrganizationUnitInput
    {
        public long[] UserIds { get; set; }

        [Range(1, long.MaxValue)]
        public int OrganizationUnitId { get; set; }
    }
}