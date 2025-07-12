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
            public const string Edit = $"{Base}/Edit";
            public const string Delete = $"{Base}/Delete/{{id}}";
            public const string GetRatings = $"{Base}/GetRatings/{{id}}";
        }

        public static class Public
        {
            private const string Base = "Api/Public";
            public const string GetFeedbackType = $"{Base}/GetFeedbackType/{{id}}";
            public const string CreateFeedback = $"{Base}/CreateFeedback";
        }

        public static class Statistics
        {
            private const string Base = "Api/Statistics";
            public const string Get = $"{Base}/Get";
        }
    }
}
