﻿#pragma checksum "D:\Customer's\CDragAndDrop\CDragAndDrop\BorderDrag.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0004CD16FA56AA3B97A78BC2AB754EB2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDragAndDrop
{
    partial class BorderDrag : 
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
                    this.cnvDrop = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                    #line 11 "..\..\..\BorderDrag.xaml"
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.cnvDrop).DragOver += this.cnvDrop_DragOver;
                    #line 11 "..\..\..\BorderDrag.xaml"
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.cnvDrop).Drop += this.cnvDrop_Drop;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Border element2 = (global::Windows.UI.Xaml.Controls.Border)(target);
                    #line 16 "..\..\..\BorderDrag.xaml"
                    ((global::Windows.UI.Xaml.Controls.Border)element2).DragStarting += this.TextBlock_DragStarting;
                    #line default
                }
                break;
            case 3:
                {
                    this.dragtext = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

