using System.Collections;
using System.Collections.Generic;

namespace AquariusShell.Controls
{
    /// <summary>
    /// Collection of accordion items
    /// </summary>
    public class AccordionItemCollection : IEnumerable<AccordionItem>
    {
        /// <summary>
        /// Add item to collection
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(AccordionItem item)
        {
            _collection.Add(item);
            if (AccordionItemAdded != null)
            {
                AccordionItemAdded(item);
            }
        }

        /// <summary>
        /// Remove item from collection
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(AccordionItem item)
        {
            _collection.Remove(item);
            if (AccordionItemRemoved != null)
            {
                AccordionItemRemoved(item);
            }
        }

        /// <summary>
        /// Number of items in collection
        /// </summary>
        public int Count => _collection.Count;

        /// <summary>
        /// Clear the collection
        /// </summary>
        /// <param name="suppressEvent">When TRUE, does not raise the Removed event for every item removed.</param>
        public void Clear(bool suppressEvent)
        {
            if ((_collection.Count > 0) && (!suppressEvent) && (AccordionItemRemoved != null))
            {
                foreach (AccordionItem item in _collection)
                {
                    AccordionItemRemoved(item);
                }
            }
            _collection.Clear();
        }


        public AccordionItemCollection()
        {
            _collection = [];
        }


        /// <summary>
        /// Item was added to this collection
        /// </summary>
        public event ItemAdded? AccordionItemAdded;

        /// <summary>
        /// Item was removed from this collection
        /// </summary>
        public event ItemRemoved? AccordionItemRemoved;

        public IEnumerator<AccordionItem> GetEnumerator() => _collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _collection.GetEnumerator();


        private List<AccordionItem> _collection;
    }
}
