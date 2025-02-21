using System.ComponentModel.DataAnnotations;

namespace TodoApplikasjon.Models
{
    public class Todo
    {
        /*  Hver Todo-oppgave skal ha følgende egenskaper:
        § Id (int): En unik identifikator for oppgaven (todo).
        § Title (string): Tittel på oppgaven (todo).
        § Description (string): Beskrivelse av oppgaven (todo) (valgfritt).
        § IsCompleted (bool): Indikerer om oppgaven (todo) er fullført eller ikke*/

        //Oppretting av Todo-modell som skal representere en Todo-oppgave
        public int Id { get; set; }

        [Required(ErrorMessage = "Title er påkrevd.")]
        public string Title { get; set; }        //Title-feltet i Todo-modellen er påkrevd

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}