
namespace KweetService.Domain.Text.Entities.Base
{
    /// <summary>
    /// The base class or all text entities.
    /// </summary>
    public abstract class TextEntity
    {
        /// <summary>
        /// The index in the kweet text where the entity starts.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// The index in the kweet text where the entity ends.
        /// </summary>
        public int End { get; set; }

        /// <summary>
        /// The textual value of the entity.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextEntity"/> class.
        /// </summary>
        /// <param name="start">The index in the tweet text where the entity starts.</param>
        /// <param name="end">The index in the tweet text where the entity ends.</param>
        /// <param name="value">The textual value of the entity.</param>
        internal TextEntity(int start, int end, string value)
        {
            this.Start = start;
            this.End = end;
            this.Value = value;
        }
    }
}
