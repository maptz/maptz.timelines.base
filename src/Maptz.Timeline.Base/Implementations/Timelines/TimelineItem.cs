using Maptz.Spans;
using System;
namespace Maptz.Timelines
{
    public class TimelineItem<T> : ITimelineContentItem<T>
    {
        public TimelineItem(long time, T item)
        {
            if (time < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(time));
            }

            this.Time = time;
            this.Content = item;
        }


        /// <summary>
        /// Gets the start of the span.
        /// </summary>
        public long Time { get; }

        public T Content { get; }

        object ITimelineContentItem.Content => this.Content;


        /// <summary>
        /// Determines if two instances of <see cref="TextSpan"/> are the same.
        /// </summary>
        public static bool operator ==(TimelineItem<T> left, TimelineItem<T> right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines if two instances of <see cref="TextSpan"/> are different.
        /// </summary>
        public static bool operator !=(TimelineItem<T> left, TimelineItem<T> right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines if current instance of <see cref="TextSpan"/> is equal to another.
        /// </summary>
        public bool Equals(TimelineItem<T> other)
        {
            return Time == other.Time;
        }

        /// <summary>
        /// Determines if current instance of <see cref="TextSpan"/> is equal to another.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is TimelineItem<T> && Equals((TimelineItem<T>)obj);
        }

        /// <summary>
        /// Produces a hash code for <see cref="TextSpan"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCodeHelpers.Combine((int)this.Time, this.Content != null ? this.Content.GetHashCode() : 0);
        }



        /// <summary>
        /// Provides a string representation for <see cref="TextSpan"/>.
        /// </summary>
        public override string ToString()
        {
            return $"[{this.Time}])";
        }

        /// <summary>
        /// Compares current instance of <see cref="TextSpan"/> with another.
        /// </summary>
        public int CompareTo(TimelineItem<T> other)
        {
            var diff = this.Time - other.Time;
            return (int)(diff);
        }
    }
}