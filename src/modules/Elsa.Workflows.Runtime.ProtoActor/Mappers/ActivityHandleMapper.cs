using Elsa.Extensions;
using Elsa.Workflows.Runtime.ProtoActor.Extensions;
using Elsa.Workflows.Models;
using ProtoActivityHandle = Elsa.Workflows.Runtime.ProtoActor.ProtoBuf.ActivityHandle;

namespace Elsa.Workflows.Runtime.ProtoActor.Mappers;

/// <summary>
/// Maps <see cref="ActivityHandle"/> to <see cref="ProtoActivityHandle"/>.
/// </summary>
public class ActivityHandleMapper
{
    /// <summary>
    /// Maps <see cref="ActivityHandle"/> to <see cref="ProtoActivityHandle"/>.
    /// </summary>
    public ProtoActivityHandle? Map(ActivityHandle? source)
    {
        if (source == null)
            return null;

        return new()
        {
            ActivityId = source.ActivityId.EmptyIfNull(),
            ActivityHash = source.ActivityHash.EmptyIfNull(),
            ActivityInstanceId = source.ActivityInstanceId.EmptyIfNull(),
            ActivityNodeId = source.ActivityNodeId.EmptyIfNull(),
        };
    }

    /// <summary>
    /// Maps <see cref="ProtoActivityHandle"/> to <see cref="ActivityHandle"/>.
    /// </summary>
    public ActivityHandle? Map(ProtoActivityHandle source)
    {
        if (string.IsNullOrEmpty(source.ActivityHash) 
            && string.IsNullOrEmpty(source.ActivityId) 
            && string.IsNullOrEmpty(source.ActivityInstanceId) 
            && string.IsNullOrEmpty(source.ActivityNodeId))
            return null;

        return new ActivityHandle
        {
            ActivityId = source.ActivityId,
            ActivityHash = source.ActivityHash,
            ActivityInstanceId = source.ActivityInstanceId,
            ActivityNodeId = source.ActivityNodeId,
        };
    }
}