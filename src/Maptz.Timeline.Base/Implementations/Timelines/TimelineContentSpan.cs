using Maptz.Spans;
using System;
namespace Maptz.Timelines
{


    /// <summary>
    /// An object representing a timeline span.
    /// </summary>
    public class TimelineContentSpan<T> : ITimelineContentSpan<T>
    {
        public TimelineContentSpan(long start, long length, T content)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (start + length < start)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            this.Start = start;
            this.Length = length;
            this.Content = content;
        }


        /// <summary>
        /// Gets the start of the span.
        /// </summary>
        public long Start { get; }

        /// <summary>
        /// Gets the end of the span.
        /// </summary>
        public long End => Start + Length;

        /// <summary>
        /// Length of the span.
        /// </summary>
        public long Length { get; }

        public T Content { get; }

        /// <summary>
        /// Gets whether the span is empty.
        /// </summary>
        public bool IsEmpty => this.Length == 0;

        object ITimelineContentItem.Content => this.Content;

        public long Time => this.Start;


        /// <summary>
        /// Creates a new <see cref="TextSpan"/> from <paramref name="start" /> and <paramref
        /// name="end"/> positions as opposed to a position and length.
        /// 
        /// The returned TextSpan contains the range with <paramref name="start"/> inclusive, 
        /// and <paramref name="end"/> exclusive.
        /// </summary>
        public static TimelineContentSpan<T> FromBounds(int start, int end, T item)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), $"{nameof(start)} must not be negative");
            }

            if (end < start)
            {
                throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)} must not be negative");
            }

            return new TimelineContentSpan<T>(start, end - start, item);
        }



        /// <summary>
        /// Provides a string representation for <see cref="TextSpan"/>.
        /// </summary>
        public override string ToString()
        {
            return $"[{Start}..{End})";
        }

        /// <summary>
        /// Compares current instance of <see cref="TextSpan"/> with another.
        /// </summary>
        public int CompareTo(Span other)
        {
            var diff = Start - other.Start;
            if (diff != 0)
            {
                return (int) diff;
            }

            return (int) (Length - other.Length);
        }
    }
}