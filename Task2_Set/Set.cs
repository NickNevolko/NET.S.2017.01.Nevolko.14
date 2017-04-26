using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Set
{
    public class Set<T> : IEnumerable<T> where T: class
    {
        private List<T> items;
        private readonly IEqualityComparer<T> equalityComparer;
        public int Count => items.Count;

        #region constructors
        public Set(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            if (ReferenceEquals(items, null))
                throw new ArgumentNullException(nameof(items));

            if (ReferenceEquals(equalityComparer, null))
                this.equalityComparer = EqualityComparer<T>.Default;
            else
                this.equalityComparer = equalityComparer;

            this.items = new List<T>();

            foreach (var item in items)
            {
                if (!ReferenceEquals(item, null))
                    Add(item);
            }
        }
        public Set(IEqualityComparer<T> equalityComparer)
        {
            if (ReferenceEquals(equalityComparer, null))
                this.equalityComparer = EqualityComparer<T>.Default;
            else
                this.equalityComparer = equalityComparer;
            this.items = new List<T>();
        }

        public Set(IEnumerable<T> items) : this(items, EqualityComparer<T>.Default) { }

        public Set() : this(EqualityComparer<T>.Default) { }
        #endregion

        #region indexer
        public T this[int i]
        {
            get
            {
                if (i > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return items[i];
                }
            }
                      
            set
            {
                if(i > Count)
                {
                    throw new IndexOutOfRangeException(nameof(i));
                }
                if (Contains(value))
                {
                    return;
                }
                else
                {
                    items[i] = value;
                }
            }
        }
        #endregion

        #region class public methods
        public bool Add(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException(nameof(item));
            if (Contains(item))
                return false;
            else
                items.Add(item);
                return true;
        }

        public bool Remove(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(T item)
        {
            return items.Contains(item, equalityComparer);
        }

        public void UnionWith(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                this.Add(item);
            }
        }

        public void IntersectWith(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            List<T> newSet = new List<T>();
            foreach(var item in other)
            {
                if (this.Contains(item))
                {
                    newSet.Add(item);
                }
            }
            this.items = newSet;
        }

        public void ExceptWith(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                if (this.Contains(item))
                    this.items.Remove(item);
            }
        }

        public void SymmetricExceptWith(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            var union = Union(other);
            var intersection = Intersect(other);
            union.ExceptWith(intersection);
            this.items = union.items;
        }

        public Set<T> Union(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                this.Add(item);
            }
            return this;
        }

        public Set<T> Except(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                if (this.Contains(item))
                    this.items.Remove(item);
            }
            return this;
        }

        public Set<T> Intersect(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            List<T> newSet = new List<T>();
            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    newSet.Add(item);
                }
            }
            this.items = newSet;
            return this;
        }

        public Set<T> SymmetricExcept(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            var union = Union(other);
            var intersection = Intersect(other);
            return union.Except(intersection);
        }

        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
