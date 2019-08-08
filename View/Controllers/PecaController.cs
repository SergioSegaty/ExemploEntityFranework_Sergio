using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;

namespace View.Controllers
{
    [Route("peca/")]
    public class PecaController : Controller
    {
        private IPecaRepository repository;

        public PecaController(IPecaRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado);
        }


        [HttpPost, Route("inserir")]
        public JsonResult Inserir([FromForm]Peca peca)
        {
            var id = repository.Inserir(peca);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar([FromForm]Peca peca)
        {
            var alterado = repository.Alterar(peca);
            var resultado = new { status = alterado };

            return Json(resultado);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var pecas = repository.ObterTodos();

            return Json(pecas);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var peca = repository.ObterPeloId(id);
            if (peca == null) return NotFound();

            return Json(peca);
        }
    }
}