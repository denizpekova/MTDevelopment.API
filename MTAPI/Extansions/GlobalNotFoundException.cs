namespace MTAPI.Extansions
{
    public sealed class GlobalNotFoundException : NotFoundExtansion
    {
        public GlobalNotFoundException(int id) : base($" This {id} id could not found ")
        {
        }

        public GlobalNotFoundException(string key) : base($" This {key} key could not found ")
        {
        }
    }
}
