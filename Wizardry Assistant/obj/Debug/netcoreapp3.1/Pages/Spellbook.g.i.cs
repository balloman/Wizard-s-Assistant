﻿#pragma checksum "..\..\..\..\Pages\Spellbook.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "216C9ACD2593AD0DC09F828201D544982F8E0C51"
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
using Wizardry_Assistant.Pages;


namespace Wizardry_Assistant.Pages {
    
    
    /// <summary>
    /// Spellbook
    /// </summary>
    public partial class Spellbook : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Pages\Spellbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WizardButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Spellbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SpellListBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\Spellbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox BuffListBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\Spellbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddSpellButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\Spellbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBuffButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wizardry Assistant;component/pages/spellbook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Spellbook.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.WizardButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.SpellListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.BuffListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.AddSpellButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Pages\Spellbook.xaml"
            this.AddSpellButton.Click += new System.Windows.RoutedEventHandler(this.AddSpellButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddBuffButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\Spellbook.xaml"
            this.AddBuffButton.Click += new System.Windows.RoutedEventHandler(this.AddBuffButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

