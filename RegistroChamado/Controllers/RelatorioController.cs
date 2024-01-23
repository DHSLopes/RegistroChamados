using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroChamado.Models;

namespace RegistroChamado.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;
        public RelatorioController(AppDbContext context)
        {
            _context = context;
        }
        // GET: RelatorioController
        public ActionResult Index()
        {
            return View();
        }
        private List<SelectListItem> GetColaborador()
        {
            List<SelectListItem> lstColaborador = _context.Colaborador
                .OrderBy(n => n.Nome)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Nome
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----- SELECIONE UM COLABORADOR -----"
            };
            var defGeral = new SelectListItem()
            {
                Value = "",
                Text = "Todos"
            };
            lstColaborador.Insert(0, defItem);
            lstColaborador.Insert(1, defGeral);
            return lstColaborador;
        }
        private List<SelectListItem> GetChamadosColaborador(int idColaborador)
        {
            List<SelectListItem> lstColaborador = _context.Chamado
                .Where(c => c.ColaboradorId == idColaborador)
                .OrderBy(n => n.ColaboradorId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Descricao
                }).ToList();
            return lstColaborador;
        }
        [HttpGet]
        public ActionResult RelatorioColaborador()
        {
            ViewBag.Colaboradores = GetColaborador();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RelatorioColaborador(int IdColaborador)
        {
            ViewBag.Colaboradores = GetChamadosColaborador(IdColaborador);            
            return View();
        }
        public ActionResult RelatorioPeriodo()
        {
            return View();
        }
        public ActionResult RelatorioPrioridade()
        {
            return View();
        }
        public ActionResult RelatorioSetor()
        {
            return View();
        }
        public ActionResult RelatorioSituacao()
        {
            return View();
        }
    }
}
