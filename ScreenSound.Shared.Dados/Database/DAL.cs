﻿using ScreenSound.Modelos;

namespace ScreenSound.Database
{
    public class DAL<T> where T : class
    {
        private readonly ScreenSoundContext context;

        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condition)
        {
            return context.Set<T>().FirstOrDefault(condition);
        }
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}
