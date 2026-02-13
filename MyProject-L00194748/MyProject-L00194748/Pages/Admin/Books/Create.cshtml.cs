using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Services;

namespace MyProject_L00194748.Pages.Admin.Books
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public MyProject.Models.Models.BookDetails Book { get; set; }
        public IEnumerable<SelectListItem> ThemesList { get; set; }
        public IEnumerable<SelectListItem> BookTypeList { get; set; }

        public void OnGet()
        {
            ThemesList = _unitOfWork.ThemesRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            BookTypeList = _unitOfWork.BookTypesRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
        public IActionResult OnPost()
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string new_filename = Path.GetFileName(files[0].FileName);

            //string new_filename = Guid.NewGuid().ToString();
            var uplaod = Path.Combine(wwwRootFolder, @"images\book");
            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(uplaod, new_filename), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
            Book.CoverImage = @"\images\book\" + new_filename;
            if (ModelState.IsValid)
            {
                _unitOfWork.BookDetailsRepo.Add(Book);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
