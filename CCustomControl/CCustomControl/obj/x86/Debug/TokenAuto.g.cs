﻿#pragma checksum "D:\Customer's\CCustomControl\CCustomControl\TokenAuto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A1CFCAD40A2F245C1D96E9725041A136"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCustomControl
{
    partial class TokenAuto : 
        global::Windows.UI.Xaml.Controls.UserControl, 
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
                    this.wrapper = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.Control1 = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    #line 14 "..\..\..\TokenAuto.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.Control1).TextChanged += this.AutoSuggestBox_TextChanged;
                    #line 14 "..\..\..\TokenAuto.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.Control1).SuggestionChosen += this.AutoSuggestBox_SuggestionChosen;
                    #line default
                }
                break;
            case 3:
                {
                    this.SuggestionOutput = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.Richtext = (global::Windows.UI.Xaml.Controls.RichEditBox)(target);
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

