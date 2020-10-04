using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using EFCoreSamples.Domain;
using EFCoreSamples.Domain.Paging;
using EFCoreSamples.Dtos;
using EFCoreSamples.Infrastructure;
using EFCoreSamples.Infrastructure.ODataMappings;
using EFCoreSamples.Domain.ValueObjects;

namespace EFCoreSamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(ILogger<DeveloperController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }


        [HttpGet]
        public IActionResult Get() => Ok(_databaseContext.Developer);

        // 4.4. Enable Query on this Method
        [HttpGet("odata")]
        public async Task<IActionResult> OData(ODataQueryOptions<DeveloperDto> oDataQuery)
        {
            var edmModel = EdmModelConfig.GetEdmModel();
            var edmEntitySet = edmModel.FindDeclaredEntitySet(nameof(Developer));

            var context = new ODataQueryContext(edmModel, typeof(Developer), oDataQuery.Context.Path);
            var edmType = context.ElementType;

            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(oDataQuery.RawValues.Filter))
                parameters.Add("$filter", oDataQuery.RawValues.Filter);

            if (!string.IsNullOrWhiteSpace(oDataQuery.RawValues.Expand))
                parameters.Add("$expand", oDataQuery.RawValues.Expand);

            if (!string.IsNullOrWhiteSpace(oDataQuery.RawValues.OrderBy))
                parameters.Add("$orderby", oDataQuery.RawValues.OrderBy);

            var parser = new ODataQueryOptionParser(edmModel, edmType, edmEntitySet, parameters);

            var queryable = (IQueryable<Developer>)_databaseContext.Developer;
            if (!string.IsNullOrWhiteSpace(oDataQuery.RawValues.Filter))
            {
                var filter = new FilterQueryOption(oDataQuery.RawValues.Filter, context, parser);
                queryable = (IQueryable<Developer>)filter.ApplyTo(queryable, new ODataQuerySettings());
            }

            if (!string.IsNullOrWhiteSpace(oDataQuery.RawValues.OrderBy))
            {
                var orderBy = new OrderByQueryOption(oDataQuery.RawValues.OrderBy, context, parser);
                queryable = orderBy.ApplyTo(queryable, new ODataQuerySettings());
            }

            IQueryable<object> expandableQueryable = null;
            if (!string.IsNullOrWhiteSpace(oDataQuery.RawValues.Expand))
            {
                var expand = new SelectExpandQueryOption(null, oDataQuery.RawValues.Expand, context, parser);
                expandableQueryable = (IQueryable<object>)expand.ApplyTo(queryable, new ODataQuerySettings());
            }

            int pageIndex = 1;
            var hasPageIndex = oDataQuery.Request.Query.TryGetValue("$pageindex", out StringValues pageIndexRaw);
            if (hasPageIndex)
            {
                var isTrue = int.TryParse(pageIndexRaw, out int _pageIndexRaw);
                pageIndex = (isTrue && _pageIndexRaw > 0) ? _pageIndexRaw : pageIndex;
            }

            int pageSize = 10;
            var hasPageSize = oDataQuery.Request.Query.TryGetValue("$pagesize", out StringValues pageSizeRaw);
            if (hasPageSize)
            {
                var isTrue = int.TryParse(pageSizeRaw, out int _pageSizeRaw);
                pageSize = (isTrue && _pageSizeRaw > 0) ? _pageSizeRaw : pageSize;
            }

            IQueryable<object> queryToExecute = expandableQueryable ?? queryable;
            var records = await queryToExecute.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = await queryToExecute.CountAsync();

            var pageList = new PageList<Developer, DevCode>(MapDomain(records).ToList(), count, pageIndex, pageSize);
            var response = PageListDto<DeveloperDto>.Map(pageList, DeveloperDto.MapDomainToDto);

            return Ok(response);
        }

        static IEnumerable<Developer> MapDomain(IEnumerable<object> objs) => objs.Select(obj =>
        {
            if (obj.GetType().Name == "SelectAllAndExpand`1")
            {
                var entityProperty = obj.GetType().GetProperty("Instance");
                return (Developer)entityProperty.GetValue(obj);
            }
            return (Developer)obj;
        }); // https://www.jauernig-it.de/intercepting-and-post-processing-odata-queries-on-the-server/
    }
}
