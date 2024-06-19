using clinicteo.Context;
using clinicteo.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace clinicteo.UnitOfWork.Repositories.impl
{
    public class GenericRepository<T> : IRepositoryGeneric<T> where T : BaseEntity
    {
        private readonly ClinicTeoContext context;
        private readonly DbSet<T> dataset;
        private readonly DateOnly dateOnly;

        public GenericRepository(ClinicTeoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            dataset = context.Set<T>();
            dateOnly = DateOnly.FromDateTime( DateTime.Now );
        }

        public void Delete(int id)
        {
            var entity = dataset.SingleOrDefault(e => e.Id == id);
            if (entity != null)
            {
                try
                {
                    dataset.Remove(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to delete entity!", ex);
                }
            }
            else
            {
                throw new InvalidOperationException("Entity not found!");
            }
        }

        public T FindById(int id)
        {
            var entity = dataset.FirstOrDefault(e => e.Id.Equals(id));
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found!");
            }
            return entity;
        }

        public T Save(T entity)
        {
            try
            {
                dataset.Add(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save entity!", ex);
            }
        }

        public T Update(T entity)
        {
            try
            {
                dataset.Update(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update entity!", ex);
            }
        }

        public List<T> GetAll()
        {
            return dataset.ToList();
        }
    }
}