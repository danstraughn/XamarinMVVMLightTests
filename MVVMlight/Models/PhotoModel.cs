using System;
using Newtonsoft.Json;

namespace MVVMlight.Shared.Models
{
	public class PhotoModel
	{
		private int _albumId;
		private int _id;
		private string _title;
		private string _url = String.Empty;
		private string _thumbnailUrl = String.Empty;

		[JsonProperty (PropertyName = "albumId")]
		public int albumId {
			get { return _albumId; }
			set { _albumId = value; }
		}

		[JsonProperty (PropertyName = "id")]
		public int id {
			get { return _id; }
			set { _id = value; }
		}

		[JsonProperty (PropertyName = "title")]
		public string title {
			get { return _title; }
			set { _title = value; }
		}

		[JsonProperty (PropertyName = "url")]
		public string url {
			get { return _url; }
			set { _url = value; }
		}

		[JsonProperty (PropertyName = "thumbnailUrl")]
		public string thumbnailUrl {
			get { return _thumbnailUrl; }
			set { _thumbnailUrl = value; }
		}

	}
}

