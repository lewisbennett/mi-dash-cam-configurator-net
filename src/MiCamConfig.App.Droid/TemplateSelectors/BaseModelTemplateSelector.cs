using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Models.Base;
using MvvmCross.DroidX.RecyclerView.ItemTemplates;
using System;
using System.Collections.Generic;

namespace MiCamConfig.App.Droid.TemplateSelectors
{
    public class BaseModelTemplateSelector : MvxTemplateSelector<BaseModel>
    {
        #region Public Methods
        public override int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        protected override int SelectItemViewType(BaseModel forItemObject)
        {
            return Layouts[forItemObject.GetType()];
        }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets the dictionary for model layouts.
        /// </summary>
        public static Dictionary<Type, int> Layouts { get; } = new Dictionary<Type, int>
        {
            { typeof(ActionModel), Resource.Layout.item_action }
        };
        #endregion
    }
}