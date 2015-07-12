using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GalaSoft.MvvmLight;
using MVVMlight.Shared.Models;

namespace MVVMlight.Shared.ViewModels
{
	public class PhotoViewModel: ViewModelBase
	{
		private List<PhotoModel> m_PhotoModel;

		public List<PhotoModel> PhotoModel {
			get { return m_PhotoModel; }
			set {
				Set (() => PhotoModel, ref m_PhotoModel, value, true);
			}
		}
	}
}
