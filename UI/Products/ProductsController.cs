﻿using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace UI.Products;

public class ProductsController : Controller
{
    private readonly IGetProductsListQuery _query;
    private readonly ICreateProductCommand _command;

    public ProductsController(IGetProductsListQuery query, ICreateProductCommand command)
    {
        _query = query;
        _command = command;
    }

    public IActionResult Index()
    {
        var products = _query.Execute();
        return View(products);
    }
    
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(CreateProductModel model)
    {
        _command.Execute(model);
        return RedirectToAction("Index");
    }
}