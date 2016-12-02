using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    [Serializable]
    [DataContract()]
    public class Aula
    {
        private int codigoAula;
        private string data;
        private string assunto;
        private Disciplina_Turma disciplinaTurma;
        [DataMember(IsRequired = true)]
        public int CodigoAula
        {
            get
            {
                return codigoAula;
            }

            set
            {
                codigoAula = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string Assunto
        {
            get
            {
                return assunto;
            }

            set
            {
                assunto = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Disciplina_Turma DisciplinaTurma
        {
            get
            {
                return disciplinaTurma;
            }

            set
            {
                disciplinaTurma = value;
            }
        }
    }
}
