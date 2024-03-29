﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries.GetEmployeeList;

public class GetEmployeesListQuery : IGetEmployeesListQuery
{
    private readonly IDatabaseService _database;

    public GetEmployeesListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public async Task<List<EmployeeModel>> Execute()
    {
        var employees = _database.Employees.Select(p => new EmployeeModel
            {
                Id = p.Id,
                Name = p.Name
            });

        return await employees.ToListAsync();
    }
}