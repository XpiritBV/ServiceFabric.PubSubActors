﻿using System.Threading.Tasks;
using Common.DataContracts;
using PublishingActor.Interfaces;

using ServiceFabric.PubSubActors.PublisherActors;

namespace PublishingActor
{
	/// <remarks>
	/// Each ActorID maps to an instance of this class.
	/// The IPublishingActor interface (in a separate DLL that client code can
	/// reference) defines the operations exposed by PublishingActor objects.
	/// </remarks>
	internal class PublishingActor : StatelessPublisherActor, IPublishingActor
	{
		async Task<string> IPublishingActor.PublishMessageOneAsync()
		{
			ActorEventSource.Current.ActorMessage(this, "Publishing Message");
			await PublishMessageAsync(new PublishedMessageOne {Content = "Hello PubSub World!"});
			return "Message published";
		}
	}
}
