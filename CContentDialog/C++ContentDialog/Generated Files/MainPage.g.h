﻿#pragma once
//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------


namespace Windows {
    namespace UI {
        namespace Xaml {
            namespace Controls {
                ref class ContentDialog;
                ref class Button;
                ref class TextBlock;
                ref class CheckBox;
            }
        }
    }
}

namespace C__ContentDialog
{
    [::Windows::Foundation::Metadata::WebHostHidden]
    partial ref class MainPage : public ::Windows::UI::Xaml::Controls::Page, 
        public ::Windows::UI::Xaml::Markup::IComponentConnector,
        public ::Windows::UI::Xaml::Markup::IComponentConnector2
    {
    public:
        void InitializeComponent();
        virtual void Connect(int connectionId, ::Platform::Object^ target);
        virtual ::Windows::UI::Xaml::Markup::IComponentConnector^ GetBindingConnector(int connectionId, ::Platform::Object^ target);
    
    private:
        bool _contentLoaded;
    
        private: ::Windows::UI::Xaml::Controls::ContentDialog^ termsOfUseContentDialog;
        private: ::Windows::UI::Xaml::Controls::Button^ BtnShowContent;
        private: ::Windows::UI::Xaml::Controls::TextBlock^ txtshow;
        private: ::Windows::UI::Xaml::Controls::TextBlock^ txtshow2;
        private: ::Windows::UI::Xaml::Controls::TextBlock^ txtshow3;
        private: ::Windows::UI::Xaml::Controls::CheckBox^ ConfirmAgeCheckBox;
    };
}
