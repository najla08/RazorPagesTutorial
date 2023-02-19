using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Services;

namespace RazorPagesTutorial.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _ctx;
        private readonly IFileService _fileService;


        public EditModel(DatabaseContext ctx, IFileService fileService)
        {
            _ctx = ctx;
            _fileService = fileService;
        }

        [BindProperty]
        public Data.Person Person { get; set; }
        public IActionResult OnGet(int id)
        {
            var person = _ctx.Person.Find(id);
            if (person == null)
                return NotFound();
            Person = person;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                if (Person == null)
                    return NotFound();
                var oldImage = Person.ProfilePicture;
                if (Person.ImageFile != null)
                {
                    // we have to save the new image and remove the old image from the folder
                    var fResult = _fileService.SaveImage(Person.ImageFile);
                    if (fResult.Item1 == 1)
                    {
                        Person.ProfilePicture = fResult.Item2;
                    }
                }
                _ctx.Person.Update(Person);
                await _ctx.SaveChangesAsync();
                if (!string.IsNullOrEmpty(oldImage) && oldImage != Person.ProfilePicture) {
                    _fileService.DeleteImage(oldImage);
                }
                //method to transfer data to the html pages
                TempData["success"] = "Saved successfully";
                return RedirectToPage("DisplayAll");

            }
            catch (Exception ex)
            {

                TempData["error"] = "Error has occured";
                return Page();
            }
            
        }
    }
}
