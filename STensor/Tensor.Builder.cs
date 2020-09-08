using SimpleSimd;
using STensor.Exceptions;
using System;

namespace STensor
{
    public partial class Tensor<T>
    {
        public class Builder
        {
            public Shape Shape { get; private set; }
            public int Volume => Shape.Volume;

            public T this[int index]
            {
                get => BuilderArray[index];
                set => BuilderArray[index] = value;
            }

            public T this[int[] indices]
            {
                get => BuilderArray[Shape.FlattenIndices(indices)];
                set => BuilderArray[Shape.FlattenIndices(indices)] = value;
            }

            protected T[] BuilderArray;

            protected Builder(Shape shape, T[] array, bool asRef)
            {
                if (shape.Volume != array.Length)
                {
                    throw new ShapeMismatchException(nameof(shape));
                }

                Shape = shape;

                BuilderArray = asRef ? array : ArrayOps<T>.Copy(array);
            }

            public Builder(Shape shape) : this(shape, new T[shape.Volume], true)
            {
            }

            public Builder(params T[] elements) : this(new Shape(elements.Length), elements, false)
            {
            }

            public Builder(Shape shape, params T[] elements) : this(shape, elements, false)
            {
            }

            public static implicit operator T[](Builder builder)
            {
                return builder.BuilderArray;
            }

            public static Builder Fill(Shape shape, T value)
            {
                T[] array = new T[shape.Volume];

                ArrayOps<T>.Fill(array, value);

                return new Builder(shape, array, true);
            }

            public Tensor<T> ToTensor()
            {
                var array = BuilderArray;
                var shape = Shape;

                BuilderArray = Array.Empty<T>();
                Shape = Shape.Empty;

                return Tensor<T>.FromRef(shape, array);
            }
        }
    }
}
