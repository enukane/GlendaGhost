﻿#pragma checksum "..\..\GlendaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AEFAFB4F2B263424D236C9A4FF5D485F"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:2.0.50727.3082
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace GlendaGhost {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.Canvas main_canvas;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.MenuItem MenuItem1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.MenuItem MenuItem2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.MenuItem MenuItem3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.MenuItem MenuItem4;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.MenuItem ExitMenuItem;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.Canvas speechBalloon;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\GlendaWindow.xaml"
        internal System.Windows.Shapes.Ellipse ellipse1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\GlendaWindow.xaml"
        internal System.Windows.Shapes.Ellipse ellipse2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\GlendaWindow.xaml"
        internal System.Windows.Shapes.Ellipse ellipse3;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\GlendaWindow.xaml"
        internal System.Windows.Shapes.Ellipse ellipse4;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\GlendaWindow.xaml"
        internal System.Windows.Controls.Label glendaText;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GlendaGhost;component/glendawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GlendaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\GlendaWindow.xaml"
            ((GlendaGhost.Window1)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.main_canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.MenuItem1 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\GlendaWindow.xaml"
            this.MenuItem1.Click += new System.Windows.RoutedEventHandler(this.MenuItem1_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MenuItem2 = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 6:
            this.MenuItem3 = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 7:
            this.MenuItem4 = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 8:
            this.ExitMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\GlendaWindow.xaml"
            this.ExitMenuItem.Click += new System.Windows.RoutedEventHandler(this.ExitMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.speechBalloon = ((System.Windows.Controls.Canvas)(target));
            return;
            case 10:
            this.ellipse1 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 11:
            this.ellipse2 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 12:
            this.ellipse3 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 13:
            this.ellipse4 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 14:
            this.glendaText = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
