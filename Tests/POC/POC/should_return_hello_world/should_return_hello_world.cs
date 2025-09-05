using System;
using System.Threading.Tasks;
using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.Tests.Mocks.POC;

namespace POC.Tests
{
    [TestClass]
    public class should_return_hello_world
    {
        public TestExecutor TestExecutor;

        [TestInitialize]
        public void Setup()
        {
            this.TestExecutor = new TestExecutor("POC/testSettings.config");
        }

        private async Task<TestWorkflowRun> RunWorkflowAsync()
        {
            var triggerMockOutput = new WhenAnHTTPRequestIsReceivedTriggerOutput();
            var triggerMock = new WhenAnHTTPRequestIsReceivedTriggerMock(outputs: triggerMockOutput);

            var testMock = new TestMockDefinition(triggerMock: triggerMock, actionMocks: null);

            return await this.TestExecutor.Create()
                .RunWorkflowAsync(testMock: testMock)
                .ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Workflow_should_execute_successfully()
        {
            var testRun = await RunWorkflowAsync();

            Assert.IsNotNull(testRun);
            Assert.AreEqual(TestWorkflowStatus.Succeeded, testRun.Status);
        }

        [TestMethod]
        public async Task Workflow_response_body_should_be_Hello_World()
        {
            var testRun = await RunWorkflowAsync();

            Assert.IsTrue(testRun.Actions.ContainsKey("Response"), "Action 'Response' not found.");
            var response = testRun.Actions["Response"];

            Console.WriteLine($"Body: {response.Outputs?["body"]}");

            var body = response.Outputs?["body"]?.ToString();
            Assert.AreEqual("Hello World", body);
        }

    }
}
