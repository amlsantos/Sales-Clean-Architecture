﻿using System.Net;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Sales;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{
    private readonly IGetSalesListQuery _listQuery;
    private readonly IGetSaleDetailQuery _detailQuery;
    private readonly ICreateSaleCommand _createCommand;

    public SalesController(IGetSalesListQuery query, IGetSaleDetailQuery detailQuery, ICreateSaleCommand createCommand)
    {
        _listQuery = query;
        _detailQuery = detailQuery;
        _createCommand = createCommand;
    }

    [HttpGet]
    public async Task<IEnumerable<SalesListItemModel>> Get()
    {
        return await _listQuery.Execute();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<SaleDetailModel> Get(int id)
    {
        return await _detailQuery.Execute(id);
    }

    [HttpPost]
    public async Task<HttpResponseMessage> Create(CreateSaleModel sale)
    {
        await _createCommand.Execute(sale);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}