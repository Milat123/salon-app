#pragma checksum "..\..\..\View\SpisakTermina.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2E97C2B2B62AD3DF72E7C98C012805328489FD80A4909D8CF9B77373FED1F6C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SF52_2015_POP2019.View;
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


namespace SF52_2015_POP2019.View {
    
    
    /// <summary>
    /// SpisakTermina
    /// </summary>
    public partial class SpisakTermina : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 12 "..\..\..\View\SpisakTermina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainWindowGrid;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\SpisakTermina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid terminiDataGrid;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\View\SpisakTermina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ObrisiBtnSpisakTermina;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\View\SpisakTermina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IzmeniBtnSpisakTermina;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\View\SpisakTermina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DodajBtnSpisakTermina;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\View\SpisakTermina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
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
            System.Uri resourceLocater = new System.Uri("/SF52-2015-POP2019;component/view/spisaktermina.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SpisakTermina.xaml"
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
            this.terminiDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.ObrisiBtnSpisakTermina = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\View\SpisakTermina.xaml"
            this.ObrisiBtnSpisakTermina.Click += new System.Windows.RoutedEventHandler(this.ObrisiBtnSpisakTermina_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.IzmeniBtnSpisakTermina = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\View\SpisakTermina.xaml"
            this.IzmeniBtnSpisakTermina.Click += new System.Windows.RoutedEventHandler(this.IzmeniBtnSpisakTermina_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DodajBtnSpisakTermina = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\View\SpisakTermina.xaml"
            this.DodajBtnSpisakTermina.Click += new System.Windows.RoutedEventHandler(this.DodajBtnSpisakTermina_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\View\SpisakTermina.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.Refresh_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 35 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 46 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 57 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 68 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 80 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 91 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 91 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 102 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 102 "..\..\..\View\SpisakTermina.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

