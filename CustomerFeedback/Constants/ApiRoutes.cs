namespace API.CustomerFeedback.Constants
{
    public static class ApiRoutes
    {
        public static class Auth
        {
            private const string Base = "Api/Auth";
            public const string Login = $"{Base}/Login";
        }

        public static class FeedbackType
        {
            private const string Base = "Api/FeedbackType";
            public const string GetAll = $"{Base}";
            public const string GetById = $"{Base}/{{id}}";
            public const string Create = $"{Base}/Create";
        }
    }
}
