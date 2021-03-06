﻿
//------------------------------------------------------------------------------
// FileName = C:\Users\Ross\OneDrive\Documents\GitHubVisualStudio\TscOdfbUtility\o365ApiTester\App.config
// Generated at 01/30/2016 19:34:12
//
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//     
//    NOTE: Please use the Add a Reference to System.Configuration assembly if 
//          you get compile errors with ConfigurationManager
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Configuration;

namespace o365ApiTester
{
    /// <remarks>
    /// You can create partial class with the same name in another file to add custom properties
    /// </remarks>
    public static partial class SiteSettings 
    {
        /// <summary>
        /// Static constructor to initialize properties
        /// </summary>
        static SiteSettings()
        {
            var settings = System.Configuration.ConfigurationManager.AppSettings;
				ClientId =  settings["ClientId"];
				Authority =  settings["Authority"];
				Domain =  settings["Domain"];
				OneDriveApiEndpoint =  settings["OneDriveApiEndpoint"];
				GraphResourceId =  settings["GraphResourceId"];
				GraphApiEndpoint =  settings["GraphApiEndpoint"];
				RedirectUrl =  settings["RedirectUrl"];
        }

		/// <summary>
		/// ClientId configuration value
		/// </summary>
		public static string ClientId 
		{
			get;
		}
		/// <summary>
		/// Authority configuration value
		/// </summary>
		public static string Authority 
		{
			get;
		}
		/// <summary>
		/// Domain configuration value
		/// </summary>
		public static string Domain 
		{
			get;
		}
		/// <summary>
		/// OneDriveApiEndpoint configuration value
		/// </summary>
		public static string OneDriveApiEndpoint 
		{
			get;
		}
		/// <summary>
		/// GraphResourceId configuration value
		/// </summary>
		public static string GraphResourceId 
		{
			get;
		}
		/// <summary>
		/// GraphApiEndpoint configuration value
		/// </summary>
		public static string GraphApiEndpoint 
		{
			get;
		}
		/// <summary>
		/// RedirectUrl configuration value
		/// </summary>
		public static string RedirectUrl 
		{
			get;
		}
  }
}

