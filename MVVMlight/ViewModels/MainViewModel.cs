using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMlight.Shared.Service;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;


namespace MVVMlight.Shared.ViewModels
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel ()
		{
			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}
		}

		private string m_BindableText;

		public string BindableText {
			get { return m_BindableText; }
			set {
				Set (() => BindableText, ref m_BindableText, value, true);
			}
		}

		public const string LastLoadedPropertyName = "LastLoaded";


		private readonly INavigationService _navigationService;
		private bool _isLoading;
		private DateTime _lastLoaded = DateTime.MinValue;
		private RelayCommand _refreshCommand;
		private RelayCommand<PhotoViewModel> _showDetailsCommand;

		public ObservableCollection<PhotoViewModel> Photos {
			get;
			private set;
		}

		public DateTime LastLoaded {
			get {
				return _lastLoaded;
			}
			set {
				if (Set (() => LastLoaded, ref _lastLoaded, value)) {
					RaisePropertyChanged (() => LastLoadedFormatted);
				}
			}
		}

		public string LastLoadedFormatted {
			get {
				return _isLoading
					? "Loading..."
						: "Last loaded: " + (LastLoaded == DateTime.MinValue ? "Never" : LastLoaded.ToString ());
			}
		}

		//		public RelayCommand RefreshCommand {
		//			get {
		//				return _refreshCommand
		//				?? (_refreshCommand = new RelayCommand (
		//					async () => {
		//						Photos.Clear ();
		//
		//						_isLoading = true;
		//						RaisePropertyChanged (() => LastLoadedFormatted);
		//
		//						try {
		//							var list = await _jsonService.Refresh ();
		//
		//							foreach (var flower in list) {
		//								Photos.Add (new FlowerViewModel (_flowersService, flower));
		//							}
		//
		//							_isLoading = false;
		//							LastLoaded = DateTime.Now;
		//						} catch (Exception ex) {
		//							var dialog = ServiceLocator.Current.GetInstance<IDialogService> ();
		//							dialog.ShowError (ex, "Error when refreshing", "OK", null);
		//						}
		//
		//						_isLoading = false;
		//						RaisePropertyChanged (() => LastLoadedFormatted);
		//					}));
		//			}
		//		}
		//
		//		public RelayCommand<FlowerViewModel> ShowDetailsCommand {
		//			get {
		//				return _showDetailsCommand
		//				?? (_showDetailsCommand = new RelayCommand<FlowerViewModel> (
		//					flower => {
		//						if (!ShowDetailsCommand.CanExecute (flower)) {
		//							return;
		//						}
		//
		//						_navigationService.NavigateTo (ViewModelLocator.DetailsPageKey, flower);
		//					},
		//					flower => flower != null));
		//			}
		//		}
		//
		//		public MainViewModel (
		//			IFlowersService flowersService,
		//			INavigationService navigationService)
		//		{
		//			_flowersService = flowersService;
		//			_navigationService = navigationService;
		//			Photos = new ObservableCollection<FlowerViewModel> ();
		//
		//			#if DEBUG
		//			if (IsInDesignMode) {
		//				RefreshCommand.Execute (null);
		//			}
		//			#endif
		//		}
	}
}

