﻿#pragma checksum "D:\Customer's\CListeView\CListeView\ListBoxSwipe.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "62CFF72CC88F221BE570DECE82B1062F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CListeView
{
    partial class ListBoxSwipe : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.lblist = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 13 "..\..\..\ListBoxSwipe.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lblist).ManipulationCompleted += this.ActionGrid_ManipulationCompleted;
                    #line 15 "..\..\..\ListBoxSwipe.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lblist).ManipulationStarted += this.ActionGrid_ManipulationStarted;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

