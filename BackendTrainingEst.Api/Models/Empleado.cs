namespace BackendTrainingEst.Api.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Salario { get; set; }
    }

    public class Gerente : Empleado
    {
        public string Departamento { get; set; }
    }
}
