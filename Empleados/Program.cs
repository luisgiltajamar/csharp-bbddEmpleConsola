using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleados.Modelo;

namespace Empleados
{
    class Program
    {

        static void Main(string[] args)
        {
            var opc = 0;
            do
            {
        Console.Write("1. Alta 2. baja 3. Buscar codigo 4. borrar 5.salir");
                int.TryParse(Console.ReadLine(), out opc);

                switch (opc)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Borrar();
                        break;
                    case 3:
                        buscarClave();
                        break;
                    case 4:
                        BuscarSalario();
                        break;
                    case 5:
                        break;
                    default:
                        Console.Write("Opcion incorrecta");
                        break;
                }


            } while (opc != 5);


        }

        public static void Add()
        {
            
        var  ae=new RepositorioEmpleados();
            Console.Write("Nombre:");
            var nombre = Console.ReadLine();

            Console.Write("DNI:");
            var dni = Console.ReadLine();

            Console.Write("Salario:");
            decimal s;
            decimal.TryParse(Console.ReadLine(), out s);

            Console.Write("Cargo (1. Programador 2. Admin 3 Diseñador):");
            int c;
            int.TryParse(Console.ReadLine(), out c);

            var emple = new Empleado()
            {
                nombre = nombre,
                dni = dni,
                salario = s,
                idCargo = c

            };
            ae.Add(emple);
        }

        public static void BuscarSalario()
        {
            var ae = new RepositorioEmpleados();
            Console.Write("Salario:");
            decimal s;
            decimal.TryParse(Console.ReadLine(), out s);

            var datos = ae.GetBySalario(s);

            foreach (var empleado in datos)
            {
                Console.Write("{0} con cargo {1} y salario {2}",
                    empleado.nombre,empleado.Cargo.nombre,
                    empleado.salario!=null?empleado.salario.ToString():
                    "No cobra");
            }
        }

        public static void buscarClave()
        {
            var ae = new RepositorioEmpleados();
            Console.Write("Clave:");
            int c;
            int.TryParse(Console.ReadLine(), out c);

            var empleado = ae.GetById(c);


            try
            {
                Console.Write("{0} con cargo {1} y salario {2}",
                    empleado.nombre, empleado.Cargo.nombre,
                    empleado.salario != null ? empleado.salario.ToString() :
                        "No cobra");
            }
            catch (Exception e)
            {
                Console.WriteLine("No hay datos");
            }
            
        }

        public static void Borrar()
        {
            var ae = new RepositorioEmpleados();
            Console.Write("Clave:");
            int c;
            int.TryParse(Console.ReadLine(), out c);

            ae.Borrar(ae.GetById(c));


           
        
        
        }
    }
}
