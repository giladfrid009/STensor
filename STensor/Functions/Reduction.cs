using System;
using System.Numerics;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public T Aggregate(T seed, Func<Vector<T>, Vector<T>, Vector<T>> vAccumulator, Func<T, T, T> accumulator)
        {
            return SimdOps<T>.Aggregate(InternalArray, seed, vAccumulator.ToStruct(), accumulator.ToStruct());
        }

        public T Average()
        {
            return SimdOps<T>.Average(InternalArray);
        }

        public T Average(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return SimdOps<T>.Average(InternalArray, vSelector.ToStruct(), selector.ToStruct());
        }

        public T Dot(T value)
        {
            return SimdOps<T>.Dot(InternalArray, value);
        }

        public T Dot(Tensor<T> other)
        {
            return SimdOps<T>.Dot(InternalArray, other.InternalArray);
        }

        public T Max()
        {
            return SimdOps<T>.Max(InternalArray);
        }

        public T Max(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return SimdOps<T>.Max(InternalArray, vSelector.ToStruct(), selector.ToStruct());
        }

        public T Min()
        {
            return SimdOps<T>.Min(InternalArray);
        }

        public T Min(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return SimdOps<T>.Min(InternalArray, vSelector.ToStruct(), selector.ToStruct());
        }

        public T Sum()
        {
            return SimdOps<T>.Sum(InternalArray);
        }

        public T Sum(Func<Vector<T>, Vector<T>> vSelector, Func<T, T> selector)
        {
            return SimdOps<T>.Sum(InternalArray, vSelector.ToStruct(), selector.ToStruct());
        }
    }
}
