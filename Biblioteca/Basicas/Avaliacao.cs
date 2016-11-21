using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Avaliacao
    {
        private int codigoAvaliacao;
        private Double nota;
        private string descricao;
        private Disciplina_Turma disciplina_turma;
        private Aluno aluno;

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
