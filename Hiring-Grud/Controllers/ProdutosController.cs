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
    public class ProdutosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Produto,Marca")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Produto,Marca")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            db.Produtos.Remove(produtos);
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
