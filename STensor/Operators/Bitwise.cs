using STensor.Exceptions;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public static Tensor<T> operator ~(Tensor<T> tensor)
        {
            T[] result = SimdOps<T>.Not(tensor.InternalArray);

            return FromRef(tensor.Shape, result);
        }

        public static Tensor<T> operator &(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = SimdOps<T>.Add(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator &(Tensor<T> left, T right)
        {
            T[] result = SimdOps<T>.Add(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator &(T left, Tensor<T> right)
        {
            T[] result = SimdOps<T>.Add(right.InternalArray, left);

            return FromRef(right.Shape, result);
        }

        public static Tensor<T> operator |(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = SimdOps<T>.Or(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator |(Tensor<T> left, T right)
        {
            T[] result = SimdOps<T>.Or(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator |(T left, Tensor<T> right)
        {
            T[] result = SimdOps<T>.Or(right.InternalArray, left);

            return FromRef(right.Shape, result);
        }

        public static Tensor<T> operator ^(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = SimdOps<T>.Xor(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator ^(Tensor<T> left, T right)
        {
            T[] result = SimdOps<T>.Xor(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator ^(T left, Tensor<T> right)
        {
            T[] result = SimdOps<T>.Xor(right.InternalArray, left);

            return FromRef(right.Shape, result);
        }
    }
}
