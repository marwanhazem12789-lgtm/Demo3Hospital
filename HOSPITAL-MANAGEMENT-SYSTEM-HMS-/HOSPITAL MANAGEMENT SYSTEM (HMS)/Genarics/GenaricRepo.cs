using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics
{
    public class GenaricRepo<T> where T : class
    {
        private readonly Context c;
        public GenaricRepo(Context c)
        {
            this.c = c;
        }
        public void Add(T item)
        {
            c.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                c.Set<T>().Remove(entity);
            }
        }



        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            c.Set<T>().Update(item);
        }
    }
}
