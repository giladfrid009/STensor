using System;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public bool Equals(Tensor<T>? tensor)
        {
            if (tensor is null)
            {
                return false;
            }

            if (ReferenceEquals(this, tensor))
            {
                return true;
            }

            return Shape == tensor.Shape && SimdOps<T>.Equals(InternalArray, tensor.InternalArray);
        }

        public bool Equals(T value)
        {
            return SimdOps<T>.Equals(InternalArray, value);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Tensor<T>) || (obj is T value && Equals(value));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InternalArray, Shape);
        }
    }
}
