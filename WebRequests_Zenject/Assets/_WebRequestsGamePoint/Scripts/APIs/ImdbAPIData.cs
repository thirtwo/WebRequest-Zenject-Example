namespace thirtwo.API
{
    public class ImdbImageAPIData
    {
        private const string API_URL = "https://imdb8.p.rapidapi.com/title/get-images?tconst=tt0944947&limit=25";
        private const string API_KEY = "2833056871msh5ab11de5e056817p1d4669jsn134ff1f5943a";
        private const string API_HOST = "imdb8.p.rapidapi.com";
        public string APIUrl => API_URL;

        public string APIKey => API_KEY;

        public string APIHost => API_HOST;
    }

    public class ImdbTextAPIData
    {
        private const string API_URL = "https://imdb8.p.rapidapi.com/auto-complete?q=game%20of%20thr";
        private const string API_KEY = "2833056871msh5ab11de5e056817p1d4669jsn134ff1f5943a";
        private const string API_HOST = "imdb8.p.rapidapi.com";
        public string APIUrl => API_URL;

        public string APIKey => API_KEY;

        public string APIHost => API_HOST;
    }
}