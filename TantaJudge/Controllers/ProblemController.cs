using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace TantaJudge.Controllers
{
    public class ProblemController : Controller
    {
        private readonly MyContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProblemController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Problemas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Problemas.ToListAsync());
        }

        // GET: Problemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problema = await _context.Problemas
                .FirstOrDefaultAsync(m => m.ProblemaId == id);
            if (problema == null)
            {
                return NotFound();
            }

            return View(problema);
        }

        // GET: Problemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Problemas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProblemaId,Titulo,Tag,Dificultad,Descripcion,Pdfpro")] Problema problema, IFormFile archivoPdf)
        {
            if (ModelState.IsValid)
            {
                if (archivoPdf != null && archivoPdf.Length > 0)
                {
                    await GuardarPdf(problema, archivoPdf);
                }
                _context.Add(problema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problema);
        }

        private async Task GuardarPdf(Problema problema, IFormFile archivoPdf)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string extension = Path.GetExtension(archivoPdf.FileName);
            string nombrePdf = $"{problema.ProblemaId}{extension}";
            problema.Pdfpro = nombrePdf;

            string path = Path.Combine(wwwRootPath, "pdfs", nombrePdf);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await archivoPdf.CopyToAsync(fileStream);
            }
        }

        // GET: Problemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problema = await _context.Problemas.FindAsync(id);
            if (problema == null)
            {
                return NotFound();
            }
            return View(problema);
        }

        // POST: Problemas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProblemaId,Titulo,Tag,Dificultad,Descripcion,Pdfpro")] Problema problema, IFormFile archivoPdf)
        {
            if (id != problema.ProblemaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (archivoPdf != null && archivoPdf.Length > 0)
                    {
                        await GuardarPdf(problema, archivoPdf);
                    }

                    _context.Update(problema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemaExists(problema.ProblemaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(problema); // CorrecciÃ³n: cambiar "Problema" a "problema"
        }

        // GET: Problemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problema = await _context.Problemas
                .FirstOrDefaultAsync(m => m.ProblemaId == id);
            if (problema == null)
            {
                return NotFound();
            }

            return View(problema);
        }

        // POST: Problemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problema = await _context.Problemas.FindAsync(id);
            if (problema != null)
            {
                _context.Problemas.Remove(problema);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProblemaExists(int id)
        {
            return _context.Problemas.Any(e => e.ProblemaId == id);
        }
    }
}