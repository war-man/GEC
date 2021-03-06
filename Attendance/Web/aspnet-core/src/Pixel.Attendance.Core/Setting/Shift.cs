﻿using Pixel.Attendance.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Pixel.Attendance.Setting
{
	[Table("Shifts")]
    public class Shift : FullAuditedEntity 
    {

		[Required]
		public virtual string NameAr { get; set; }
		
		[Required]
		public virtual string NameEn { get; set; }
		
		[Required]
		public virtual string Code { get; set; }
		
		public virtual Day DayOff { get; set; }
		
		public virtual Day DayRest { get; set; }
		
		public virtual int TimeIn { get; set; }
		
		public virtual int TimeOut { get; set; }
		
		public virtual int EarlyIn { get; set; }
		
		public virtual int LateIn { get; set; }
		
		public virtual int EarlyOut { get; set; }
		
		public virtual int LateOut { get; set; }
		
		public virtual int TimeInRangeFrom { get; set; }
		
		public virtual int TimeInRangeTo { get; set; }
		
		public virtual int TimeOutRangeFrom { get; set; }
		
		public virtual int TimeOutRangeTo { get; set; }
		public int DeductType { get; set; }
		public bool IsOverTimeAllowed { get; set; }
		public ShiftTypeEnum ShiftType { get; set; }

	}
}