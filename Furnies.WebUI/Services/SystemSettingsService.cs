using Furnies.Application;
using System.Web.Helpers;
using Furnies.Domain;
using System.Web;

namespace Furnies.WebUI.Services
{
    public class SystemSettingsService
    {
        private const string pageSizeKey = "PageSize";
        private const string systemNameKey = "SystemName";
        private const string welcomeMessageKey = "WelcomeMessage";

        public static int PageSize { get {
                string pageSizeCached = HttpRuntime.Cache[pageSizeKey] as string;
                
                if (pageSizeCached != null && !string.IsNullOrEmpty(pageSizeCached))
                {
                    return int.Parse(pageSizeCached);
                }
                else {
                    using (var confService = new ConfiguracionSistemaAppService(new FurniesContext())) {
                        var pageSize = confService.GetPageSize();
                        HttpRuntime.Cache[pageSizeKey] = pageSize;
                        return pageSize;
                    }
                }
            }
            set {
                HttpRuntime.Cache[pageSizeKey] = value;
            }
        }

        public static string SystemName
        {
            get
            {
                string systemNameCached = HttpRuntime.Cache[systemNameKey] as string;

                if (systemNameCached != null && !string.IsNullOrEmpty(systemNameCached))
                {
                    return systemNameCached;
                }
                else
                {
                    using (var confService = new ConfiguracionSistemaAppService(new FurniesContext()))
                    {
                        var value = confService.GetNombreSistema();
                        HttpRuntime.Cache[systemNameKey] = value;
                        return value;
                    }
                }
            }
            set
            {
                HttpRuntime.Cache[systemNameKey] = value;
            }
        }

        public static string WelcomeMessage
        {
            get
            {
                string welcomeMessageCached = HttpRuntime.Cache[welcomeMessageKey] as string;

                if (welcomeMessageCached != null && !string.IsNullOrEmpty(welcomeMessageCached))
                {
                    return welcomeMessageCached;
                }
                else
                {
                    using (var confService = new ConfiguracionSistemaAppService(new FurniesContext()))
                    {
                        var value = confService.GetWelcomeMessage();
                        HttpRuntime.Cache[welcomeMessageKey] = value;
                        return value;
                    }
                }
            }
            set
            {
                HttpRuntime.Cache[welcomeMessageKey] = value;
            }
        }

        public static void UpdateValyeByKeyInCache(string key, string value) {
            HttpRuntime.Cache[key] = value;
        }
    }
}