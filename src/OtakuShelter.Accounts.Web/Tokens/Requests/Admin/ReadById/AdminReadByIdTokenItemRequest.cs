using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class AdminReadByIdTokenItemRequest
	{
		public AdminReadByIdTokenItemRequest(Token token)
		{
			Id = token.Id;
			IpAddress = token.IpAddress;
			Created = token.Created;
			UserAgent = token.UserAgent;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "ipAddress")]
		public string IpAddress { get; }
		
		[DataMember(Name = "userAgent")]
		public string UserAgent { get; set; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; }
	}
}