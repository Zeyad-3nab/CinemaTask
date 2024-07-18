namespace CinemaTask.Repository.IRepository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Update(T temp);
        public void Delete(int id);
        public void Add(T temp);


    }
}
