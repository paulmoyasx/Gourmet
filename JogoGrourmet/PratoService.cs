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

        public static List<PratoModel> Listar(int pai = 0)
        {
            InicializarPratos();
            if (pai == 0)
            {
                return _pratos.Where(x => x.Pai == pai).OrderBy(x => x.Id).ToList();
            }
            else
            {
                return _pratos.Where(x => x.Pai == pai).OrderByDescending(x => x.Filhos).ThenBy(x => x.Id).ToList();
            }

        }
        private static void InicializarPratos()
        {
            if (_pratos.Count == 0)
            {
                Adicionar(new PratoModel { Nome = "Massa", Id = -1 });
                Adicionar(new PratoModel { Nome = "Lassanha", Pai = -1 } );
                Adicionar(new PratoModel { Nome = "Bolo de chocolate", Id=int.MaxValue});
            }
        }

        public static PratoModel Adicionar(PratoModel prato)
        {
            if(prato.Id==0) prato.Id = _pratos.Count+1;
            if (prato != null && !string.IsNullOrEmpty(prato.Nome))
            {
                _pratos.Add(prato);
                PratoModel pai = Consutlar(prato.Pai);
                if (pai != null) pai.Filhos++;

            }
            else
            {
                throw new Exception("Prato Invalido");
            }
            return prato;
        }

        public static PratoModel Consutlar(int id)
        {
            return _pratos.FirstOrDefault(x => x.Id == id);
        }

        
        public static string Conteudo(List<PratoModel> lista = null)
        {
            if (lista == null) lista = Listar();
            StringBuilder str = new StringBuilder();
            foreach (var item in lista)
            {
                str.AppendLine($@"id={item.Id} pai:{item.Pai} filhos: {item.Filhos} {item.Nome} ");
                str.AppendLine(Conteudo(Listar(item.Id)));
            }
            return str.ToString();
        }

        public static void Resetar()
        {
            _pratos.Clear();
        }


        public static string ValidarPrato(PratoModel prato, string nome)
        {
            StringBuilder retorno = new StringBuilder("");
            if (string.IsNullOrEmpty(nome))
            {
                retorno.AppendLine("Não foi especificado um nome.");
            }
            else
            {
                if ((prato != null) && prato.Nome.ToUpper().Trim() == nome.ToUpper().Trim()) retorno.AppendLine($" {nome} já existe na úitima opção.");

                PratoModel pai = PratoService.Consutlar(prato.Pai);
                if ((pai != null) && pai.Nome.ToUpper().Trim() == nome.ToUpper().Trim()) retorno.AppendLine($" {nome} já existe na úitima opção.");
            }
            return retorno.ToString();
        }



    }
}
