﻿using Abp.Application.Services.Dto;

namespace Pixel.Attendance.Organizations.Dto
{
    public class OrganizationUnitDto : AuditedEntityDto<long>
    {
        public long? ParentId { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public int MemberCount { get; set; }
        
        public int RoleCount { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerName { get; set; }

        public bool HasApprove { get; set; }
    }
}