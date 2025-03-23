using Elsa.Http;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Models;
using System.Dynamic;
using Elsa.Expressions.Models;
using Elsa.Extensions;

namespace ElsaServer.Workflows
{
    public class LeaveWorkflow : WorkflowBase
    {
        protected override void Build(IWorkflowBuilder builder)
        {
            var code = builder.WithVariable<string>();
            var routeDataVariable = builder.WithVariable<IDictionary<string, object>>();
            var userVariable = builder.WithVariable<ExpandoObject>();
            var content = builder.WithVariable<ExpandoObject>();

            builder.Root = new Sequence()
            {
                Activities = new List<IActivity>()
                {
                    new HttpEndpoint()
                    {
                        Path = new("leavatest"),
                        SupportedMethods = new Input<ICollection<string>>(new List<string>(){HttpMethods.Post}),
                        CanStartWorkflow = true,
                        ParsedContent = new(content),
                        Result =new Output<HttpRequest>(),
                        RouteData = new(routeDataVariable)
                    },
                    new SetVariable
                    {
                        Variable = code,
                        Value = new Input<object?>(context =>
                        {
                            var aacc= content.Get(context);

                            //var dsfdsf = code.Get(context);
                            //var cc = request;
                            //var aaaa = content.Get(context);
                            var aa = context;
                            //var routeData = routeDataVariable.Get(context)!;
                            //var userId = routeData["userid"].ToString();
                            return true;
                        })
                    },
                    new If(context =>
                    {
                        var obj= content.Get(context);
                        var result= obj!?.GetValue<bool>("IsManager")?? false;
                        return result;
                    })
                    {
                        Then = new WriteHttpResponse()
                        {
                            Content=new Input<object?>(context =>
                            {
                                return content.Get(context);
                            })
                        },
                        Else = new WriteFileHttpResponse()
                        {
                            Content = new ("failed")
                        }
                    }
                }
            };
        }
    }

    public class Leavatest
    {
        public bool IsManager { get; set; }

        public bool EmployeeCode { get; set; }
    }
}
