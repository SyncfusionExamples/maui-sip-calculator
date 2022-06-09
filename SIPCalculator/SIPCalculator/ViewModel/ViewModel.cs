using System.ComponentModel;

namespace SIPCalculator.ViewModel
{
    /// <summary>
    /// View Model class for SIP calculations
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double monthlyInvestment;
        private double timePeriod;
        private double expectedReturnRate;
        public double investedAmount;
        public double totalInvetment;
        public double result;
        double i;

        /// <summary>
        /// Gets or sets a value for the monthly investment.
        /// </summary>
        public double MonthlyInvestment
        {
            get { return monthlyInvestment; }
            set
            {
                if (monthlyInvestment != value)
                {
                    monthlyInvestment = value;
                    InvestSlider_ValueChanged(value);
                    OnPropertyChanged(nameof(MonthlyInvestment));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for the investment time period.
        /// </summary>
        public double TimePeriod
        {
            get { return timePeriod; }
            set
            {
                if (timePeriod != value)
                {
                    timePeriod = value;
                    TimePeroidSlider_ValueChanged(value);
                    OnPropertyChanged(nameof(TimePeriod));
                }

            }
        }
        
        /// <summary>
        /// Gets or sets a value for expected return rate.
        /// </summary>
        public double ExpectedReturnRate
        {
            get { return expectedReturnRate; }
            set
            {
                if (expectedReturnRate != value)
                {
                    expectedReturnRate = value;
                    RateSlider_ValueChanged(value);
                    OnPropertyChanged(nameof(ExpectedReturnRate));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for invested amount.
        /// </summary>
        public double InvestedAmount
        {
            get { return investedAmount; }
            set
            {
                if (investedAmount != value)
                {
                    investedAmount = value;
                    OnPropertyChanged(nameof(InvestedAmount));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for total investment.
        /// </summary>
        public double TotalInvetment
        {
            get { return totalInvetment; }
            set
            {
                if (totalInvetment != value)
                {
                    totalInvetment = value;
                    OnPropertyChanged(nameof(TotalInvetment));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for the propsed return.
        /// </summary>
        public double Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }

            }
        }

        /// <summary>
        /// Update the values when the time period changed.
        /// </summary>
        private void InvestSlider_ValueChanged(double value)
        {
            MonthlyInvestment = value;
            InvestedAmount = MonthlyInvestment * 12 * TimePeriod;
            i = ExpectedReturnRate / (12 * 100);
            Result = MonthlyInvestment * ((Math.Pow(1 + i, TimePeriod * 12) - 1) / i) * (1 + i) - InvestedAmount;
            TotalInvetment = InvestedAmount + Result;
        }

        /// <summary>
        /// Update the values when the expected return rate changed.
        /// </summary>
        private void RateSlider_ValueChanged(double value)
        {
            ExpectedReturnRate = value;
            i = ExpectedReturnRate / (12 * 100);
            Result = MonthlyInvestment * ((Math.Pow(1 + i, TimePeriod * 12) - 1) / i) * (1 + i) - InvestedAmount;
            TotalInvetment = InvestedAmount + Result;
        }

        /// <summary>
        /// Update the values when the time period changed.
        /// </summary>
        private void TimePeroidSlider_ValueChanged(double value)
        {
            TimePeriod = value;
            InvestedAmount = MonthlyInvestment * 12 * TimePeriod;
            i = expectedReturnRate / (12 * 100);
            Result = MonthlyInvestment * ((Math.Pow(1 + i, TimePeriod * 12) - 1) / i) * (1 + i) - InvestedAmount;
            TotalInvetment = InvestedAmount + Result;
        }

        /// <summary>
        /// Invoke the OnPropertyChanged method.
        /// </summary>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModel()
        {
            monthlyInvestment = 25000;
            timePeriod = 10;
            expectedReturnRate = 12;
            InvestedAmount = MonthlyInvestment * 12 * TimePeriod;
            i = ExpectedReturnRate / (12 * 100);
            Result = MonthlyInvestment * ((Math.Pow(1 + i, TimePeriod * 12) - 1) / i) * (1 + i) - InvestedAmount;
            TotalInvetment = InvestedAmount + Result;
        }
    }
}
