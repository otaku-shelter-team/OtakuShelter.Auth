using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class AdminDeleteByIdTokenRequest
	{
		[DataMember(Name = "tokenId")]
		public int TokenId { get; set; }

		public async ValueTask  Delete(AccountsContext context)
		{
			var token = await context.Tokens.FirstAsync(t => t.Id == TokenId);
			
			context.Tokens.Remove(token);
		}
	}
}