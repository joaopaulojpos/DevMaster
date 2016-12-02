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
    public class Avaliacao
    {
        
        private int codigoAvaliacao;
        private Double nota;
        private string descricao;
        private Disciplina_Turma disciplina_turma;
        private Aluno aluno;
        [DataMember(IsRequired = true)]
        public double Nota
        {
            get
            {
                return nota;
            }

            set
            {
                nota = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Disciplina_Turma Disciplina_turma
        {
            get
            {
                return disciplina_turma;
            }

            set
            {
                disciplina_turma = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Aluno Aluno
        {
            get
            {
                return aluno;
            }

            set
            {
                aluno = value;
            }
        }
        [DataMember(IsRequired = true)]
        public int CodigoAvaliacao
        {
            get
            {
                return codigoAvaliacao;
            }

            set
            {
                codigoAvaliacao = value;
            }
        }
    }
}
