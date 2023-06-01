namespace Wartezimmer_App.Models
{
    public static class Warteschlange
    {
        public static Queue<Patient> patientenschlange { get; set; } = new Queue<Patient>();

        public static void PatientAdd(Patient p)
        {
            if (p.Notfall)
            {
                List<Patient> test = new();
                test.AddRange(Warteschlange.patientenschlange.Reverse().ToList());
                Warteschlange.patientenschlange.Clear();
                test.Add(p);
                test.Reverse();
                foreach (Patient t in test)
                {
                    Warteschlange.patientenschlange.Enqueue(t);
                }
            }
            else
            {
                Warteschlange.patientenschlange.Enqueue(p);
            }
        }
    }
}