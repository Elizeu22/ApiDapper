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
using Newtonsoft.Json;



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

            string cnpj = "4232242";
        
            await using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"corretores/Pesquisar?cnpj={cnpj}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);



        }




        [Fact]
        public async Task DeletarCNpj()
        {

            string cnpj = "0122365898989878455";

            await using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"corretores/Deletar?cnpj={cnpj}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);



        }



       [Fact]
        public async Task CadastrarCnpj()
        {

            var corretora = new Corretora() { Cnpj = "09054789", corretora = "teste", Logradouro="teste", Cep="02354899", NomeSocial="teste" };
            var payloadCorretora = JsonConvert.SerializeObject(corretora);
            var contentCorretora = new StringContent(payloadCorretora, Encoding.UTF8, "application/json");

            await using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            // Act
            var response = await client.PostAsync ("corretores/Gravar", contentCorretora);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);



        }



        [Fact]
        public async Task AtualizarCnpj()
        {

            var corretora = new Corretora() { Cnpj = "0568784541313", corretora = "teste", Logradouro = "teste", Cep = "05689777", NomeSocial = "teste" };
            var payloadCorretora = JsonConvert.SerializeObject(corretora);
            var contentCorretora = new StringContent(payloadCorretora, Encoding.UTF8, "application/json");

            await using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            // Act
            var response = await client.PutAsync("corretores/Atualizar", contentCorretora);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);



        }






    }
}
