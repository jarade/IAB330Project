//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuncorpNetwork {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class Home : ContentPage {
        
        private Button TagsBtn;
        
        private Picker SortByPicker;
        
        private StackLayout NewsSection;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(Home));
            TagsBtn = this.FindByName<Button>("TagsBtn");
            SortByPicker = this.FindByName<Picker>("SortByPicker");
            NewsSection = this.FindByName<StackLayout>("NewsSection");
        }
    }
}