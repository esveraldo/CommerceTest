namespace CommerceTest.Domain.Entities.VOs
{
    public class Endereco : ValueObject
    {
        //public Endereco(){} Não usar em VO

        public Endereco(string? rua, string? numero, string? complemento, string? bairro, string? cidade, string? estado, string? cep)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        public string? Rua { get; private set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }
        public string? Cep { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rua;
            yield return Numero;
            yield return Complemento;
            yield return Bairro;
            yield return Cidade;
            yield return Estado;
            yield return Cep;
        }
    }
}
