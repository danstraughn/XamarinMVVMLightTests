using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using MVVMlight.Shared.ViewModels;
using MVVMlight.Shared.Models;

namespace MVVMlight.Shared.Service
{
	public static class JsonService
	{
		private const string _Service = "http://jsonplaceholder.typicode.com/photos?albumId=1";


		public static async Task<List<PhotoModel>> GetPhotos ()
		{

			using (var client = new HttpClient (new NativeMessageHandler ())) {
				client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
				var request = string.Format ("{0}", _Service);
				var result = await client.GetStringAsync (request);

				var returnList = JsonConvert.DeserializeObject<List<PhotoModel>> (result);

				return returnList;
			}
		}

		public static async Task<T> LoadObject<T> (string apiCall)
		{
			// instantiate the HTTP client 
			var ws = new HttpClient (new NativeMessageHandler ());

			// take the API string and create a URI object
			var uriAPICall = new Uri (apiCall);

			//make the asynchronous call to retreieve the API response
			var objString = await ws.GetStringAsync (uriAPICall);

			// deserialize the response
			return (T)DeserializeObject<T> (objString);
		}

        
		public static T DeserializeObject<T> (string objString)
		{
			return (T)JsonConvert.DeserializeObject<T> (objString);
		}
	}
}
