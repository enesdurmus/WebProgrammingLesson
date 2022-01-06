using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public partial class SurveyResponse
    {
        public int ID { get; set; }

        public int SurveyID { get; set; }

        public int QuestionID { get; set; }

        public string Response { get; set; }

        public string FilledBy { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
