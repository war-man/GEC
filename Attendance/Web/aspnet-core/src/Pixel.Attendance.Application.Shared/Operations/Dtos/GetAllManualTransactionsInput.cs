﻿using Abp.Application.Services.Dto;
using System;

namespace Pixel.Attendance.Operations.Dtos
{
    public class GetAllManualTransactionsInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public DateTime? MaxTransDateFilter { get; set; }
		public DateTime? MinTransDateFilter { get; set; }


		 public string UserNameFilter { get; set; }

		 		 public string MachineNameEnFilter { get; set; }

		 
    }
}