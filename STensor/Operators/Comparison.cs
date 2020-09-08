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

            return ArrayOps<T>.Greater(left.InternalArray, right.InternalArray);
        }

        public static bool operator >(Tensor<T> left, T right)
        {
            return ArrayOps<T>.Greater(left.InternalArray, right);
        }

        public static bool operator >(T left, Tensor<T> right)
        {
            return ArrayOps<T>.Less(right.InternalArray, left);
        }

        public static bool operator <(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return ArrayOps<T>.Less(left.InternalArray, right.InternalArray);
        }

        public static bool operator <(Tensor<T> left, T right)
        {
            return ArrayOps<T>.Less(left.InternalArray, right);
        }

        public static bool operator <(T left, Tensor<T> right)
        {
            return ArrayOps<T>.Greater(right.InternalArray, left);
        }

        public static bool operator >=(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return ArrayOps<T>.GreaterOrEqual(left.InternalArray, right.InternalArray);
        }

        public static bool operator >=(Tensor<T> left, T right)
        {
            return ArrayOps<T>.GreaterOrEqual(left.InternalArray, right);
        }

        public static bool operator >=(T left, Tensor<T> right)
        {
            return ArrayOps<T>.LessOrEqual(right.InternalArray, left);
        }

        public static bool operator <=(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            return ArrayOps<T>.LessOrEqual(left.InternalArray, right.InternalArray);
        }

        public static bool operator <=(Tensor<T> left, T right)
        {
            return ArrayOps<T>.LessOrEqual(left.InternalArray, right);
        }

        public static bool operator <=(T left, Tensor<T> right)
        {
            return ArrayOps<T>.GreaterOrEqual(right.InternalArray, left);
        }

    }
}
