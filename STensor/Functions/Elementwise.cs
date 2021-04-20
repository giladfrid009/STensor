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

        public Tensor<TRes> Select<TRes>(Func<Vector<T>, Vector<TRes>> vSelector, Func<T, TRes> selector) where TRes : unmanaged
        {
            return Tensor<TRes>.FromRef(Shape, SimdOps<T>.Select<TRes, FWrapper<Vector<T>, Vector<TRes>>, FWrapper<T, TRes>>(InternalArray, vSelector.ToStruct(), selector.ToStruct()));
        }

        public Tensor<TRes> Concat<TRes>(Tensor<T> other, Func<Vector<T>, Vector<T>, Vector<TRes>> vSelector, Func<T, T, TRes> selector) where TRes : unmanaged
        {
            return Tensor<TRes>.FromRef(Shape, SimdOps<T>.Concat<TRes, FWrapper<Vector<T>, Vector<T>, Vector<TRes>>, FWrapper<T, T, TRes>>(InternalArray, other.InternalArray, vSelector.ToStruct(), selector.ToStruct()));
        }
    }
}
