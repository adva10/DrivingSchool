#pragma checksum "..\..\UpdateTraineeWin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C6EC4D6EBE6CAC892D7EA989ECB4E3ECA0888153"
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
    /// UpdateTraineeWin
    /// </summary>
    public partial class UpdateTraineeWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Street;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox School;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Teacher;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numLessons;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Car;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox GearBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumBuild;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\UpdateTraineeWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox City;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/updatetraineewin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateTraineeWin.xaml"
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
            this.Street = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\UpdateTraineeWin.xaml"
            this.Street.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Street_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.School = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\UpdateTraineeWin.xaml"
            this.School.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.School_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Teacher = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\UpdateTraineeWin.xaml"
            this.Teacher.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Teacher_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.numLessons = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\UpdateTraineeWin.xaml"
            this.numLessons.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.numLessons_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Car = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.GearBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            
            #line 51 "..\..\UpdateTraineeWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NumBuild = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\UpdateTraineeWin.xaml"
            this.NumBuild.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.numBuild_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.City = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\UpdateTraineeWin.xaml"
            this.City.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.City_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

