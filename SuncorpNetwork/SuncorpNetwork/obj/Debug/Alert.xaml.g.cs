//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuncorpNetwork {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class Alert : ContentPage {
        
        private Grid GridContent;
        
        private StackLayout NotificationListSection;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(Alert));
            GridContent = this.FindByName<Grid>("GridContent");
            NotificationListSection = this.FindByName<StackLayout>("NotificationListSection");
        }
    }
}
