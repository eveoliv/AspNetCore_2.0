﻿using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {

        public CadastroRepository(ApplicationContext context) : base(context){}

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cadastroId).SingleOrDefault();

            if (cadastroDB == null)
            {
                throw new ArgumentException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            context.SaveChanges();
            return cadastroDB;
        }
    }
}
