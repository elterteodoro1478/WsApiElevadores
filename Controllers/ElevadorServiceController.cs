using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WsElevadores.Repository;
using WsElevadores.Models;

namespace WsElevadores.Controllers
{
    public class ElevadorServiceController : ApiController
    {
        // GET: ElevadorService
        [HttpGet]
        [Route("api/andarMenosUtilizado")]
        public List<int> andarMenosUtilizado()
        {           
           return new ElevadorService().andarMenosUtilizado(); 
        }

        
        [HttpGet]
        [Route("api/elevadorMaisFrequentado")]
        public List<char> elevadorMaisFrequentado()
        {
            return new ElevadorService().elevadorMaisFrequentado();
        }

        
        [HttpGet]
        [Route("api/elevadorMenosFrequentado")]
        public List<char> elevadorMenosFrequentado()
        {            
            return new ElevadorService().elevadorMenosFrequentado();
        }

        [HttpGet]
        [Route("api/percentualDeUsoElevadorA")]
        public float percentualDeUsoElevadorA()
        {
            return new ElevadorService().percentualDeUsoElevadorA();
        }

        [HttpGet]
        [Route("api/percentualDeUsoElevadorB")]
        public float percentualDeUsoElevadorB()
        {           
            return new ElevadorService().percentualDeUsoElevadorB();
        }

        [HttpGet]
        [Route("api/percentualDeUsoElevadorC")]
        public float percentualDeUsoElevadorC()
        {
            return new ElevadorService().percentualDeUsoElevadorC();
        }


        [HttpGet]
        [Route("api/percentualDeUsoElevadorD")]
        public float percentualDeUsoElevadorD()
        {
            return new ElevadorService().percentualDeUsoElevadorD();
        }

        [HttpGet]
        [Route("api/percentualDeUsoElevadorE")]
        public float percentualDeUsoElevadorE()
        {
            return new ElevadorService().percentualDeUsoElevadorE();
        }

        [HttpGet]
        [Route("api/periodoMaiorFluxoElevadorMaisFrequentado")]
        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            return new ElevadorService().periodoMaiorFluxoElevadorMaisFrequentado();
        }

        [HttpGet]
        [Route("api/periodoMaiorUtilizacaoConjuntoElevadores")]
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            return new ElevadorService().periodoMaiorUtilizacaoConjuntoElevadores();
        }

        [HttpGet]
        [Route("api/periodoMenorFluxoElevadorMenosFrequentado")]
        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            return new ElevadorService().periodoMenorFluxoElevadorMenosFrequentado();
        }

    }
}