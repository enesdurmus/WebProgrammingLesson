using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class Question
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

        //public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }

       // public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
