﻿using System.ComponentModel.DataAnnotations;

namespace Pixel.Attendance.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}