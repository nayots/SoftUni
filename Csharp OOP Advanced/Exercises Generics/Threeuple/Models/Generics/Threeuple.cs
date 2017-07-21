namespace Threeuple.Models.Generics
{
    public class Threeuple<T, U, P>
    {
        public Threeuple(T itemOne, U itemTwo, P itemThree)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo;
            this.ItemThree = itemThree;
        }

        public T ItemOne { get; private set; }
        public U ItemTwo { get; private set; }
        public P ItemThree { get; private set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo} -> {this.ItemThree}";
        }
    }
}