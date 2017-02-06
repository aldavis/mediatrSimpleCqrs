using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace application.Customers.Get
{
    public class AllCustomersRequest:IRequest<AllCustomersResult>
    {
    }

    public class AllCustomersResult   
    {
        public int TotalCount { get; set; }

        public IList<string> Customers { get; set; }

    }

    public class AllCustomersHandler:IAsyncRequestHandler<AllCustomersRequest,AllCustomersResult>
    {
        public Task<AllCustomersResult> Handle(AllCustomersRequest message)
        {
            IList<string> customerNames;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                customerNames = connection.QueryAsync<string>("Select Name from Customers").Result.ToList();
            }

            var result = new AllCustomersResult
            {
                Customers =  customerNames,
                TotalCount = customerNames.Count
            };

            return Task.FromResult(result);
        }
    }
}
