using System;
using System.Numerics;
using STensor.Exceptions;
using SimpleSimd;

namespace STensor
{
    public partial class Tensor<T>
    {
        public bool All(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return ArrayOps<T>.All(InternalArray, vPredicate, predicate);
        }

        public bool Any(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return ArrayOps<T>.Any(InternalArray, vPredicate, predicate);
        }

        public bool Contains(T value)
        {
            return ArrayOps<T>.Contains(InternalArray, value);
        }

        public Tensor<T> Copy()
        {
            return FromRef(Shape, InternalArray);
        }

        public Tensor<T> Copy(Shape shape)
        {
            if (shape.Volume != Volume)
            {
                throw new ShapeMismatchException(nameof(shape));
            }

            return FromRef(shape, InternalArray);
        }

        public void Foreach(Action<Vector<T>> vAction, Action<T> action)
        {
            ArrayOps<T>.Foreach(InternalArray, vAction, action);
        }

        public void Foreach(Action<Vector<T>, int> vAction, Action<T, int> action)
        {
            ArrayOps<T>.Foreach(InternalArray, vAction, action);
        }

        public int IndexOf(T value)
        {
            return ArrayOps<T>.IndexOf(InternalArray, value);
        }

        public int IndexOf(Func<Vector<T>, bool> vPredicate, Func<T, bool> predicate)
        {
            return ArrayOps<T>.IndexOf(InternalArray, vPredicate, predicate);
        }

        public T[] ToArray()
        {
            return ArrayOps<T>.Copy(InternalArray);
        }
    }
}
