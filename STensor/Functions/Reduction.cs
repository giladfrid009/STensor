using System;
using System.Numerics;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public T Aggregate(T seed, Func<Vector<T>, Vector<T>, Vector<T>> vAccumulator, Func<T, T, T> accumulator)
        {
            return ArrayOps<T>.Aggregate(InternalArray, seed, vAccumulator, accumulator);
        }

        public T Average()
        {
            return ArrayOps<T>.Average(InternalArray);
        }

        public T Average(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return ArrayOps<T>.Average(InternalArray, vSelector, selector);
        }

        public T Dot(T value)
        {
            return ArrayOps<T>.Dot(InternalArray, value);
        }

        public T Dot(Tensor<T> other)
        {
            return ArrayOps<T>.Dot(InternalArray, other.InternalArray);
        }

        public T Max()
        {
            return ArrayOps<T>.Max(InternalArray);
        }

        public T Max(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return ArrayOps<T>.Max(InternalArray, vSelector, selector);
        }

        public T Min()
        {
            return ArrayOps<T>.Min(InternalArray);
        }

        public T Min(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return ArrayOps<T>.Min(InternalArray, vSelector, selector);
        }

        public T Sum()
        {
            return ArrayOps<T>.Sum(InternalArray);
        }

        public T Sum(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return ArrayOps<T>.Sum(InternalArray, vSelector, selector);
        }

        public T Sum(Func<Vector<T>, int, Vector<T>> vSelector, Func<T, int, T> selector)
        {
            return ArrayOps<T>.Sum(InternalArray, vSelector, selector);
        }
    }
}
