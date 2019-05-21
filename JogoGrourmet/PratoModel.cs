using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGrourmet
{
    public class PratoModel
    {
        public int Id { get; set; } = 0;
        public int Pai { get; set; } = 0;
        public int Filhos { get; set; } = 0;
        public string Nome { get; set; } = "";
        public bool Pensou { get; set; } = false;

    }
}
