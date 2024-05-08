using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Retrieve the list of users from the userlist
            var users = userlist; 
            // Return the list of users as the view model for the Index view
            return View(users);
        }
 
      // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Return the user as the view model for the Details view
            return View(user);
        }
 
      // GET: User/Create
        public ActionResult Create()
        {
            // Return the Create view
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Add the user to the userlist
                userlist.Add(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If the model is not valid, return the Create view with validation errors
            return View(user);
        }

        // GET: User/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
                                    // If no user is found, it returns a HttpNotFoundResult.
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);
            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }
            // Pass the user to the Edit view
            return View(user);
        }
 

 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here            // Implement the Delete method here
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);
            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }
            // Pass the user to the Delete view
            return View(user);
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here            // Implement the Delete method (POST) here            // Implement the Delete method (POST) here
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);
            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }
            // Remove the user from the userlist
            userlist.Remove(user);
            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
