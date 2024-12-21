using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaKayıt
{
    internal class Hasta
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public DateTime Tarih { get; set; }
        public string Birim { get; set; }
        public int Yas { get; set; }
        public bool Sigorta { get; set; }

    }
}
