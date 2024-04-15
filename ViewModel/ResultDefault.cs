using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Domain.ViewModel
{
    public class ResultDefault <T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public ResultDefault(T data, List<string> erros)
        {
            Data = data;
            Errors = erros;
        }
        public ResultDefault(T data)
            => Data = data;

        public ResultDefault(List<string> erros)
            => Errors = erros;

        public ResultDefault(string erro)
            => Errors.Add(erro);
    }
}
