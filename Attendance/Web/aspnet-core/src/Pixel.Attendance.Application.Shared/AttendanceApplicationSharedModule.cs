﻿using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Pixel.Attendance
{
    [DependsOn(typeof(AttendanceCoreSharedModule))]
    public class AttendanceApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AttendanceApplicationSharedModule).GetAssembly());
        }
    }
}