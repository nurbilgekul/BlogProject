using BlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? CreateDate  { get; set; }
        public string CreatedComputerName  { get; set; }
        public string CreatedIp  { get; set; }

        public DateTime? ModifiedDate  { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp  { get; set; }

        public DateTime? RemovedDate  { get; set; }
        public string RemovedComputerName { get; set; }
        public string RemovedIp  { get; set; }

        public Status Status { get; set; }
    }
}
