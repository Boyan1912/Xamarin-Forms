//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace xamtest.Pages {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class ShowItemFromOutside : global::Xamarin.Forms.BasePage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.RelativeLayout layout;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Image image;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button ShowDownFromTop;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button ShowUpFromBottom;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button ShowUpFromLeft;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button ShowUpFromRight;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ScrollView PanelUp;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout PanelUpStack;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ScrollView PanelDown;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout PanelDownStack;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ScrollView PanelLeft;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout PanelLeftContent;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(ShowItemFromOutside));
            layout = this.FindByName<global::Xamarin.Forms.RelativeLayout>("layout");
            image = this.FindByName<global::Xamarin.Forms.Image>("image");
            ShowDownFromTop = this.FindByName<global::Xamarin.Forms.Button>("ShowDownFromTop");
            ShowUpFromBottom = this.FindByName<global::Xamarin.Forms.Button>("ShowUpFromBottom");
            ShowUpFromLeft = this.FindByName<global::Xamarin.Forms.Button>("ShowUpFromLeft");
            ShowUpFromRight = this.FindByName<global::Xamarin.Forms.Button>("ShowUpFromRight");
            PanelUp = this.FindByName<global::Xamarin.Forms.ScrollView>("PanelUp");
            PanelUpStack = this.FindByName<global::Xamarin.Forms.StackLayout>("PanelUpStack");
            PanelDown = this.FindByName<global::Xamarin.Forms.ScrollView>("PanelDown");
            PanelDownStack = this.FindByName<global::Xamarin.Forms.StackLayout>("PanelDownStack");
            PanelLeft = this.FindByName<global::Xamarin.Forms.ScrollView>("PanelLeft");
            PanelLeftContent = this.FindByName<global::Xamarin.Forms.StackLayout>("PanelLeftContent");
        }
    }
}