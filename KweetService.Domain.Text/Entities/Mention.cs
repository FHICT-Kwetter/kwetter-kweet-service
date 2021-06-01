using KweetService.Domain.Text.Entities.Base;

namespace KweetService.Domain.Text.Entities
{
    /// <summary>
    /// A part of a kweet text where it contains a username preceded by the "@" symbol.
    /// For example : "Hello @KwetterUser"
    /// </summary>
    public class Mention : TextEntity
    {
        /// <summary>
        /// The username of the mention.
        /// Example 1: @Username -> Username will be Username.
        /// Example 2: @Username! -> Username will be Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mention"/> class.
        /// </summary>
        /// <param name="start">The starting index of the mention in the text.</param>
        /// <param name="end">The ending index (inclusive) of the mention in the text.</param>
        /// <param name="value">The full value of the mention, including the @ symbol.</param>
        public Mention(int start, int end, string value) : base(start, end, value)
        {
            this.Username = value.Remove(0, 1);
        }
    }
}
