using STensor.Exceptions;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        protected static readonly T One = MathOps<int, T>.Convert(1);

        public static Tensor<T> operator -(Tensor<T> tensor)
        {
            T[] result = ArrayOps<T>.Negate(tensor.InternalArray);

            return FromRef(tensor.Shape, result);
        }

        public static Tensor<T> operator ++(Tensor<T> tensor)
        {
            T[] result = ArrayOps<T>.Add(tensor.InternalArray, One);

            return FromRef(tensor.Shape, result);
        }

        public static Tensor<T> operator --(Tensor<T> tensor)
        {
            T[] result = ArrayOps<T>.Subtract(tensor.InternalArray, One);

            return FromRef(tensor.Shape, result);
        }

        public static Tensor<T> operator +(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = ArrayOps<T>.Add(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator +(Tensor<T> left, T right)
        {
            T[] result = ArrayOps<T>.Add(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator +(T left, Tensor<T> right)
        {
            T[] result = ArrayOps<T>.Add(right.InternalArray, left);

            return FromRef(right.Shape, result);
        }

        public static Tensor<T> operator -(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = ArrayOps<T>.Subtract(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator -(Tensor<T> left, T right)
        {
            T[] result = ArrayOps<T>.Subtract(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator -(T left, Tensor<T> right)
        {
            T[] result = ArrayOps<T>.Subtract(left, right.InternalArray);

            return FromRef(right.Shape, result);
        }

        public static Tensor<T> operator *(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = ArrayOps<T>.Multiply(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator *(Tensor<T> left, T right)
        {
            T[] result = ArrayOps<T>.Multiply(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator *(T left, Tensor<T> right)
        {
            T[] result = ArrayOps<T>.Multiply(right.InternalArray, left);

            return FromRef(right.Shape, result);
        }

        public static Tensor<T> operator /(Tensor<T> left, Tensor<T> right)
        {
            if (left.Shape != right.Shape)
            {
                throw new ShapeMismatchException(nameof(right));
            }

            T[] result = ArrayOps<T>.Divide(left.InternalArray, right.InternalArray);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator /(Tensor<T> left, T right)
        {
            T[] result = ArrayOps<T>.Divide(left.InternalArray, right);

            return FromRef(left.Shape, result);
        }

        public static Tensor<T> operator /(T left, Tensor<T> right)
        {
            T[] result = ArrayOps<T>.Divide(left, right.InternalArray);

            return FromRef(right.Shape, result);
        }
    }
}
