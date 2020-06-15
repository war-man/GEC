﻿using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pixel.Attendance.Operations.Dtos;
using Pixel.Attendance.Dto;

namespace Pixel.Attendance.Operations
{
    public interface ITransactionsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTransactionForViewDto>> GetAll(GetAllTransactionsInput input);

        Task<GetTransactionForViewDto> GetTransactionForView(int id);

		Task<GetTransactionForEditOutput> GetTransactionForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTransactionDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetTransactionsToExcel(GetAllTransactionsForExcelInput input);

		
    }
}