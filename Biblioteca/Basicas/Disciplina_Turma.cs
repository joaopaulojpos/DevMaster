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
    public class Disciplina_Turma
    {
        private int codigoDisciplinaTurma;
        private Turma turma;
        private Disciplina disciplina;
        private Usuario usuario;
        [DataMember(IsRequired = true)]
        public int CodigoDisciplinaTurma
        {
            get
            {
                return codigoDisciplinaTurma;
            }

            set
            {
                codigoDisciplinaTurma = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Turma Turma
        {
            get
            {
                return turma;
            }

            set
            {
                turma = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Disciplina Disciplina
        {
            get
            {
                return disciplina;
            }

            set
            {
                disciplina = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }
    }
}
