using System;
using System.Data;
using Blazares.Tooling.DataTableExtensions;
using NUnit.Framework;

namespace Blazares.Tooling.Test.DataTableExtensions
{
    public class ConvertToJsonTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DataTable table = new DataTable();
            table.TableName = "testName";
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Diagnosis", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Step 3: here we add rows.
            table.Rows.Add(25, "Drug A", "Disease A", DateTime.Now);
            table.Rows.Add(50, "Drug Z", "Problem Z", DateTime.Now);
            table.Rows.Add(10, "Drug Q", "Disorder Q", DateTime.Now);
            table.Rows.Add(21, "Medicine A", "Diagnosis A", DateTime.Now);

            var result =table.ToJson();
            
            Assert.Pass();
        }
    }
}