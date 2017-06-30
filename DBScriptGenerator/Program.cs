using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace DBScriptGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dbName = "RealizeDemo300";
            var server = new Server();
            var database = server.Databases[dbName];

            var scripter = new Scripter(server)
            {
                Options =
                {
                    ScriptData = true,
                    ScriptSchema = false
                }
            };

            foreach (Table databaseTable in database.Tables)
            {
                var scriptStringCollection = scripter.EnumScript(new []
                {
                    databaseTable.Urn
                });

                foreach (var str in scriptStringCollection)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
