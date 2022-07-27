using BLL.DTO;
using BLL.Service;
using Digital_City_Wassime_TFE.Models;
using Digital_City_Wassime_TFE.Models.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Digital_City_Wassime_TFE.Controllers
{
    public class HomeController : Controller
    {
        public List<PatientOut> maListe;
        
        private readonly ILogger<HomeController> _logger;
        public PatientService service { get; set; }
        public PatientAllService serviceAll { get; set; }

        public HomeController(ILogger<HomeController> logger , PatientService service, PatientAllService serviceAll)
        {
            _logger = logger;
            this.service = service;
            this.serviceAll = serviceAll;
        }

        public IActionResult Index()
        {
            IEnumerable<Patient> patients = service.GetAll().Select(p => p.ToModel());
            IEnumerable<Patient> listePatientTrier = patients.OrderBy(si => si.level).Reverse();

            return View(listePatientTrier);
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(PatientForm patientform)
        {
            if(ModelState != null)
            {               
               PatientDTO patient =   new PatientDTO()
                {
                    lastName = patientform.lastName,
                    firstName = patientform.firstName,
                    problem = patientform.problem,
                    level = patientform.level,
                    date_entry = DateTime.Now,
                    statut = patientform.statut
                };
                service.Add(patient).ToModel(); 

            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Remove(int id , List<PatientOut> test )
        {
            foreach (var item in service.GetAll())
            {
                if (item.id == id)
                {

                    PatientAllDTO testons = new PatientAllDTO()
                    {
                        id = item.id,
                        firstName = item.firstName,
                        lastName = item.lastName,
                        level = item.level,
                        statut = item.statut,
                        date_entry = item.date_entry,
                        problem = item.problem
                    }; 
                    serviceAll.Add(testons).ToModelAll();

                   
                    
                    

                      
                    
                }
            };

            

            
            

            service.Remove(id);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Update( Patient patient )
        {
            foreach (var item in service.GetAll())
            {
                if(item.id== patient.id)
                {
                    return View(item.ToModel());
                }
            }
            
            return View(); 
        }

        [HttpPost]

        public IActionResult Update(int id , PatientDTO patientDTO)
        {
            service.Update(id, patientDTO); 

            return RedirectToAction(nameof(Index));
        }


        public IActionResult PatientOfDay()
        {
            //if(patientofday != null)
            //{
            //    return View(patientofday); 
            //}
            IEnumerable<PatientAll>patients = serviceAll.GetAll().Select(p => p.ToModelAll());
            IEnumerable<PatientAll> listePatientTrier = patients.OrderBy(si => si.level).Reverse();

            return View(listePatientTrier);
        }


















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}