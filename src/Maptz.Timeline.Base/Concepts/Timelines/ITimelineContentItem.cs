namespace Maptz.Timelines
{

    public interface ITimelineContentItem : ITimelineItem
    {

        object Content { get; }
    }

    public interface ITimelineContentItem<T> : ITimelineContentItem
    {
        new T Content { get; }
    }
}