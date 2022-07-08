using Application.Sales.Commands.CreateSale;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Sales.Models;

public class CreateSaleViewModel
{
    public int SelectedCustomerId { get; set; }
    public int SelectedEmployeeId { get; set; }
    public int[] SelectedProductsIds { get; set; }
    public List<SelectListItem> Customers { get; set; }
    public List<SelectListItem> Employees { get; set; }
    public List<SelectListItem> Products { get; set; }
}