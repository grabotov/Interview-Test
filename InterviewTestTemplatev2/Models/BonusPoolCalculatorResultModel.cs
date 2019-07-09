using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorResultModel
    {
        //add get / set 
        public Data.HrEmployee HrEmployee { get; set; }
        public int BonusPoolAllocation { get; set; }
        public Data.HrDepartment HrDepartment { get; set; }

    }
}