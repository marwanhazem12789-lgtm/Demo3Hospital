namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics
{
    public interface IGenaricRepo<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T GetById(int id);
    }
}
