using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Corretora.Data;
using App_Corretora.Repository;
using App_Corretora.Models;
using App_Corretora.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Xunit;

namespace CorretoraTest.Controllers
{
    public class TestCorretoraApp
    {
        private readonly CorretoraRepository _repository;
         
        public TestCorretoraApp(CorretoraRepository repository)
        {
            _repository = repository;
        }

        [Fact]
        public async Task listarCorretoras()
        {
            //arrange
            var corretoras =  await _repository.listarCorretoras();

           

            ///Assert 
           corretoras.Should().Equals(corretoras);

        }

     
    }
}
