

namespace PowerpointAccessories.Issues
{
    public interface IIssue
    {
        string Description { get; set; }
        bool IsFixable { get; set; }
        bool IsFixed { get; set; }
    }
}
