using SimpleSimd;
using System;

namespace STensor
{
    [Serializable]
    public class Shape : IEquatable<Shape>
    {
        public static Shape Empty { get; } = new Shape();

        public int Rank { get; }
        public int Volume { get; }
        public int this[int index] => Dims[index];

        protected readonly int[] Dims;

        public Shape(params int[] dims)
        {
            if (dims.Length == 0)
            {
                Rank = 0;
                Volume = 0;
                Dims = Array.Empty<int>();
                return;
            }

            if (SimdOps<int>.Less(dims, 1))
            {
                throw new ArgumentOutOfRangeException($"{nameof(dims)} must be in range >= 1.");
            }

            Rank = dims.Length;

            Dims = dims.AsSpan().ToArray();

            Volume = SimdOps<int>.Aggregate(dims, 1, (R, X) => R * X, (R, X) => R * X);
        }
        
        public static bool operator ==(Shape left, Shape right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Shape left, Shape right)
        {
            return !(left == right);
        }

        public int FlattenIndices(params int[] indices)
        {
            if (indices.Length != Rank)
            {
                throw new RankException(nameof(indices));
            }

            for (int i = 0; i < indices.Length; i++)
            {
                if (indices[i] < 0 || indices[i] > Dims[i] - 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(indices)} must be in range (0, {Dims[i] - 1})");
                }
            }

            int flat = 0;

            for (int i = 0; i < Rank; i++)
            {
                flat = flat * Dims[i] + indices[i];
            }

            return flat;
        }

        public bool Equals(Shape? shape)
        {
            if (shape is null)
            {
                return false;
            }

            if (ReferenceEquals(this, shape))
            {
                return true;
            }

            if (Rank != shape.Rank)
            {
                return false;
            }

            return SimdOps<int>.Equal(Dims, shape.Dims);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Shape);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Dims, Volume);
        }
    }
}