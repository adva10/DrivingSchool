﻿#pragma checksum "..\..\TraineeInfoWin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F0708789A394032C7CE4BF944D0BE405807F1FD7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// TraineeInfoWin
    /// </summary>
    public partial class TraineeInfoWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\TraineeInfoWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TesterByCar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\TraineeInfoWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Tests;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TraineeInfoWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AverageTest;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/traineeinfowin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TraineeInfoWin.xaml"
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
            this.TesterByCar = ((System.Windows.Controls.ListView)(target));
            
            #line 21 "..\..\TraineeInfoWin.xaml"
            this.TesterByCar.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Tests = ((System.Windows.Controls.ListView)(target));
            
            #line 22 "..\..\TraineeInfoWin.xaml"
            this.Tests.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AverageTest = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
