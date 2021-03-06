﻿using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Pixel.Attendance.DataExporting.Excel.EpPlus;
using Pixel.Attendance.Setting.Dtos;
using Pixel.Attendance.Dto;
using Pixel.Attendance.Storage;

namespace Pixel.Attendance.Setting.Exporting
{
    public class SystemConfigurationsExcelExporter : EpPlusExcelExporterBase, ISystemConfigurationsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SystemConfigurationsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSystemConfigurationForViewDto> systemConfigurations)
        {
            return CreateExcelPackage(
                "SystemConfigurations.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("SystemConfigurations"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("TotalPermissionNumberPerMonth"),
                        L("TotalPermissionNumberPerWeek"),
                        L("TotalPermissionNumberPerDay"),
                        L("TotalPermissionHoursPerMonth"),
                        L("TotalPermissionHoursPerWeek"),
                        L("TotalPermissionHoursPerDay")
                        );

                    AddObjects(
                        sheet, 2, systemConfigurations,
                        _ => _.SystemConfiguration.TotalPermissionNumberPerMonth,
                        _ => _.SystemConfiguration.TotalPermissionNumberPerWeek,
                        _ => _.SystemConfiguration.TotalPermissionNumberPerDay,
                        _ => _.SystemConfiguration.TotalPermissionHoursPerMonth,
                        _ => _.SystemConfiguration.TotalPermissionHoursPerWeek,
                        _ => _.SystemConfiguration.TotalPermissionHoursPerDay
                        );

					

                });
        }
    }
}
