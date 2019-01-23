using System.Configuration;

namespace Framework.Entities
{
    public static class URL
    {
        public static readonly string Host = ConfigurationManager.AppSettings["SiteUrl"];
    }
}