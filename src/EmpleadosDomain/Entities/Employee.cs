using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosDomain.Entities
{
    public class Employee
    {
        public Employee() { }
        public Employee(Guid id,string name, string lastname, string secondLastname, string sexo, string rol, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            SecondLastname = secondLastname;
            Sexo = sexo;
            Rol = rol;
            DateCreated = dateCreated;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }  
        public string LastName { get; set; }    
        public string SecondLastname { get; set; }
        public string Sexo { get; set; }
        public string Rol { get; set; }
        public DateTime DateCreated { get; set; }

       
        public static Employee Crear(Guid id, string name, string lastname, string secondLastname, string sexo, string rol, DateTime datecreated)
        {
            return new Employee(id,name,lastname,secondLastname,sexo,rol, datecreated);
        }


    }
}
