using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SOSPets.Extensions
{
    public static class ExtensionViewModelInput
    {
        public static List<string> ExtensionMessage(this ModelStateDictionary model)
        {
            var result = new List<string>();
            foreach (var item in model.Values)
            {
                result.AddRange(item.Errors.Select(x => x.ErrorMessage));
            }
            return result;
        }
    }
}
