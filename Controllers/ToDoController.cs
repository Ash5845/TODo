using RefreshTODo.Data;
using RefreshTODo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RefreshTODo.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            List<ToDoModel> toDos = new List<ToDoModel>();

            ToDoDAO toDoDao = new ToDoDAO();

            toDos = toDoDao.FetchAll();

            return View("Index", toDos);
        }

        public ActionResult Details(int Id)
        {
            ToDoDAO toDoDAO = new ToDoDAO();

            ToDoModel toDo = toDoDAO.FetchOne(Id);

            return View("Details", toDo);
        }

        public ActionResult Create()
        {
            return View("ToDoForm", new ToDoModel());
        }

        public ActionResult Edit(int Id)
        {
            ToDoDAO toDoDAO = new ToDoDAO();
            ToDoModel toDo = toDoDAO.FetchOne(Id);
            return View("ToDoForm", toDo);
        }

        public ActionResult ProcessCreate(ToDoModel toDoModel)
        {
            ToDoDAO toDoDAO = new ToDoDAO();

            toDoDAO.CreateOrUpdate(toDoModel);

            return View("Details", toDoModel);
        }

        public ActionResult Delete(int Id)
        {
            ToDoDAO toDoDAO = new ToDoDAO();
            toDoDAO.Delete(Id);

            List<ToDoModel> toDos = toDoDAO.FetchAll();

            return View("Index", toDos);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForEmployee(string searchPhrase)
        {
            ToDoDAO toDoDAO = new ToDoDAO();

            List<ToDoModel> searchResults = toDoDAO.SearchForEmployee(searchPhrase);

            return View("Index", searchResults);
        }
    }
}