using System;
using Newtonsoft.Json;

namespace Cerberus.PortableLibrary 
{
	/// <summary>
	/// Todo Item business object
	/// </summary>
	public class TodoItem 
	{

		// SQLite attributes Not sure if needed for Azure DB
		// [PrimaryKey, AutoIncrement]

        public string ID { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }

		public bool Done { get; set; }  // TODO: add this field to the user-interface
	
	}

}