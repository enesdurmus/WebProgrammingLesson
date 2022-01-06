using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class SurveyQuestion
    {        
        public int ID { get; set; }

        public int SurveyID { get; set; }

        public int QuestionID { get; set; }

        public int OrderID { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
