using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webBuildings;
using Microsoft.EntityFrameworkCore;

namespace webBuildings.Pages;

public class IndexModel : PageModel
{
    public List<Building> BuildingList{get;set;}
    private readonly SystemBuildingContext _context;

    public IndexModel(SystemBuildingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void OnGet()
    {
        
        BuildingList = _context.Buildings.ToList();
    }
}
