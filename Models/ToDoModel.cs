using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RefreshTODo.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        [Required]
        public string Employee { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public string StartDate { get; set; }
        [Required]
        public string Deadline { get; set; }
        [Required]
        public string Complete { get; set; }

        public ToDoModel()
        {
            Id = -1;
            Employee = "";
            Task = "";
            StartDate = "";
            Deadline = "";
            Complete = "No";
        }

        public ToDoModel(int id, string employee, string task, string startDate, string deadline, string complete)
        {
            Id = id;
            Employee = employee;
            Task = task;
            StartDate = startDate;
            Deadline = deadline;
            Complete = complete;
        }
    }
}