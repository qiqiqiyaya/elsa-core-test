using Elsa.Http;
using Elsa.Workflows;
using Elsa.Workflows.Activities;

namespace ElsaServer.Workflows;

public class Test : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        builder.Root = new Sequence
        {
            Activities =
            {
                new WriteLine("Line 1"),
                new WriteLine("Line 2"),
                new WriteLine("Line 3")
            }
        };
    }
}
