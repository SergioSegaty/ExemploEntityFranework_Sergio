using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;

namespace View.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepository repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            this.repository = repository;
        }






        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  Método que permitirá ter acesso aos dados das categorias,
        ///  filltrando, ordenando e paginando as informações de acordo com os parametros
        /// </summary>
        /// <param name="quantidade"></param>
        /// <param name="pagina"></param>
        /// <param name="busca"></param>
        /// <param name="colunaOrdem"></param>
        /// <param name="ordem"></param>
        /// <returns></returns>



        [HttpGet, Route("categoria/obtertodos")]
        public JsonResult ObterTodos(int quantidade = 10, int pagina = 0, string busca = "", string colunaOrdem = "nome", string ordem = "ASC")
        {
            List<Categoria> categorias = repository.ObterTodos(quantidade, pagina, busca, colunaOrdem, ordem);  

            return Json(new { data = categorias });
        }
        [HttpPost]
        public JsonResult Cadastrar([FromBody]Categoria categoria)
        {
            categoria.RegistroAtivo = true;
            int id = repository.Inserir(categoria);
            // Objeto Anonimo

            var retorno = new {id};
            return Json(retorno);   
        }


        [HttpPost]
        public JsonResult Alterar([FromBody]Categoria categoria)
        {
            bool alterado = repository.Alterar(categoria);

            var resultado = new { status = alterado };

            return Json(resultado);
        }

        [HttpGet]
        // categoria/apagar?id=
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado);
        }
    }
}