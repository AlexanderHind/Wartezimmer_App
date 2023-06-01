using Microsoft.AspNetCore.Mvc;
using Wartezimmer_App.Models;

namespace Wartezimmer_App.Controllers
{
    public class HomeController : Controller
    {
        // Startseite mit Auswahl
        public IActionResult Index()
        {
            return View();
        }
        //Aufnahme der Patientendaten
        [HttpGet]
        public ViewResult PatientenAufnahme()
        {
            return View();
        }
        // Übermittlung der Patientendaten & Weiterleitung auf die Erfolgsseite
        [HttpPost]
        public ViewResult PatientenAufnahme(Patient p)
        {
            Warteschlange.PatientAdd(p);
            return View("Erfolg");
        }
        // Ansicht für den Doktor mit Patentendaten
        public ViewResult PatientenEinsicht()
        {
            if (Warteschlange.patientenschlange?.Count == 0)
            {
                Patient patient = new Patient() { PNr = 0000, Anrede = "Keiner", Nachname = "Niemand", Name = "Nix", Notfall = false, Wohnhaft = "Nimmerlandweg 3" };
                return View(patient);
            }
            else
            {
                return View(Warteschlange.patientenschlange?.Dequeue());

            }

        }
        //Zweite Einsicht für den Doktor zum Aktualisieren 
        public ViewResult Naechster()
        {
            if (Warteschlange.patientenschlange?.Count != 0)
            {
                if (Warteschlange.patientenschlange?.Peek() != null)
                {
                    return View(Warteschlange.patientenschlange?.Dequeue());
                }
                else
                {
                    Patient patient = new Patient() { PNr = 0000, Anrede = "Keiner", Nachname = "Niemand", Name = "Nix", Notfall = false, Wohnhaft = "Nimmerlandweg 3" };
                    return View(patient);
                }

            }
            else
            {
                return View();
            }
        }
    }
}