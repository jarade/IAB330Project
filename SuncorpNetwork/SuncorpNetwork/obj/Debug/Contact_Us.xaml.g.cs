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
    
    
    public partial class Contact_Us : BaseView {
        
        private StackLayout content;
        
        private Entry emailAddress;
        
        private Picker problemPicker;
        
        private StackLayout subjectSection;
        
        private Switch respondSwitch;
        
        private StackLayout refrerence;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(Contact_Us));
            content = this.FindByName<StackLayout>("content");
            emailAddress = this.FindByName<Entry>("emailAddress");
            problemPicker = this.FindByName<Picker>("problemPicker");
            subjectSection = this.FindByName<StackLayout>("subjectSection");
            respondSwitch = this.FindByName<Switch>("respondSwitch");
            refrerence = this.FindByName<StackLayout>("refrerence");
        }
    }
}
