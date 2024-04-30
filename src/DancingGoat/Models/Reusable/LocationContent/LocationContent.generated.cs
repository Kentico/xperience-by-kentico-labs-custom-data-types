//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS.ContentEngine;
using DancingGoat;

namespace DancingGoat.Models
{
	/// <summary>
	/// Represents a content item of type <see cref="LocationContent"/>.
	/// </summary>
	[RegisterContentTypeMapping(CONTENT_TYPE_NAME)]
	public partial class LocationContent : IContentItemFieldsSource
	{
		/// <summary>
		/// Code name of the content type.
		/// </summary>
		public const string CONTENT_TYPE_NAME = "DancingGoat.LocationContent";


		/// <summary>
		/// Represents system properties for a content item.
		/// </summary>
		[SystemField]
		public ContentItemFields SystemFields { get; set; }


		/// <summary>
		/// LocationContentTitle.
		/// </summary>
		public string LocationContentTitle { get; set; }


		/// <summary>
		/// LocationContentAddressJSON.
		/// </summary>
		public AddressDataType LocationContentAddressJSON { get; set; }
	}
}