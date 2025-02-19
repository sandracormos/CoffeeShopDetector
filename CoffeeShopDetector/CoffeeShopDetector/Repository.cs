namespace CoffeeShopDetector
{
    public abstract class Repository<T>
    {
        protected List<T> elements = new List<T>();
        public abstract void Initialize(string filePath);
        public abstract T GetAt(int index);
        public abstract List<T> GetAll();
    }
}
