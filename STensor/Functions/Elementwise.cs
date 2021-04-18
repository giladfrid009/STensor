using System;
using System.Numerics;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public Tensor<T> Abs()
        {
            return FromRef(Shape, SimdOps<T>.Abs(InternalArray));
        }

        public Tensor<T> Sqrt()
        {
            return FromRef(Shape, SimdOps<T>.Sqrt(InternalArray));
        }

        public Tensor<U> Select<U>(Func<Vector<T>, Vector<U>> vSelector, Func<T, U> selector) where U : unmanaged
        {
            return Tensor<U>.FromRef(Shape, SimdOps<T>.Select(InternalArray, vSelector, selector));
        }

        public Tensor<U> Select<U>(Func<Vector<T>, int, Vector<U>> vSelector, Func<T, int, U> selector) where U : unmanaged
        {
            return Tensor<U>.FromRef(Shape, SimdOps<T>.Select(InternalArray, vSelector, selector));
        }

        public Tensor<U> Concat<U>(Tensor<T> other, Func<Vector<T>, Vector<T>, Vector<U>> vSelector, Func<T, T, U> selector) where U : unmanaged
        {
            return Tensor<U>.FromRef(Shape, SimdOps<T>.Concat(InternalArray, other.InternalArray, vSelector, selector));
        }
    }
}
