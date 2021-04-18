using System;
using System.Numerics;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public bool All(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return SimdOps<T>.All(InternalArray, vPredicate, predicate);
        }

        public bool Any(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return SimdOps<T>.Any(InternalArray, vPredicate, predicate);
        }

        public bool Contains(T value)
        {
            return SimdOps<T>.Contains(InternalArray, value);
        }

        public void Foreach(Action<Vector<T>> vAction, Action<T> action)
        {
            SimdOps<T>.Foreach(InternalArray, vAction, action);
        }

        public void Foreach(Action<Vector<T>, int> vAction, Action<T, int> action)
        {
            SimdOps<T>.Foreach(InternalArray, vAction, action);
        }

        public int IndexOf(T value)
        {
            return SimdOps<T>.IndexOf(InternalArray, value);
        }

        public int IndexOf(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return SimdOps<T>.IndexOf(InternalArray, vPredicate, predicate);
        }

        public T[] ToArray()
        {
            return InternalArray.AsSpan().ToArray();
        }
    }
}
