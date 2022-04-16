using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTest.Application.Dtos
{
    public class ClienteDto
    {
        public string? Nome { get; set; }
        public string? DDD { get; set; }
        public string? Telefone { get; set; }

        //Endereco
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }

        //Documento
        public string? Documento { get; private set; }
    }
}
