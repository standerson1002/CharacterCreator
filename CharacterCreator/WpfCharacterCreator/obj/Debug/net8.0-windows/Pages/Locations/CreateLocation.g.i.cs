﻿#pragma checksum "..\..\..\..\..\Pages\Locations\CreateLocation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59AD168B3224080608983EF904136D33E5562794"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfCharacterCreator.Pages.Locations;


namespace WpfCharacterCreator.Pages.Locations {
    
    
    /// <summary>
    /// CreateLocation
    /// </summary>
    public partial class CreateLocation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboCountries;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboSubdivisions;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboCities;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textAddress;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textDescription;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateLocation;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfCharacterCreator;V1.0.0.0;component/pages/locations/createlocation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.comboCountries = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
            this.comboCountries.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboCountries_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboSubdivisions = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
            this.comboSubdivisions.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboSubdivisions_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.comboCities = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.textAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnCreateLocation = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
            this.btnCreateLocation.Click += new System.Windows.RoutedEventHandler(this.btnCreateLocation_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\Pages\Locations\CreateLocation.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

