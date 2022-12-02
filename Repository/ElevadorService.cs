using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WsElevadores.Models;
using WsElevadores.Interface;


namespace WsElevadores.Repository
{
    public class ElevadorService : IElevadorService
    {
        /// <summary> Deve retornar uma List contendo o(s) andar(es) menos utilizado(s). </summary> 
        public List<int> andarMenosUtilizado()
        {
            List<Elevador> elevadores = ListaElevadores();

            var ListaAndares = elevadores.GroupBy(n => n.andar).Select(n => new { Andar = n.Key, Qtde = n.Count() }).OrderBy(n => n.Qtde).ToList();
            int QtdeMenor = ListaAndares.First().Qtde;            

            List<int> retorno =  ListaAndares.Where(n=> n.Qtde == QtdeMenor).OrderBy(n => n.Andar).Select( n => n.Andar ).ToList();
           
            return retorno;
        }

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s). </summary> 
        public List<char> elevadorMaisFrequentado()
        {
            List<Elevador> elevadores = ListaElevadores();

            var ListaAndares = elevadores.GroupBy(n => n.elevador).Select(n => new { Elevador = n.Key, Qtde = n.Count() }).OrderByDescending(n => n.Qtde).ToList();
            int QtdeMaior = ListaAndares.First().Qtde;

            List<char> retorno = ListaAndares.Where(n => n.Qtde == QtdeMaior).OrderBy(n => n.Elevador).Select(n => n.Elevador[0]).ToList();

            return retorno;
        }

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s). </summary> 
        public List<char> elevadorMenosFrequentado()
        {
            List<Elevador> elevadores = ListaElevadores();

            var ListaAndares = elevadores.GroupBy(n => n.elevador).Select(n => new { Elevador = n.Key, Qtde = n.Count() }).OrderBy(n => n.Qtde).ToList();
            int QtdeMenor = ListaAndares.First().Qtde;

            List<char> retorno = ListaAndares.Where(n => n.Qtde == QtdeMenor).OrderBy(n => n.Elevador).Select(n => n.Elevador[0]).ToList();

            return retorno;
        }

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados. </summary> 
        public float percentualDeUsoElevadorA()
        {
          return PercentualElevadores("A"); 
        }

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relação a todos os serviços prestados. </summary> 
        public float percentualDeUsoElevadorB()
        {
            return PercentualElevadores("B");
        }

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relação a todos os serviços prestados. </summary> 
        public float percentualDeUsoElevadorC()
        {
            return PercentualElevadores("C");
        }

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relação a todos os serviços prestados. </summary> 
        public float percentualDeUsoElevadorD()
        {
            return PercentualElevadores("D");
        }

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relação a todos os serviços prestados. </summary> 
        public float percentualDeUsoElevadorE()
        {
            return PercentualElevadores("E");
        }

        /// <summary> Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {

            List<Elevador> elevadores = ListaElevadores();

            var ListaAndares = elevadores.GroupBy(n => n.elevador).Select(n => new { Elevador = n.Key, Qtde = n.Count() }).OrderByDescending(n => n.Qtde).ToList();
            int QtdeMaior = ListaAndares.First().Qtde;

            var tbElevadorMais = ListaAndares.Where(n => n.Qtde == QtdeMaior).OrderBy(n => n.Elevador).ToList();

            List<char> retorno = new List<char>();

            foreach (var item in tbElevadorMais)
            {
                List<Elevador> elevadoresPerido = ListaElevadores();

                string Turno = elevadoresPerido.Where(n => n.elevador == item.Elevador).GroupBy(n => n.turno).Select(n => new { Turno = n.Key, Qtde = n.Count() }).OrderByDescending(n => n.Qtde).FirstOrDefault().Turno;
                retorno.Add(Turno[0]);
            }

            return retorno;
        }

        /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores. </summary> 
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            List<Elevador> elevadores = ListaElevadores();

            var ListaTurno = elevadores.GroupBy(n => n.turno).Select(n => new { Turno = n.Key, Qtde = n.Count() }).OrderByDescending(n => n.Qtde).ToList();
            int QtdeMaior = ListaTurno.First().Qtde;

            List<char> retorno = ListaTurno.Where(n => n.Qtde == QtdeMaior).OrderBy(n => n.Turno).Select(n => n.Turno[0]).ToList();

            return retorno;
        }

        /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<Elevador> elevadores = ListaElevadores();

            var ListaAndares = elevadores.GroupBy(n => n.elevador).Select(n => new { Elevador = n.Key, Qtde = n.Count() }).OrderBy(n => n.Qtde).ToList();
            int QtdeMaior = ListaAndares.First().Qtde;

            var tbElevadorMais = ListaAndares.Where(n => n.Qtde == QtdeMaior).OrderBy(n => n.Elevador).ToList();

            List<char> retorno = new List<char>();

            //string ultimo = "";

            foreach (var item in tbElevadorMais)
            {
                List<Elevador> elevadoresPerido = ListaElevadores();

                string Turno = elevadoresPerido.Where(n => n.elevador == item.Elevador).GroupBy(n => n.turno).Select(n => new { Turno = n.Key, Qtde = n.Count() }).OrderByDescending(n => n.Qtde).FirstOrDefault().Turno;


                retorno.Add(Turno[0]);
            }

            return retorno.Distinct().ToList();
        }

        private float PercentualElevadores( string Elevador)
        {
            List<Elevador> elevadores = ListaElevadores();
            int QtdeServicos = elevadores.Count;
            int QtdeElevadorA = elevadores.Where(n => n.elevador == Elevador).Count();

            double Percentual = (((double)QtdeElevadorA / (double)QtdeServicos) * 100);

            return (float)Math.Round(Percentual, 2);
        }

        private List<Elevador> ListaElevadores()
        {
            var caminho = HttpContext.Current.Server.MapPath("~/Content");

            List<Elevador> retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Elevador>>(File.ReadAllText($@"{caminho}\\input.json"));

            return retorno;
        }
    }
}