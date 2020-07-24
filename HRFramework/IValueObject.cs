namespace HRFramework
{
    public interface IValueObject<T> where T : class
    {
        bool SameValueAs(T valueObject);
        
    }
}