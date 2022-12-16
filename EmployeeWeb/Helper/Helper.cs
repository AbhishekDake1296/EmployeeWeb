namespace EmployeeWeb.Helper
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5222/");
            return client;
        }
    }
}
