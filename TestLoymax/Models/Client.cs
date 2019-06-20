using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLoymax.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; } //Идентификатор пользователя 
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } //Имя
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; } //Фамилия
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string MiddleName { get; set; } //Отчество
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } //Дата рождения
        [Required]
        public decimal Deposit { get; set; } //Cумма на счете
        //[Required]
        //public Guid BankAccountId { get; set; } = Guid.NewGuid(); //Номер счета
    }
}
