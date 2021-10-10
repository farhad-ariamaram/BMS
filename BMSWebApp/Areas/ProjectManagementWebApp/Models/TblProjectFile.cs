using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class TblProjectFile
    {
        public Guid FldProjectFilesId { get; set; }
        public Guid FldProjectId { get; set; }
        public Guid FldProjectFileTypeId { get; set; }
        public Guid FldWorkpieceId { get; set; }
        public long? FldProjectFilesFileId { get; set; }
        public long? FldProjectFilesOldFileId { get; set; }
        public bool FldProjectFilesDeleted { get; set; }

        public virtual TblProject FldProject { get; set; }
        public virtual TblProjectFileType FldProjectFileType { get; set; }
        public virtual TblWorkpiece FldWorkpiece { get; set; }
    }
}
