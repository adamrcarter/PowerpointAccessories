

namespace PowerpointAccessories
{
    public class IssueScannerFactory
    {
        public static IIssueScanner GetIssueScanner(IPowerpoint powerpoint)
        {
            return new IssueScanner(powerpoint);
        }

    }
}
