using System.ComponentModel.DataAnnotations;
namespace Wartezimmer_App.Models
{
    public class Patient
    {
        public int PNr { get; set; }
        public string? Anrede { get; set; }
        public string? Name { get; set; }
        public string? Nachname { get; set; }
        public string? Wohnhaft { get; set; }
        public bool Notfall { get; set; } = false;


        public Patient()
        {
            PNr = Nummero.Generator();
        }
    }

    public static class Nummero
    {
        public static int nr { get; set; }

        public static int Generator ()
        {
            nr++;
            return nr;
        }
    }
}

