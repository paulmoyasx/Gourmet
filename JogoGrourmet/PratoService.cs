using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGrourmet
{
    class PratoService
    {
        private static List<PratoModel> _pratos = new  List <PratoModel>();

        private static void InicializarPratos()
        {
            if (_pratos.Count == 0)
            {
                Adicionar(new PratoModel { Nome = "Massa", Id = -1 });
                Adicionar(new PratoModel { Nome = "Lassanha", Pai = -1 } );
                Adicionar(new PratoModel { Nome = "Bolo de chocolate" });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prato"></param>
        /// <returns></returns>
        public static PratoModel Adicionar(PratoModel prato)
        {
            if(prato.Id==0) prato.Id = _pratos.Count+1;
            prato.Pai = prato.Pai;
            if (prato != null && !string.IsNullOrEmpty(prato.Nome))
            {
                _pratos.Add(prato);
                PratoModel pai = Consutlar(prato.Id);
                if (pai != null) pai.Filhos++;

            }
            else
            {
                throw new Exception("Prato Invalido");
            }
            return prato;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PratoModel Consutlar(int id)
        {
            return _pratos.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pai"></param>
        /// <returns></returns>
        public static List<PratoModel> Listar(int pai=0)
        {
            InicializarPratos();
            return _pratos.Where(x => x.Pai==pai).OrderBy(x => x.Id).ThenByDescending(x=>x.Filhos).ToList();
        }


        public static string Analizar(List<PratoModel> lista = null)
        {
            if (lista == null) lista = Listar();
            StringBuilder str = new StringBuilder();
            foreach (var item in lista)
            {
                str.AppendLine($@"id={item.Id} pai:{item.Pai} {item.Nome} ");
                str.AppendLine(Analizar(Listar(item.Id)));
            }
            return str.ToString();
        }





    }
}
