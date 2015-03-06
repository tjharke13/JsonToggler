using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToggler.Tests
{
    public static class TestFilterData
    {
        public static DataSet GetFullGuidList()
        {
            var dataSet = new DataSet();

            var dataTable = new DataTable();

            DataColumnCollection collection = dataTable.Columns;
            DataColumn col = collection.Add("Id", typeof(Guid));
            col = collection.Add("Description", typeof(String));

            dataSet.Tables.Add(dataTable);

            dataSet.Tables[0].Rows.Add("00000000-0000-0000-0000-000000000001", "Item 1");
            dataSet.Tables[0].Rows.Add("00000000-0000-0000-0000-000000000002", "Item 2");
            dataSet.Tables[0].Rows.Add("00000000-0000-0000-0000-000000000003", "Item 3");
            dataSet.Tables[0].Rows.Add("00000000-0000-0000-0000-000000000004", "Item 4");
            dataSet.Tables[0].Rows.Add("00000000-0000-0000-0000-000000000005", "Item 5");

            return dataSet;
        }

        public static DataSet GetFullLongList()
        {
            var dataSet = new DataSet();

            var dataTable = new DataTable();

            DataColumnCollection collection = dataTable.Columns;
            DataColumn col = collection.Add("Id", typeof(long));
            col = collection.Add("Description", typeof(String));

            dataSet.Tables.Add(dataTable);

            dataSet.Tables[0].Rows.Add("1234", "Item 1");
            dataSet.Tables[0].Rows.Add("12345", "Item 2");
            dataSet.Tables[0].Rows.Add("123456", "Item 3");
            dataSet.Tables[0].Rows.Add("1234567", "Item 4");
            dataSet.Tables[0].Rows.Add("12345678", "Item 5");

            return dataSet;
        }

        public static IEnumerable<TestGuidObject> GetGuidObjects()
        {
            var result = new List<TestGuidObject>();

            result.Add(new TestGuidObject() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Value = "First Value" });
            result.Add(new TestGuidObject() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Value = "Second Value" });
            result.Add(new TestGuidObject() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Value = "Third Value" });
            result.Add(new TestGuidObject() { Id = new Guid("00000000-0000-0000-0000-000000000004"), Value = "Fourth Value" });
            result.Add(new TestGuidObject() { Id = new Guid("00000000-0000-0000-0000-000000000005"), Value = "Fifth Value" });

            return result;
        }

        public class TestGuidObject
        {
            public Guid Id { get; set; }
            public string Value { get; set; }
        }

        public class TestLongObject
        {
            public Guid Id { get; set; }
            public string Value { get; set; }
        }
    }
}
