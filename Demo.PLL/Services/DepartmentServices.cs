﻿using Demo.BLL.DTOs;
using Demo.BLL.Factories;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Models;
using Demo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{


    public class IDepartmentServices(IDepartmentRepository _departmentRepository)
    {
        // Get All Departments
        //public IEnumerable<DepartmentDto> GetAllDepartments()
        //{
        //    var depts = _departmentRepository.GetAll();
        //    var departmentsToReturn = depts.Select(D => new DepartmentDto()
        //    {
        //        DeptId = D.Id,
        //        Name = D.Name,
        //        Code = D.Code,
        //        Description = D.Description,
        //        DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
        //    });
        //    return departmentsToReturn;
        //}

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var depts = _departmentRepository.GetAll();
            var departmentsToReturn = depts.Select(D => D.ToDepartmentDto()); //Extension Method
            return departmentsToReturn;

        }

        public DepartmentDetailsDto? GetById(int id)
        {
            var dept = _departmentRepository.GetById(id);
            //if (dept is null)
            //    return null;
            //else
            //{
            //    var deptToReturn = new DepartmentDetailsDto()
            //    {
            //        Id = dept.Id,
            //        Name = dept.Name,
            //        Code = dept.Code,
            //        Description = dept.Description,
            //        DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            //        LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
            //        CreatedBy = dept.CreatedBy,
            //        LastModifiedBy = dept.LastModifiedBy,
            //        IsDeleted = dept.IsDeleted
            //    };
            //    return deptToReturn;
            //}

            //// same as [ using ternary operator]

            // Manual Mapping
            // -Constructor Mapping
            // -Extension Method Mapping
            // -Auto Mapper [Nuget Package]
            //return dept is null ? null : new DepartmentDetailsDto()
            //{
            //    Id = dept.Id,
            //    Name = dept.Name,
            //    Code = dept.Code,
            //    Description = dept.Description,
            //    DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
            //    CreatedBy = dept.CreatedBy,
            //    LastModifiedBy = dept.LastModifiedBy,
            //    IsDeleted = dept.IsDeleted
            //};

            //// Constructor Mapping
            //return dept is null ? null : new DepartmentDetailsDto(dept);

            //// Extension Method Mapping
            return dept is null ? null : dept.ToDepartmentDetailsDto();

        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Add(entity);
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Update(entity);
        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
                return false;
            else
            {
                var res = _departmentRepository.Remove(department);
                return res > 0 ? true : false;
            }
        }
    }
}
