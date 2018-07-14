using Furnies.Application;
using System.Web.Helpers;
using Furnies.Domain;

namespace Furnies.WebUI.Services
{
    public class SystemSettings
    {
        private const string pageSizeKey = "PageSize";

        public int PageSize { get {
                var pageSizeCached = WebCache.Get(pageSizeKey);
                if (pageSizeCached != null && !string.IsNullOrEmpty(pageSizeCached))
                {
                    return int.Parse(pageSizeCached);
                }
                else {
                    using (var confService = new ConfiguracionSistemaAppService(new FurniesContext())) {
                        var pageSize = confService.GetPageSize();
                        WebCache.Set(pageSizeKey, pageSize);
                        return pageSize;
                    }
                }
            }
            set {
                WebCache.Set(pageSizeKey, value);
            }
        }
    }
}