using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using YuSheng.OrchardCore.Form.Validation.Models;
using YuSheng.OrchardCore.Form.Validation.ViewModels;

namespace YuSheng.OrchardCore.Form.Validation.Drivers
{
    public class FormPartDisplayDriver : ContentPartDisplayDriver<FormPart>
    {
        public override IDisplayResult Edit(FormPart part)
        {
            return Initialize<FormPartEditViewModel>("FormPart_Fields_Edit", m =>
            {
                m.Action = part.Action;
                m.Method = part.Method;
                m.WorkflowTypeId = part.WorkflowTypeId;
                m.EncType = part.EncType;
                m.EnableAntiForgeryToken = part.EnableAntiForgeryToken;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(FormPart part, IUpdateModel updater)
        {
            var viewModel = new FormPartEditViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                part.Action = viewModel.Action?.Trim();
                part.Method = viewModel.Method;
                part.WorkflowTypeId = viewModel.WorkflowTypeId;
                part.EncType = viewModel.EncType;
                part.EnableAntiForgeryToken = viewModel.EnableAntiForgeryToken;
            }

            return Edit(part);
        }
    }
}
