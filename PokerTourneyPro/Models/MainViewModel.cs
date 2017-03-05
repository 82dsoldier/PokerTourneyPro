using PokerTourneyPro.Common.Base;
using PokerTourneyPro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace PokerTourneyPro.Models {
	public class MainViewModel : NotifyObject, IMainViewModel {
		private DateTime _CurrentBlindTime = DateTime.Now;
		private ICommand _StartTimer;
		private ICommand _PauseTimer;
		private Timer _timer;

		public DateTime CurrentBlindTime
		{
			get { return _CurrentBlindTime; }
			set
			{
				_CurrentBlindTime = value;
				OnPropertyChanged("CurrentBlindTime");
			}
		}

		public ICommand StartTimer
		{
			get {
				if(_StartTimer == null)
					_StartTimer = new RelayCommand(
						param => StartTimerFunc(),
						param => CanStartTimer()
						);
				return _StartTimer;
			}
		}

		public ICommand PauseTimer
		{
			get {
				if(_PauseTimer == null)
					_PauseTimer = new RelayCommand(
						param => PauseTimerFunc(),
						param => CanPauseTimer()
						);
				return _PauseTimer;
			}
		}

		public void StartTimerFunc() {
			_timer.Enabled = true;
		}

		public void PauseTimerFunc() {
			_timer.Enabled = false;
		}

		private bool CanStartTimer() {
			return true;
		}

		private bool CanPauseTimer() {
			return true;
		}

		public MainViewModel() {
			_timer = new Timer {
				AutoReset = true,
				Enabled = false,
				Interval = 1000
			};
			_timer.Elapsed += Timer_Elapsed;
		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
			CurrentBlindTime = CurrentBlindTime - new TimeSpan(0, 0, 1);
		}
	}
}
