using GraphQL.Types;
using YuSheng.OrchardCore.Form.Validation.Models;

namespace YuSheng.OrchardCore.Form.Validation.GraphQL
{
    public class LabelPartQueryObjectType : ObjectGraphType<LabelPart>
    {
        public LabelPartQueryObjectType()
        {
            Name = "LabelPart";

            Field(x => x.For, nullable: true);
            Field<StringGraphType>("value", resolve: context =>
            {
                return context.Source.ContentItem.DisplayText;
            });
        }
    }
}
