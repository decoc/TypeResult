
namespace TypeResult
{
    public class Error
    {
        public string Reason => reason;

        protected internal string reason;
        
        public Error(string reason = "")
        {
            this.reason = Reason;
        }
    }
}