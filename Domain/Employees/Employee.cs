﻿using Domain.Common;
using Domain.Sales;

namespace Domain.Employees;

public class Employee : IEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public List<Sale> Sales { get; set; }
}