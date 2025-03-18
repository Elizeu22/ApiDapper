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
using Microsoft.AspNetCore.Builder;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Microsoft.AspNetCore.Hosting;



namespace CorretoraTest.Controllers
{
    public class TestCorretoraApp
    {

 
        [Fact]
        public async Task Ler()
        {
            await using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("corretores/Localizar");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);



        }



        [Fact]
        public async Task LerCNpj()
        { 

            string cnpj = "66456464";
        
            await using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"corretores/Pesquisar?cnpj={cnpj}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);



        }



    }
}
