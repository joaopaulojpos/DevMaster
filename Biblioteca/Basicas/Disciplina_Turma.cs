using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Basicas
{
    public class Disciplina_Turma
    {
        private int codigoDisciplinaTurma;
        private Turma turma;
        private Disciplina disciplina;
        private Usuario usuario;

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

        public Ensino Turma
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
