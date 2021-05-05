using DataAccess.Abstract;
using Etities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var addEntity = rentACarContext.Entry(entity);
                addEntity.State = EntityState.Added;
                rentACarContext.SaveChanges();

            }
        }

        public void Delete(Brand entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var deletedEntity = rentACarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACarContext.SaveChanges();

            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return rentACarContext.Set<Brand>().SingleOrDefault(filter);

            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return filter == null ? rentACarContext.Set<Brand>().ToList() : rentACarContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var updatedEntity = rentACarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                rentACarContext.SaveChanges();

            }
        }
    }
}
