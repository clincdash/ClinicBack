using clinicteo.Context;
using clinicteo.Models.Base;
using clinicteo.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace clinicteo.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ClinicTeoContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository( ClinicTeoContext context )
        {
            _context = context ?? throw new ArgumentNullException( nameof( context ) );
            _dataset = _context.Set<T>();
        }
        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public void Delete( int id )
        {
            var entity = _dataset.SingleOrDefault( e => e.Id == id );
            if (entity != null)
            {
                try
                {
                    _dataset.Remove( entity );
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception( "Unable to delete entity!", ex );
                }
            }
            else
            {
                throw new InvalidOperationException( "Entity not found!" );
            }
        }

        public T FindById( int id )
        {
            var entity = _dataset.FirstOrDefault( e => e.Id.Equals(id) );
            if (entity == null)
            {
                throw new InvalidOperationException( "Entity not found!" );
            }
            return entity;
        }

        public T Save( T entity )
        {
            try
            {
                _dataset.Add( entity );
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception( "Unable to save entity!", ex );
            }
        }

        public T Update( T entity )
        {
            try
            {
                _dataset.Update( entity );
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception( "Unable to update entity!", ex );
            }
        }
    }
}