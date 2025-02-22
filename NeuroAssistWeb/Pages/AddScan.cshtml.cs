using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeuroAssist.Data;
using NeuroAssist.Services;
using NeuroAssistWeb.Services;

namespace NeuroAssistWeb.Pages
{
    public class AddScanModel : PageModel
    {
        public readonly MainDbContext _context;
        public readonly UploadFileService _uploadService;
        public readonly BrainscanService _scanService;

        public AddScanModel(MainDbContext context, 
            UploadFileService uploadService,
            BrainscanService scanService)
        {
            _context = context;
            _uploadService = uploadService;
            _scanService = scanService;

        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {

            //var project = await _context.ProjectScans.AddAsync(new NeuroAssist.Models.ProjectScan
            //{
            //    Title = Request.Form["scanTitle"]
            //});
            //await _context.SaveChangesAsync();

            //var scanPaths = await _uploadService.UploadFile(Request.Form.Files.ToList());
            //var predictions = await _scanService.UploadScans(scanPaths);
            

            
            //var res = await _geminiService.AnalyzeImage(Request.Form.Files[0], "find the tumor class either giloma, menigioma, or pitutiary, pick one class " +
            //    "find the size of the tumor and location of the tumor return your answer in json format, see example { size : 30, location : beneath the pineal gland, tumor_class: menigioma }");


        }
    }
}
