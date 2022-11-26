using System.Reflection;
using Xunit.Sdk;

namespace B3.Test.Config
{
    public class CsvTestDataAttribute : DataAttribute
    {
        private readonly string _csvFileName;

        public CsvTestDataAttribute(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string[] csvLines = File.ReadAllLines($"./{_csvFileName}");

            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<string> values = csvLine.Split(';').Select(t => t).AsEnumerable();
                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);
            }

            return testCases;
        }

    }
}
