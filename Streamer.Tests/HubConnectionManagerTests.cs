using NUnit.Framework;
using Streamer.Interfaces;
using Streamer.Services;

namespace Streamer.Tests
{
    public class HubConnectionManagerTests
    {
        private IHubConnectionManager _hubManager;
        private string _testStreamId = "testStreamId";
        private string _testConnectionId = "testConnectionId";

        [SetUp]
        public void Setup()
        {
            _hubManager = new HubConnectionManager();
            _hubManager.AddConnection(_testStreamId, _testConnectionId);
        }

        [Test]
        public void AddConnection()
        {
            var streamId = "streamId";
            var connectionId = "connectionId";
            _hubManager.AddConnection(streamId, connectionId);
            var savedConnectionId = _hubManager.GetConnection(streamId);
            Assert.AreEqual(connectionId, savedConnectionId);
        }

        [Test]
        public void RemoveConnection()
        {
            _hubManager.RemoveConnection(_testStreamId);
            var connectionId = _hubManager.GetConnection(_testStreamId);
            Assert.IsNull(connectionId);
        }

        [Test]
        public void AddConnectionWithSameId()
        {
            var streamId = _testConnectionId;
            var connectionId = "connectionId";
            _hubManager.AddConnection(streamId, connectionId);
            var savedConnectionId = _hubManager.GetConnection(streamId);
            Assert.AreEqual(connectionId, savedConnectionId);
        }

        [TearDown]
        public void TearDown()
        {
            _hubManager = null;
        }
    }
}