﻿#pragma checksum "..\..\..\View\IzmeniSalon.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0E47A77C16E7B139624E62C633246087C451F8D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SF52_2015.View.Converters;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SF52_2015.View {
    
    
    /// <summary>
    /// IzmeniSalon
    /// </summary>
    public partial class IzmeniSalon : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\IzmeniSalon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainWindowGrid;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\IzmeniSalon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sifraTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\IzmeniSalon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazivTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\IzmeniSalon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox adresaTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\IzmeniSalon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IzmeniBtn;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\IzmeniSalon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OtkaziBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SF52-2015;component/view/izmenisalon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\IzmeniSalon.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainWindowGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.sifraTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.nazivTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.adresaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.IzmeniBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\View\IzmeniSalon.xaml"
            this.IzmeniBtn.Click += new System.Windows.RoutedEventHandler(this.IzmeniBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OtkaziBtn = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\View\IzmeniSalon.xaml"
            this.OtkaziBtn.Click += new System.Windows.RoutedEventHandler(this.OtkaziBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

