namespace EmployeeWeb.Models
{
    public class TblEmpInfo
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Range(1, 111111111)]
        public int EmpId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string? Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Phone]
        public string? Mobile { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string? EmailId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string? Address { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string? Dept { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(1, 111111111)]
        public int? Salary { get; set; }
    }
}
