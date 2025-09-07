using BackendTrainingEst.Api.Helpers;
using BackendTrainingEst.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTrainingEst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region Hola mundo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola mundo");
        }
        #endregion
        #region Saludar por nombre
        [HttpGet("saludo/{nombre}")]
        public IActionResult Saludar(string nombre)
        {
            return Ok($"Hola, {nombre}");
        }
        #endregion
        #region Sumar dos números
        [HttpGet("sumar/{a}/{b}")]
        public IActionResult Sumar(int a, int b)
        {
            int resultado = a + b;
            return Ok(resultado);
        }
        #endregion
        #region Lista de frutas
        [HttpGet("frutas")]
        public IActionResult ObtenerFrutas()
        {
            string[] frutas = { "Manzana", "Banana", "Naranja", "Fresa", "Uva" };
            return Ok(frutas);
        }
        #endregion
        #region Buscar en lista
        [HttpGet("buscar/{item}")]
        public IActionResult BuscarItem(string item)
        {
            string[] lista = { "Manzana", "Banana", "Naranja", "Fresa", "Uva" };

            bool encontrado = false;

            foreach (string fruta in lista)
            {
                if (fruta.ToLower() == item.ToLower())
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
                return Ok($"{item} se encontró en la lista");
            else
                return NotFound($"{item} no se encontró en la lista");
        }
        #endregion
        #region Filtrar números pares
        [HttpPost("filtrar-pares")]
        public IActionResult FiltrarPares([FromBody] List<int> numeros)
        {
            List<int> pares = new List<int>();

            foreach (int num in numeros)
            {
                if (num % 2 == 0)
                {
                    pares.Add(num);
                }
            }

            return Ok(pares);
        }
        #endregion
        #region Contador de palabras
        [HttpPost("contar-palabras")]
        public IActionResult ContarPalabras([FromBody] string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return Ok(0);
            string[] palabras = texto.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            int cantidad = palabras.Length;

            return Ok(cantidad);
        }
        #endregion
        #region Lista de productos
        [HttpGet("productos")]
        public IActionResult ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Guitarra", Precio = 1500 },
                new Producto { Id = 2, Nombre = "Piano", Precio = 5000 },
                new Producto { Id = 3, Nombre = "Batería", Precio = 3000 }
            };

            return Ok(productos);
        }
        #endregion
        #region Lista de empleados (herencia)
        [HttpGet("empleados")]
        public IActionResult ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>
            {
                new Empleado { Id = 1, Nombre = "Juan", Salario = 2000 },
                new Empleado { Id = 2, Nombre = "Ana", Salario = 2200 },
                new Gerente { Id = 3, Nombre = "Carlos", Salario = 5000, Departamento = "Ventas" }
            };

            return Ok(empleados);
        }
        #endregion
        #region Lista dinámica genérica
        private static List<string> listaItems = new List<string>();

        [HttpPost("agregar-item")]
        public IActionResult AgregarItem([FromBody] string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                return BadRequest("No se puede agregar un item vacío");

            listaItems.Add(item);
            return Ok(new { mensaje = "Item agregado", listaActual = listaItems });
        }
        #endregion
        #region HashSet de números únicos
        private static HashSet<int> numerosUnicos = new HashSet<int>();

        [HttpPost("agregar-numero")]
        public IActionResult AgregarNumero([FromBody] int numero)
        {
            
            bool agregado = numerosUnicos.Add(numero);

            if (!agregado)
                return BadRequest($"El número {numero} ya existe en la colección");

            return Ok(new { mensaje = $"Número {numero} agregado", numeros = numerosUnicos });
        }
        #endregion
        #region Validar edad
        [HttpGet("validar-edad/{edad}")]
        public IActionResult ValidarEdad(int edad)
        {
            if (edad < 18)
            {
                return BadRequest("Edad invalida: La edad debe ser mayor o igual a 18 años");
            }

            return Ok($"Edad válida: {edad} años");
        }
        #endregion
        #region Ordenar usuarios por edad
        [HttpGet("usuarios/ordenados")]
        public IActionResult ObtenerUsuariosOrdenados()
        {
            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario { Nombre = "Juan", Edad = 25 },
                new Usuario { Nombre = "Ana", Edad = 20 },
                new Usuario { Nombre = "Carlos", Edad = 30 }
            };

            
            var usuariosOrdenados = usuarios.OrderBy(u => u.Edad).ToList();

            return Ok(usuariosOrdenados);
        }
        #endregion
    }

}
