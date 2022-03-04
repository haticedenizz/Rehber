using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rehber.Models.Entities
{
    [Table("Kisiler")]
    public class Kisi
    {
        public int Id { get; set; }
        [DisplayName("İsim")]
        public string Ad { get; set; }
        [DisplayName("Soyisim")]
        public string Soyad { get; set; }
        [DisplayName("Cep Telefonu")]
        public string CepTelefon { get; set; }
        [DisplayName("Email Adres")]
        public string EmailAdres { get; set; }
        public string Adres { get; set; }
    }
}