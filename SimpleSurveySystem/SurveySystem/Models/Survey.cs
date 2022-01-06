﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Models
{
    public class Survey
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
