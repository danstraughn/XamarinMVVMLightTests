using System.Globalization;
using Android.App;
using Android.Runtime;
using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using MVVMlight.Shared;


namespace MVVMlight.Droid
{
	[Application]
	public class MainApp : Application
	{
		private static ViewModelLocator s_ViewModelLocator;

		private static CultureInfo s_CurrentCulture;

		public static ViewModelLocator ViewModelLocator {
			get { return s_ViewModelLocator ?? (s_ViewModelLocator = new ViewModelLocator ()); }
		}

		public MainApp (IntPtr handle, JniHandleOwnership transfer)
			: base (handle, transfer)
		{
			ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;

		}

		private bool ServerCertificateValidationCallback (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
		{
			return true;
		}
	}
}