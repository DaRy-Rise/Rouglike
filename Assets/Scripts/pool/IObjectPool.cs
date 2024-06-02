public interface IObjectPool<T>
{
    T Get();
    void ReturnToPool(T obj);
}