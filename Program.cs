using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using AAS.Client;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace AjiyaSAP_AAS_CM
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("1. Get IRM ");
                Console.WriteLine("2. Get Production Sheet ");
                Console.WriteLine("3. Approve Production Sheet ");
                Console.Write("Enter choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await IRM();
                        break;
                    case 2:
                        await PS();
                        break;
                    case 3:
                        await ApprovePS();
                        break;
                }
            } while (choice > 3 || choice < 1);
 
        }

        public static async Task IRM()
        {
            int filter;

            dynamic data = new JObject();

            do
            {
                Console.WriteLine("\n1. Coil ID ");
                Console.WriteLine("2. Coil No. ");
                Console.WriteLine("3. Suppier ID ");
                Console.WriteLine("4. Color ");
                Console.WriteLine("5. Thickness ");
                Console.WriteLine("6. Width ");
                Console.WriteLine("7. Length ");
                Console.WriteLine("8. Grade ");
                Console.WriteLine("9. Branch ");
                Console.WriteLine("10. Exit ");
                Console.Write("Filter detail : ");
                filter = Convert.ToInt32(Console.ReadLine());

                switch (filter)
                {
                    case 1:
                        Console.Write("\nEnter Coil ID : ");
                        data.CoilID = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("\nEnter Coil No. : ");
                        data.CoilNo = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("\nEnter Supplier ID : ");
                        data.SupplierID = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("\nEnter Color. : ");
                        data.Color = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("\nEnter Thickness : ");
                        data.Thickness = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("\nEnter Width : ");
                        data.Width = Console.ReadLine();
                        break;
                    case 7:
                        Console.Write("\nEnter Length : ");
                        data.Length = Console.ReadLine();
                        break;
                    case 8:
                        Console.Write("\nEnter Grade : ");
                        data.Grade = Console.ReadLine();
                        break;
                    case 9:
                        Console.Write("\nEnter Branch : ");
                        data.Branch = Console.ReadLine();
                        break;
                }
            } while (filter < 10 && filter > 1);

            var irmDetail = PostIRM(data.ToString());

            var irai = "0990-MY.0043909.0000000028-#TS-00040460.0000000001.0002";

            var aasClient = new AasClient("http://110.238.107.2", "ABCD1234");

            var json = irmDetail.Content;
            var obj = JsonConvert.DeserializeObject<List<IRM>>(json);

            foreach (var irm in obj)
            {
                await aasClient.InstanceApi.AddOrUpdateInstance(irai, irm,irm.id.ToString());
                Console.WriteLine($"Added IRM - {irm.id}");
            }

            Console.WriteLine("DONE");
        }

        public static async Task PS()
        {
            Console.Write("\nEnter creation date (E.g. YYYY-MM-DD) : ");
            string date = Console.ReadLine();

            var data = new
            {
                CreateDate = date,
            };

            var psDetail = PostPS(data);

            var irai = "0990-MY.0043909.0000000028-#TS-00040460.0000000001.0003";

            var aasClient = new AasClient("http://110.238.107.2", "ABCD1234");

            var json = psDetail.Content;
            var obj = JsonConvert.DeserializeObject<List<ProductionSheet>>(json);

            foreach (var productionSheet in obj)
            {
                await aasClient.InstanceApi.AddOrUpdateInstance(irai, productionSheet, productionSheet.id.ToString());
                Console.WriteLine($"Added Production Sheet - {productionSheet.id}");
            }

            Console.WriteLine("DONE");
        }

        public static async Task ApprovePS()
        {
            Console.Write("\nEnter Production No. : ");
            string pNo = Console.ReadLine();

            var data = new
            {
                Production_No = pNo,
            };

            var parameter = "http://www.ftsap.com:82/aas-web-api/api/ProductionSheet/ApprovePS";

            var client = new RestClient(parameter);
            var req = new RestRequest(Method.POST);

            req.AddHeader("Content-Type", "application/json");
            req.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

            client.Execute(req);

            Console.WriteLine("DONE");
        }

        public static IRestResponse PostIRM(object data)
        {
            var parameter = "http://www.ftsap.com:82/aas-web-api/api/IRM/GetIRMList";

            var client = new RestClient(parameter);
            var req = new RestRequest(Method.POST);

            req.AddHeader("Content-Type", "application/json");
            req.AddParameter("application/json", data, ParameterType.RequestBody);

            return client.Execute(req);
        }
        
        public static IRestResponse PostPS(object data)
        {
            var parameter = "http://www.ftsap.com:82/aas-web-api/api/ProductionSheet/GetPSList";

            var client = new RestClient(parameter);
            var req = new RestRequest(Method.POST);

            req.AddHeader("Content-Type", "application/json");
            req.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

            return client.Execute(req);
        }
    }
}
