﻿using System.Collections.Generic;
using FeedEngine.Contracts;
using ServiceBlocks.Common.Serializers;
using ServiceBlocks.Messaging.Common;
using ServiceBlocks.Messaging.NetMq;

namespace FeedEngine.Client
{
    public class QuoteSnapshotClient : NetMqSnapshotClient, ISnapshotClient<IEnumerable<Quote>>
    {
        public QuoteSnapshotClient(string address)
            : base(address)
        {
        }

        public IEnumerable<Quote> GetAndParseSnapshot(string topic)
        {
            return BinarySerializer<IEnumerable<Quote>>.DeSerializeFromByteArray(base.GetSnapshot(topic));
        }
    }
}