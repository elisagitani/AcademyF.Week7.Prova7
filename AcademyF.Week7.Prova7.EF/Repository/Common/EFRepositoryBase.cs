using AcademyF.Week7.Prova7.Core.Interfaces;
using AcademyF.Week7.Prova7.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyF.Week7.Prova7.EF.Repository.Common
{
    public abstract class EFRepositoryBase<T>: IRepository<T>
        where T: class, IEntity, new()
    {
        public CommerceDbContext Context { get; set; }

        public EFRepositoryBase()
        {
            Context = new CommerceDbContext();
        }

        public EFRepositoryBase(CommerceDbContext context)
        {
            Context = context;
        }

        public bool Create(T entity)
        {
            if (entity == null)
                return false;

            try
            {
                GetDbSet().Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                string message = ex.Message;
                return false;
            }
        }

        public abstract DbSet<T> GetDbSet();

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;
            try
            {
                var deletedEntity = GetDbSet().SingleOrDefault(e => e.Id == id);
                if (deletedEntity == null)
                    return false;
                GetDbSet().Remove(deletedEntity);
                Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<T> Fetch(Func<T, bool> filter = null)
        {
            if (filter != null)
                return GetDbSet().Where(filter).ToList();

            return GetDbSet().ToList();
        }

        public T Get(int id)
        {
            if (id <= 0)
                return null;
            return GetDbSet().SingleOrDefault(l => l.Id == id);
        }

        public bool Update(T entity)
        {
            if (entity == null)
                return false;

            try
            {
                GetDbSet().Update(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}

