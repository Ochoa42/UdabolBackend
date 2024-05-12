using ProjectDB_Udabol.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDB_Udabol.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DBClubWarnesEntities context =  new DBClubWarnesEntities())
            {
                return View(context.CLIENTES.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DBClubWarnesEntities context = new DBClubWarnesEntities())
            {
                return View(context.CLIENTES.Where(x => x.Id_Cliente == id).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(CLIENTES clientes)
        {
            try
            {
                using (DBClubWarnesEntities context = new DBClubWarnesEntities())
                {
                    context.CLIENTES.Add(clientes);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBClubWarnesEntities context = new DBClubWarnesEntities())
            {
                return View(context.CLIENTES.Where(x => x.Id_Cliente == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CLIENTES cliente)
        {
            try
            {
                using (DBClubWarnesEntities context = new DBClubWarnesEntities())
                {
                    context.Entry(cliente).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBClubWarnesEntities context = new DBClubWarnesEntities ())
            {
                return View(context.CLIENTES.Where(x => x.Id_Cliente == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBClubWarnesEntities context = new DBClubWarnesEntities())
                {
                    CLIENTES cliente = context.CLIENTES.Where(x => x.Id_Cliente == id).FirstOrDefault();
                    context.CLIENTES.Remove(cliente);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
