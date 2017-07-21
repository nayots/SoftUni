namespace Tuple.Models.Generics
{
    public class CustomTuple<T, U>
    {
        public CustomTuple(T itemOne, U ItemTwo)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = ItemTwo;
        }

        public T ItemOne { get; protected set; }
        public U ItemTwo { get; protected set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo}";
        }
    }
}