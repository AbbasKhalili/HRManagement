namespace HRFramework
{
    public abstract class EntityBase<T>
    {
        public T Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityBase<T> entity)) return false;

            return this.Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
