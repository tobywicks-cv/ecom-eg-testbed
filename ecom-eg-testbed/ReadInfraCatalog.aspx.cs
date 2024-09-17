using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EcomEgTestBed
{
    public partial class ReadInfraCatalog : Page
    {
        protected void btnReadCatalog_Click(object sender, EventArgs e)
        {
            var endPointUri = txtEndPoint.Text;
            var primaryKey = txtReadAccessKey.Text;
            var databaseId = txtDatabaseId.Text;
            var containerId = txtContainerID.Text;

            try
            {
                var result = ReadItemsAsync(endPointUri, primaryKey, databaseId, containerId).ConfigureAwait(false)
                    .GetAwaiter().GetResult();
                txtResult.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            catch (Exception exception)
            {
                txtResult.Text = string.Join(Environment.NewLine, GetExceptionDetails(exception));
            }
        }

        private IEnumerable<string> GetExceptionDetails(Exception ex)
        {
            yield return ex.Message;

            var inner = ex.InnerException;
            while (inner != null)
            {
                yield return inner.Message;
                inner = inner.InnerException;
            }
        }

        public static async Task<IList<dynamic>> ReadItemsAsync(string endPointUri, string primaryKey,
            string databaseId, string containerId)
        {
            var cosmosClient = new CosmosClient(endPointUri, primaryKey);
            var container = cosmosClient.GetContainer(databaseId, containerId);

            var sqlQueryText = "SELECT * FROM c";
            var queryDefinition = new QueryDefinition(sqlQueryText);
            var queryResultSetIterator = container.GetItemQueryIterator<dynamic>(queryDefinition);

            var items = new List<dynamic>();

            while (queryResultSetIterator.HasMoreResults)
            {
                foreach (var item in await queryResultSetIterator.ReadNextAsync().ConfigureAwait((false)))
                {
                    items.Add(item);
                }
            }

            return items;
        }
    }
}