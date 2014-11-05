using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleados.Modelo;

namespace Empleados
{
   public class RepositorioEmpleados :IAccesoEmpleado
    {
       private rrhhEntities db=new rrhhEntities();

       public void Add(Empleado emple)
       {
           db.Empleado.Add(emple);
           db.SaveChanges();
       }

       public void Borrar(Empleado emple)
       {
           db.Empleado.Remove(emple);
           db.SaveChanges();
       }

       public Empleado GetById(int id)
       {
           return db.Empleado.Find(id);
       }

       public IEnumerable<Empleado> GetBySalario(decimal salario)
       {
           return db.Empleado.Where(o => o.salario >= salario);
       }


       public decimal? SalarioMedioEmpleado()
       {
           return db.Empleado.Average(o => o.salario);
       }

       public IEnumerable<Empleado> EmpleadosPorProyecto(int id)
       {
           try
           {
               return db.Proyecto.First(o => o.idProyecto == id).Empleado;
           }
           catch (Exception e)
           {
               return null;
           }
       }

       public IEnumerable<Proyecto> ProyectoPorEmpleado(int idEmpleado)
       {
           try
           {
               return db.Empleado.Find(idEmpleado).Proyecto;
           }
           catch (Exception e)
           {
               return null;
           }
       }

       public IEnumerable<Empleado> EmpleadosPorNombre(string nombre)
       {
           return db.Empleado.Where(o => o.nombre.Contains(nombre));
       }
    }
}
