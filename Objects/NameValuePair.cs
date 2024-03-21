using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AquariusShell.Objects
{
    /// <summary>
    /// A pair of a name and a value. This type is primarily for use with 
    /// CheckedListBox controls.
    /// </summary>
    public class NameValuePair<T>
    {
        /// <summary>
        /// The display text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get; set;

        } = string.Empty;

        /// <summary>
        /// The underlying (freeform value)
        /// </summary>
        [JsonPropertyName("value")]
        public T? Value
        {
            get; set;

        }

        /// <summary>
        /// Default initialiser
        /// </summary>
        public NameValuePair()
        {
        }

        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="text">The display text</param>
        /// <param name="value">The underlying (freeform value)</param>
        public NameValuePair(string text, T? value)
        {
            Text = text;
            Value = value;
        }


        /// <summary>
        /// Returns the value of the Text property
        /// </summary>
        public override string ToString()
            => Text;


        /// <summary>
        /// Returns if the provided collection contains the given item
        /// </summary>
        /// <param name="collection">Collection to check in</param>
        /// <param name="item">Item to search for</param>
        /// <returns>True if collection contains the item</returns>
        public static bool Contains(IEnumerable<NameValuePair<T>> collection, NameValuePair<T> item)
        {
            foreach(NameValuePair<T> x in collection)
            {
                if (x.Text.Equals(item.Text) || ((x.Value != null) && x.Value.Equals(item.Value)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
