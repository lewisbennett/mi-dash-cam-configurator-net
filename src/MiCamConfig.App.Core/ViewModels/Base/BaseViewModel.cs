using MiCamConfig.App.Core.Services;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core.ViewModels.Base
{
    public partial class BaseViewModel : MvxViewModel
    {
        #region Properties
        /// <summary>
        /// Gets the app's <see cref="ICoreService" />.
        /// </summary>
        public ICoreService CoreService { get; }
        #endregion

        #region Constructors
        public BaseViewModel(ICoreService coreService)
            : base()
        {
            CoreService = coreService;
        }
        #endregion
    }

    public class BaseViewModel<TNavigationParams> : BaseViewModel, IMvxViewModel<TNavigationParams>
        where TNavigationParams : class
    {
        #region Lifecycle
        public virtual void Prepare(TNavigationParams parameter)
        {
        }
        #endregion

        #region Constructors
        public BaseViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }
}
