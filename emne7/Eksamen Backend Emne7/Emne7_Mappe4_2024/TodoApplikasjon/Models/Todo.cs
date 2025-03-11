using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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


        // Title: Må være påkrevd og ha mellom 3 og 100 tegn
        [Required(ErrorMessage = "Title er påkrevd.")]
        [StringLength(100, ErrorMessage = "Tittelen kan ikke være lengre enn 100 tegn")]
        [MinLength(3, ErrorMessage = "Tittelen må være minst 3 tegn")]
        public string Title { get; set; }


        // Description: Må ha minimum 10 tegn, hvis oppgitt
        [MinLength(10, ErrorMessage = "Beskrivelsen må være minst 10 tegn hvis oppgitt.")]
        public string Description { get; set; }


        // IsCompleted: Valider at den ikke kan settes til true ved oppretting (standardverdi må være false)
        [Range(typeof(bool), "false", "false", ErrorMessage = "IsCompleted kan ikke settes til true ved oppretting. Standardverdi må være false.")]
        public bool IsCompleted { get; set; } = false; // Standardverdi satt til false


        [ForeignKey("Category")]
        public int CategoryId { get; set; }  //Fremmed nøkkel (Den er i annen tabel)

         [ValidateNever]
        public Category Category { get; set; }  //jeg får informasjon om category gjennom todo



    }
}