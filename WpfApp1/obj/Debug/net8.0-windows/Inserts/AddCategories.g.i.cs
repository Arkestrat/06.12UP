﻿#pragma checksum "..\..\..\..\Inserts\AddCategories.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AA4DA4D5E2C8A41E97A0C8BA63CFCE986FCA9AFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp1.Inserts;


namespace WpfApp1.Inserts {
    
    
    /// <summary>
    /// AddCategories
    /// </summary>
    public partial class AddCategories : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Inserts\AddCategories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoToTheMainWindow;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Inserts\AddCategories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtCategories;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Inserts\AddCategories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtDescription;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Inserts\AddCategories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveCategory;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/inserts/addcategories.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Inserts\AddCategories.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnGoToTheMainWindow = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Inserts\AddCategories.xaml"
            this.btnGoToTheMainWindow.Click += new System.Windows.RoutedEventHandler(this.btnGoToTheMainWindow_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxtCategories = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\Inserts\AddCategories.xaml"
            this.TxtCategories.SelectionChanged += new System.Windows.RoutedEventHandler(this.TxtCategories_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TxtDescription = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\Inserts\AddCategories.xaml"
            this.TxtDescription.SelectionChanged += new System.Windows.RoutedEventHandler(this.TxtDescription_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SaveCategory = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Inserts\AddCategories.xaml"
            this.SaveCategory.Click += new System.Windows.RoutedEventHandler(this.SaveCategory_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

