using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Web.Http.Results;
using App_Corretora.Data;
using App_Corretora.Repository;
using App_Corretora.Models;
using App_Corretora.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using FluentAssertions;


namespace Corretoras
{
    [TestClass]
    public class CorretoresControllerTest
    {

        private readonly CorretoraRepository _repository;



        public CorretoresControllerTest(CorretoraRepository repository)
        {
            _repository = repository;


        }

        [TestMethod]
        public async Task getAllCorretoras()
        {
            var corretoras =await  _repository.listarCorretoras();

            Assert.Contains(corretoras);

      



        }



        private List<Corretora>  GetCorretoras()
        {
            var testCorretora = new List<Corretora>();

            testCorretora.Add(new Corretora
            {
                Cnpj = "021546565",
                corretora = "Alves",
                Logradouro = "Rua Silva",
                Cep = "02156888",
                NomeSocial = "Alveslima"
            });

            testCorretora.Add(new Corretora
            {
                Cnpj = "2656566989",
                corretora = "Silva",
                Logradouro = "Rua Alves",
                Cep = "05698989",
                NomeSocial = "AlvesSouza"
            });


            return testCorretora;

        }
    }
}
