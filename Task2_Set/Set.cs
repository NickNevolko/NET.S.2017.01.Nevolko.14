using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Set
{
    /// <summary>
    /// represent a generic collection Set
    /// </summary>
    /// <typeparam name="T">param must be a reference type object</typeparam>
    public class Set<T> : IEnumerable<T> where T: class
    {
        private List<T> items;
        private readonly IEqualityComparer<T> equalityComparer;
        /// <summary>
        /// count of elements in set
        /// </summary>
        public int Count => items.Count;

        #region constructors
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="items">not null enumerable</param>
        /// <param name="equalityComparer">rule for checking the equality</param>
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
        /// <summary>
        /// ctor that takes no enumerables 
        /// </summary>
        /// <param name="equalityComparer">rule for checking the equality</param>
        public Set(IEqualityComparer<T> equalityComparer)
        {
            if (ReferenceEquals(equalityComparer, null))
                this.equalityComparer = EqualityComparer<T>.Default;
            else
                this.equalityComparer = equalityComparer;
            this.items = new List<T>();
        }
        /// <summary>
        /// ctor that takes no equalitycomparer
        /// </summary>
        /// <param name="items">enumerable of items</param>
        public Set(IEnumerable<T> items) : this(items, EqualityComparer<T>.Default) { }
        /// <summary>
        /// ctor with no any parameters
        /// </summary>
        public Set() : this(EqualityComparer<T>.Default) { }
        #endregion

        #region indexer
        /// <summary>
        /// indexer
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>element of set </returns>
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
        /// <summary>
        /// add a unique element in the set
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>true if sucess</returns>
        public bool Add(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException(nameof(item));
            if (Contains(item))
                return false;
            else
                items.Add(item);
                return true;
        }
        /// <summary>
        /// removing the element from the set
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>true if sucess</returns>
        public bool Remove(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// clear the set
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// check does the element contains in the set
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>true if it is</returns>
        public bool Contains(T item)
        {
            return items.Contains(item, equalityComparer);
        }

        /// <summary>
        /// union of the two sets
        /// </summary>
        /// <param name="other">other set</param>
        public void UnionWith(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// the intersection of the two sets
        /// </summary>
        /// <param name="other">other set</param>
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

        /// <summary>
        /// the exception of the two sets
        /// </summary>
        /// <param name="other">other set</param>
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

        /// <summary>
        /// the symmetric exception of the two sets
        /// </summary>
        /// <param name="other">other set</param>
        public void SymmetricExceptWith(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            var union = Union(other);
            var intersection = Intersect(other);
            union.ExceptWith(intersection);
            this.items = union.items;
        }

        /// <summary>
        /// the union of the two sets
        /// </summary>
        /// <param name="other">other set</param>
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

        /// <summary>
        /// the except of the two sets
        /// </summary>
        /// <param name="other">other set</param>
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

        /// <summary>
        /// the intersection of the two sets
        /// </summary>
        /// <param name="other">other set</param>
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

        /// <summary>
        /// the symmetric deifference of the two sets
        /// </summary>
        /// <param name="other">other set</param>
        public Set<T> SymmetricExcept(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            var union = Union(other);
            var intersection = Intersect(other);
            return union.Except(intersection);
        }

        #endregion
        /// <summary>
        ///  method of interface
        /// </summary>
        /// <returns></returns>
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
