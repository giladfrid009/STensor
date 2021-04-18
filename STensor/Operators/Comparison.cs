using STensor.Exceptions;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public static bool operator ==(Tensor<T> left, Tensor<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator ==(Tensor<T> left, T right)
        {
            return left.Equals(right);
        }

        public static bool operator ==(T left, Tensor<T> right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(Tensor<T> left, Tensor<T> right)
        {
            return !(left == right);
        }

        public static bool operator !=(Tensor<T> left, T right)
        {
            return !(left == right);
        }

        public static bool operator !=(T left, Tensor<T> right)
        {
            return !(left == right);
        }

        public static bool operator >(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return SimdOps<T>.Greater(left.InternalArray, right.InternalArray);
        }

        public static bool operator >(Tensor<T> left, T right)
        {
            return SimdOps<T>.Greater(left.InternalArray, right);
        }

        public static bool operator >(T left, Tensor<T> right)
        {
            return SimdOps<T>.Less(right.InternalArray, left);
        }

        public static bool operator <(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return SimdOps<T>.Less(left.InternalArray, right.InternalArray);
        }

        public static bool operator <(Tensor<T> left, T right)
        {
            return SimdOps<T>.Less(left.InternalArray, right);
        }

        public static bool operator <(T left, Tensor<T> right)
        {
            return SimdOps<T>.Greater(right.InternalArray, left);
        }

        public static bool operator >=(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return SimdOps<T>.GreaterOrEqual(left.InternalArray, right.InternalArray);
        }

        public static bool operator >=(Tensor<T> left, T right)
        {
            return SimdOps<T>.GreaterOrEqual(left.InternalArray, right);
        }

        public static bool operator >=(T left, Tensor<T> right)
        {
            return SimdOps<T>.LessOrEqual(right.InternalArray, left);
        }

        public static bool operator <=(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return SimdOps<T>.LessOrEqual(left.InternalArray, right.InternalArray);
        }

        public static bool operator <=(Tensor<T> left, T right)
        {
            return SimdOps<T>.LessOrEqual(left.InternalArray, right);
        }

        public static bool operator <=(T left, Tensor<T> right)
        {
            return SimdOps<T>.GreaterOrEqual(right.InternalArray, left);
        }

    }
}
