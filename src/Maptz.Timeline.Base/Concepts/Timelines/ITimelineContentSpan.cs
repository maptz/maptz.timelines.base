namespace Maptz.Timelines
{

    public interface ITimelineContentSpan : ITimelineItem, ITimelineSpan
    {

    }

    public interface ITimelineContentSpan<T> : ITimelineContentItem<T>, ITimelineContentSpan
    {

    }
}