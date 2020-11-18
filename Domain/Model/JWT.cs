namespace Domain.Model
{
    public class JWT
    {
        private static JWT _instance;

        public string Secret { get; set; }

        public static JWT GetInstance()
        {
            if(_instance == null)
            {
                _instance = new JWT();
            }

            return _instance;
        }
    }
}
