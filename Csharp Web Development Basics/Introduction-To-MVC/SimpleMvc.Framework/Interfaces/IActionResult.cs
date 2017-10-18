namespace SimpleMvc.Framework.Interfaces
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}