using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace POC.Tests.Mocks.POC
{
    /// <summary>
    /// The <see cref="WhenAnHTTPRequestIsReceivedTriggerMock"/> class.
    /// </summary>
    public class WhenAnHTTPRequestIsReceivedTriggerMock : TriggerMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="WhenAnHTTPRequestIsReceivedTriggerMock"/> with static outputs.
        /// </summary>
        public WhenAnHTTPRequestIsReceivedTriggerMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, WhenAnHTTPRequestIsReceivedTriggerOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new WhenAnHTTPRequestIsReceivedTriggerOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="WhenAnHTTPRequestIsReceivedTriggerMock"/> with static error info.
        /// </summary>
        public WhenAnHTTPRequestIsReceivedTriggerMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="WhenAnHTTPRequestIsReceivedTriggerMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public WhenAnHTTPRequestIsReceivedTriggerMock(Func<TestExecutionContext, WhenAnHTTPRequestIsReceivedTriggerMock> onGetTriggerMock, string name = null)
            : base(onGetTriggerMock: onGetTriggerMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for WhenAnHTTPRequestIsReceivedTriggerOutput representing an object with properties.
    /// </summary>
    public class WhenAnHTTPRequestIsReceivedTriggerOutput : MockOutput
    {
        public HttpStatusCode StatusCode {get; set;}

        public JObject Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhenAnHTTPRequestIsReceivedTriggerOutput"/> class.
        /// </summary>
        public WhenAnHTTPRequestIsReceivedTriggerOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new JObject();
        }

    }

}