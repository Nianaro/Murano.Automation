using System.Configuration;

namespace Framework.Entities
{
    public static class URL
    {
		//этот код ожидает, что у проекта, к которому его подключат, в конфиге будет определённое значение.
	    //это неправильно. Либо этому классу не место в проекте Framework, либо базовый урл надо передавать по-другому
        public static readonly string Host = ConfigurationManager.AppSettings["SiteUrl"];
    }
}