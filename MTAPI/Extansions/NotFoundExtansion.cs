namespace MTAPI.Extansions
{
    public abstract class NotFoundExtansion : Exception
    {
        protected NotFoundExtansion(string message) : base(message) {
            
        }
    }
}
