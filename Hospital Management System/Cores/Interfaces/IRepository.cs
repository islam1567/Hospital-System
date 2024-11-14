namespace Hospital_Management_System.Cores.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(string id);
        void Add (T entity);
        void Update (string id, T entity);
        void Delete (string id);
    }
}
