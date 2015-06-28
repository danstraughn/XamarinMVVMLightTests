using System;
using Android.Widget;
using Android.App;

namespace MVVMlight.Droid
{
	[Activity (Label = "MVVMlight.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public partial class MainActivity
	{

		private EditText m_EditText;
		private TextView m_AutoUpdateText;
		private TextView m_ResultText;

		private EditText TxtNewText {
			get { return m_EditText ?? (m_EditText = FindViewById<EditText> (Resource.Id.editText1)); }
		}

		private TextView LblAutoUpdate {
			get { return m_AutoUpdateText ?? (m_AutoUpdateText = FindViewById<TextView> (Resource.Id.textViewShowAsTyping)); }
		}

		private TextView LblResult {
			get { return m_ResultText ?? (m_ResultText = FindViewById<TextView> (Resource.Id.textViewShowOnEnter)); }
		}
	}
}

