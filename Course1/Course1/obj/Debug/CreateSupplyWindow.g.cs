#pragma checksum "..\..\CreateSupplyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BBBF044435AFAEDFC0B003213099B4D068A54242"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Course1;
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


namespace Course1 {
    
    
    /// <summary>
    /// CreateSupplyWindow
    /// </summary>
    public partial class CreateSupplyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CreateSupplyData;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn CheckB;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn col1;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BAdd;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CB;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CreateSupplyData2;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn CheckB2;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn QuantityColumn;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBWarehouse;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BCreate;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\CreateSupplyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BUpdate;
        
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
            System.Uri resourceLocater = new System.Uri("/Course1;component/createsupplywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateSupplyWindow.xaml"
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
            this.CreateSupplyData = ((System.Windows.Controls.DataGrid)(target));
            
            #line 22 "..\..\CreateSupplyWindow.xaml"
            this.CreateSupplyData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CreateSupplyData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CheckB = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 3:
            this.col1 = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.BAdd = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\CreateSupplyWindow.xaml"
            this.BAdd.Click += new System.Windows.RoutedEventHandler(this.ButtonAdd);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\CreateSupplyWindow.xaml"
            this.CB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CreateSupplyData2 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 52 "..\..\CreateSupplyWindow.xaml"
            this.CreateSupplyData2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CreateSupplyData2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CheckB2 = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 8:
            this.QuantityColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.CBWarehouse = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.BCreate = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\CreateSupplyWindow.xaml"
            this.BCreate.Click += new System.Windows.RoutedEventHandler(this.ButtonCreate);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\CreateSupplyWindow.xaml"
            this.BUpdate.Click += new System.Windows.RoutedEventHandler(this.ButtonUpdate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

