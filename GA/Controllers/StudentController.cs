using GA.Database;
using GA.Entity.Student;
using GA.Models.Student;
using Microsoft.AspNetCore.Mvc;

namespace GA.Controllers
{
    public class StudentController : Controller
    {
        private readonly GADbContext _dbContext;
        public StudentController(GADbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var classes = _dbContext.GA_STDCLASS
                    .Select(c => new stdClassmodel { classid = c.STD_CLID, stdent_Class = c.STD_CLNAME })
                    .ToList();
            ViewBag.Classes = classes;
            // Retrieve data from the database
            var PreAdmisiionstudentList = _dbContext.GA_STDPREADMISSION.ToList();
            ViewBag.Preadmission = PreAdmisiionstudentList;

            return View();

        }

        [HttpPost]
        public IActionResult Index(StudentPreAdmission viewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve UNQ_CODE and UNQ_SERIES values from the database based on class ID (viewModel.STD_CLASS)
                var unqSeriesRecord = _dbContext.STD_UNQSERIES
                    .FirstOrDefault(u => u.UNQ_STDCLID.ToString() == viewModel.STD_CLASS);
                var classname = _dbContext.GA_STDCLASS
                    .FirstOrDefault(u => u.STD_CLID.ToString() == viewModel.STD_CLASS).STD_CLNAME;
                if (unqSeriesRecord != null)
                {
                    // Increment UNQ_SERIES by 1
                    int incrementedSeries = unqSeriesRecord.UNQ_SERIES + 1;

                    // Generate the unique code by concatenating UNQ_CODE and incremented UNQ_SERIES
                    string uniqueCode = $"{unqSeriesRecord.UNQ_CODE}{incrementedSeries}";

                    var newStudent = new GA_STDPREADMISSION
                    {
                        STD_FNAME = viewModel.STD_FNAME,
                        STD_LNAME = viewModel.STD_LNAME,
                        STD_FANAME = viewModel.STD_FANAME,
                        STD_MOBILENO = viewModel.STD_MOBILENO,
                        STD_CLASS = classname,
                        STD_MEDIUM = viewModel.STD_MEDIUM,
                        STD_AFEES = viewModel.STD_AFEES,
                        STD_STSID = 10,
                        STD_ENTRYDATE = DateTime.Now,
                        STD_UNIQUECODE = uniqueCode // Set the unique code property
                    };

                    // Update the UNQ_SERIES value in the database
                    unqSeriesRecord.UNQ_SERIES = incrementedSeries;
                    _dbContext.SaveChanges();

                    // Add the new student to the database
                    _dbContext.GA_STDPREADMISSION.Add(newStudent);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Success");
                }
            }

            return View(viewModel);
        }

    }
}
