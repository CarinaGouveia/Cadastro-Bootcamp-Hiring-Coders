using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hiring_Crud.Models;

namespace Hiring_Crud.Controllers
{
    public class PessoasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Email,Endereco,Cidade,Telefone")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,Email,Endereco,Cidade,Telefone")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
