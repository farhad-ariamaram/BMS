using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class TblEmployeeRequestPagesSequence
    {
        public TblEmployeeRequestPagesSequence()
        {
            TblEmployeeRequestEmployees = new HashSet<TblEmployeeRequestEmployee>();
        }

        public long FldEmployeeRequestPagesSequenceId { get; set; }
        public bool? FldEmployeeRequestPagesSequenceStatus { get; set; }
        public long? FldEmployeeRequestPagesSequenceRecord { get; set; }
        public int? FldEmployeeRequestPagesSequenceOne { get; set; }
        public int? FldEmployeeRequestPagesSequenceTwo { get; set; }
        public int? FldEmployeeRequestPagesSequenceThree { get; set; }
        public int? FldEmployeeRequestPagesSequenceFour { get; set; }
        public int? FldEmployeeRequestPagesSequenceFive { get; set; }
        public int? FldEmployeeRequestPagesSequenceSix { get; set; }
        public int? FldEmployeeRequestPagesSequenceSeven { get; set; }
        public int? FldEmployeeRequestPagesSequenceEight { get; set; }
        public int? FldEmployeeRequestPagesSequenceNine { get; set; }
        public int? FldEmployeeRequestPagesSequenceTen { get; set; }
        public int? FldEmployeeRequestPagesSequenceEleven { get; set; }
        public int? FldEmployeeRequestPagesSequenceTwelve { get; set; }
        public int? FldEmployeeRequestPagesSequenceThirteen { get; set; }
        public int? FldEmployeeRequestPagesSequenceFourteen { get; set; }
        public int? FldEmployeeRequestPagesSequenceFifteen { get; set; }
        public int? FldEmployeeRequestPagesSequenceSixteen { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployee> TblEmployeeRequestEmployees { get; set; }
    }
}
