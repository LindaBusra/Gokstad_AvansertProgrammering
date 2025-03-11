using System.ComponentModel.DataAnnotations;

namespace TodoApplikasjonDel2.Models
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


        // Title: Maksimum lengde 100 tegn
        [Required(ErrorMessage = "Title er påkrevd.")] 
        [StringLength(100, ErrorMessage = "Tittelen kan ikke være lengre enn 100 tegn")] 
        public string Title { get; set; }       

        
        // Description: Maksimum lengde 500 tegn
        [StringLength(500, ErrorMessage = "Tittelen kan ikke være lengre enn 500 tegn")] 
        public string Description { get; set; } = string.Empty;


        // IsCompleted: Standardverdi false        
        public bool IsCompleted { get; set; } = false; // Standardverdi satt til false
    }
}