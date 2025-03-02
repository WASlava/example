using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace example.Controllers
{
    [Route("api/metrics")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private const string _token = "PbpWJili_BiDFOqq1_xxwSciZzWChnYdD_n7qtVyUY29ayJeX13ikh6G4ihAmcd_j3Q4lZLC7bj3xg9cYFEt-g==";
        private const string _bucket = "exampleBucket";
        private const string _org = "exampleOrg";
        private const string _url = "http://influxdb:8086";

        [HttpPost("write")]
        public async Task<IActionResult> WriteMetrics()
        {
            using var client = new InfluxDBClient(_url, _token);
            var writeApi = client.GetWriteApiAsync();

            var point = PointData.Measurement("requests")
                .Tag("host", "backend")
                .Field("count", 1)
                .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

            await writeApi.WritePointAsync(point, _bucket, _org);

            return Ok("Metric sent");
        }
    }
}
