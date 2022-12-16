using EmployeeWeb.Helper;
using EmployeeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeAPI _api = new EmployeeAPI();
        public async Task<IActionResult> Index()
        {
            List<TblEmpInfo> employees = new List<TblEmpInfo>();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Employee/GetAllEmployee");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<TblEmpInfo>>(results);
            }

            return View(employees);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(TblEmpInfo tblEmpInfo)
        {
            HttpClient client = _api.Initial();

            var PostTask = client.PostAsJsonAsync<TblEmpInfo>("api/Employee/AddEmployee", tblEmpInfo);
            PostTask.Wait();

            var Result = PostTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<ActionResult> EditAsync(int id)
        {
            List<TblEmpInfo> employees = new List<TblEmpInfo>();
            TblEmpInfo employee = new TblEmpInfo();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/Employee/GetAllEmployee");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<TblEmpInfo>>(results).Find(results=> results.EmpId==id);
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TblEmpInfo tblEmpInfo)
        {
            HttpClient client = _api.Initial();

            var PutTask = client.PutAsJsonAsync<TblEmpInfo>($"/api/Employee/UpdateEmployee?id={tblEmpInfo.EmpId}", tblEmpInfo);
            PutTask.Wait();

            var Result = PutTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            TblEmpInfo employees = new TblEmpInfo();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/Employee/DeleteEmployee?empId={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(employees);
        }
    }
}
