using Opgave05._10.Interfaces;namespace Opgave05._10.Classes
{
    public abstract class Entity : IPersistable
    {
        protected int _id;

        public int Id => _id;

        public Entity(int id) => _id = id;
    }
}
