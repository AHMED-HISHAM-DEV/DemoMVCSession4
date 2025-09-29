﻿using Demo.BLL.DTOs;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Factories
{
    static class DepartmentFactory
    {
        // Extension Method [popular way]
        public static DepartmentDto ToDepartmentDto (this Department department)
        {
            return new DepartmentDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }


        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department dept)
        {
            return new DepartmentDetailsDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                Description = dept.Description,
                DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
                CreatedBy = dept.CreatedBy,
                LastModifiedBy = dept.LastModifiedBy,
                IsDeleted = dept.IsDeleted,
            };

        }


        public static Department ToEntity(this CreatedDepartmentDto dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }


        public static Department ToEntity(this UpdatedDepartmentDto dto)
        {
            return new Department()
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
