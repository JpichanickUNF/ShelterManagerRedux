using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace ShelterManagerRedux.Models

{
    public class FrequentlyAskedQuestions
    {
        [Key]
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
