using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evaluacion
    {
        [Key]
        public int EvaluacionID { get; set; }
        public DateTime Fecha { get; set; }
        public string Estudiante { get; set; }
        public string Categoria { get; set; }
        public  decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }
    }
}
