namespace HRFramework
{
    public abstract class ValueObjectBase<T> : IValueObject<T> where T : class
    {
        public abstract bool SameValueAs(T valueObject);
        

        public override bool Equals(object obj)
        {
            return SameValueAs(obj as T);
        }
        
    }
}