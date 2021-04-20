using System;
using System.Numerics;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public bool All(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return SimdOps<T>.All(InternalArray, vPredicate.ToStruct(), predicate.ToStruct());
        }

        public bool Any(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return SimdOps<T>.Any(InternalArray, vPredicate.ToStruct(), predicate.ToStruct());
        }

        public bool Contains(T value)
        {
            return SimdOps<T>.Contains(InternalArray, value);
        }

        public void Foreach(Action<Vector<T>> vAction, Action<T> action)
        {
            SimdOps<T>.Foreach(InternalArray, vAction.ToStruct(), action.ToStruct());
        }

        public int IndexOf(T value)
        {
            return SimdOps<T>.IndexOf(InternalArray, value);
        }

        public int IndexOf(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return SimdOps<T>.IndexOf(InternalArray, vPredicate.ToStruct(), predicate.ToStruct());
        }

        public T[] ToArray()
        {
            return InternalArray.AsSpan().ToArray();
        }
    }
}
