namespace FocusOnLife.Domain.Entities
{
    public class Condominio
    {
        public int Id { get; set; }  // 🛠️ Verifique se esta linha existe
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Localidade { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoPostalLocal { get; set; }
        public string Freguesia { get; set; }
        public string Concelho { get; set; }
        public string Distrito { get; set; }
        public int NumeroFracoes { get; set; }
        public string NIF { get; set; }
        public bool CalculoQuotaPorPermilagem { get; set; }
    }
}