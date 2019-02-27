using Maptz.Spans;
namespace Maptz.Timelines
{

    public interface ITimelineItem
    {
        /// <summary>
        /// Gets the start of the span.
        /// </summary>
        long Time { get; }
    }
}