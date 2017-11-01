using JudgeSystem.App.Models.Contests;
using System.Text;

namespace JudgeSystem.App.Infrastructure
{
    public static class HtmlHelpers
    {
        //public static string ToHtml(this GameListingHomeModel game, bool isAdmin)
        //    => "";

        public static string ToHtml(this ContestListModel model, bool isAdmin, string email)
        {
            var result = new StringBuilder();

            result.Append($@"<tr>
                        <td scope=""row"">{model.ContestName}</td>
                        <td>{model.Submissions}</td>
                        <td>");
            if (isAdmin || model.CreatorEmail == email)
            {
                result.Append($@"<a href=""/contests/edit?id={model.Id}"" class=""btn btn-sm btn-warning"" >Edit</a>
                            <a href= ""/contests/delete?id={model.Id}"" class=""btn btn-sm btn-danger"" >Delete</a>");
            }

            result.AppendLine(@"</td></tr>");

            return result.ToString();
        }

        public static string ToHtml(this ContestSelectModel model, bool first)
        {
            var result = string.Empty;

            if (first)
            {
                result = $@"<option value=""{model.Id}"" selected>{model.ContestName}</option>";
            }
            else
            {
                result = $@"<option value=""{model.Id}"">{model.ContestName}</option>";
            }

            return result;
        }

        public static string ToHtmlSubm(this ContestSelectModel model, bool selected)
        {
            var result = string.Empty;

            if (selected)
            {
                result = $@"<a class=""list-group-item list-group-item-action list-group-item-dark active"" data-toggle=""list"" href=""#"" role= ""tab"" >{model.ContestName}</a>;
";
            }
            else
            {
                result = $@"<a class=""list-group-item list-group-item-action list-group-item-dark"" data-toggle=""list"" href=""#"" role= ""tab"" >{model.ContestName}</a>";
            }

            return result;
        }
    }
}