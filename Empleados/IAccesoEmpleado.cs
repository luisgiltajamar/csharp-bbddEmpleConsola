using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleados.Modelo;

namespace Empleados
{
   public interface IAccesoEmpleado
    {
        void Add(Empleado emple);
        void Borrar(Empleado emple);
        Empleado GetById(int id);
        IEnumerable<Empleado> GetBySalario(decimal salario);
       decimal? SalarioMedioEmpleado();
       IEnumerable<Empleado> EmpleadosPorProyecto(int id);
       IEnumerable<Proyecto> ProyectoPorEmpleado(int idProyecto);
       IEnumerable<Empleado> EmpleadosPorNombre(String nombre);

    }
}
