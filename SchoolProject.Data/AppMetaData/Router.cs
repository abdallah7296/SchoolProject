namespace SchoolProject.Data.AppMetaData
{
    public class Router
    {
        public const string SingleRoute = "/{id}";
        public const string Url = "APi";
        public static class StudentRoute
        {
            public const string prefix = Url + "/Student";
            public const string List = prefix + "/List";
            public const string GetById = prefix + SingleRoute;
            public const string Create = prefix + "/Create";
            public const string Edit = prefix + "/Edit";
            public const string Delete = prefix + "/Delete" + SingleRoute;
            public const string Paginated = prefix + "/Paginated";

        }
        public static class DepartmentRoute
        {
            public const string prefix = Url + "/Department";
            public const string GetById = prefix + "/id";
        }
    }
}