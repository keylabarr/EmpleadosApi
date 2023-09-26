namespace EmpleadosApi.Models
{
    public class EmployeeModel
    {
        public Guid? IdEmpleado { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string secondLastname { get; set; }
        public string sexo { get; set; }
        public string rol { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
