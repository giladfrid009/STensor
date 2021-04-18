using STensor.Exceptions;
using SimpleSimd;
using System;

namespace STensor
{
    [Serializable]
    public partial class Tensor<T> : IEquatable<Tensor<T>>, IEquatable<T> where T : unmanaged
    {
        public Shape Shape { get; }
        public int Volume => Shape.Volume;
        public T this[int index] => InternalArray[index];
        public T this[int[] indices] => InternalArray[Shape.FlattenIndices(indices)];

        protected readonly T[] InternalArray;

        protected Tensor(Shape shape, T[] array, bool asRef = false)
        {
            if (shape.Volume != array.Length)
            {
                throw new ShapeMismatchException(nameof(shape));
            }

            Shape = shape;

            InternalArray = asRef ? array : array.AsSpan().ToArray();
        }

        public Tensor(params T[] elements) : this(new Shape(elements.Length), elements, false)
        {
        }

        public Tensor(Shape shape, params T[] elements) : this(shape, elements, false)
        {
        }

        public static Tensor<T> FromRef(Shape shape, params T[] array)
        {
            return new Tensor<T>(shape, array, true);
        }

        public static Tensor<T> Fill(Shape shape, T value)
        {
            T[] array = new T[shape.Volume];

            SimdOps<T>.Fill(array, value);

            return FromRef(shape, array);
        }
    }
}