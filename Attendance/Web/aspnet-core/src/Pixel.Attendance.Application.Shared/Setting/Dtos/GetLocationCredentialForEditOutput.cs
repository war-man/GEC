﻿using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Pixel.Attendance.Setting.Dtos
{
    public class GetLocationCredentialForEditOutput
    {
		public CreateOrEditLocationCredentialDto LocationCredential { get; set; }

		public string LocationDescriptionAr { get; set;}


    }
}