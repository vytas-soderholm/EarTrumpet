﻿using EarTrumpet.UI.ViewModels;
using System.ComponentModel;

namespace EarTrumpet_Actions.ViewModel
{
    public class EarTrumpetActionPageHeaderViewModel : SettingsPageHeaderViewModel
    {
        EarTrumpetActionViewModel _parent;

        public ToolbarItemViewModel[] Toolbar => _parent.Toolbar;
        public string DisplayName { get => _parent.DisplayName; set => _parent.DisplayName = value; }
        public bool IsExpanded { get => _parent.IsExpanded; set => _parent.IsExpanded = value; }

        public EarTrumpetActionPageHeaderViewModel(EarTrumpetActionViewModel parent) : base(parent)
        {
            _parent = parent;
            ((INotifyPropertyChanged)_parent).PropertyChanged += EarTrumpetActionPageHeaderViewModel_PropertyChanged;
        }

        private void EarTrumpetActionPageHeaderViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }
    }
}