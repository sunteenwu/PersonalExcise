﻿//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------
#include "pch.h"

#if defined _DEBUG && !defined DISABLE_XAML_GENERATED_BINDING_DEBUG_OUTPUT
extern "C" __declspec(dllimport) int __stdcall IsDebuggerPresent();
#endif

#include "MainPage.xaml.h"

void ::C__ContentDialog::MainPage::InitializeComponent()
{
    if (_contentLoaded)
    {
        return;
    }
    _contentLoaded = true;
    ::Windows::Foundation::Uri^ resourceLocator = ref new ::Windows::Foundation::Uri(L"ms-appx:///MainPage.xaml");
    ::Windows::UI::Xaml::Application::LoadComponent(this, resourceLocator, ::Windows::UI::Xaml::Controls::Primitives::ComponentResourceLocation::Application);
}

void ::C__ContentDialog::MainPage::Connect(int __connectionId, ::Platform::Object^ __target)
{
    switch (__connectionId)
    {
        case 1:
            {
                this->termsOfUseContentDialog = safe_cast<::Windows::UI::Xaml::Controls::ContentDialog^>(__target);
                (safe_cast<::Windows::UI::Xaml::Controls::ContentDialog^>(this->termsOfUseContentDialog))->PrimaryButtonClick += ref new ::Windows::Foundation::TypedEventHandler<::Windows::UI::Xaml::Controls::ContentDialog^, ::Windows::UI::Xaml::Controls::ContentDialogButtonClickEventArgs^>(this, (void (::C__ContentDialog::MainPage::*)
                    (::Windows::UI::Xaml::Controls::ContentDialog^, ::Windows::UI::Xaml::Controls::ContentDialogButtonClickEventArgs^))&MainPage::termsOfUseContentDialog_PrimaryButtonClick);
                (safe_cast<::Windows::UI::Xaml::Controls::ContentDialog^>(this->termsOfUseContentDialog))->SecondaryButtonClick += ref new ::Windows::Foundation::TypedEventHandler<::Windows::UI::Xaml::Controls::ContentDialog^, ::Windows::UI::Xaml::Controls::ContentDialogButtonClickEventArgs^>(this, (void (::C__ContentDialog::MainPage::*)
                    (::Windows::UI::Xaml::Controls::ContentDialog^, ::Windows::UI::Xaml::Controls::ContentDialogButtonClickEventArgs^))&MainPage::termsOfUseContentDialog_SecondaryButtonClick);
            }
            break;
        case 2:
            {
                this->BtnShowContent = safe_cast<::Windows::UI::Xaml::Controls::Button^>(__target);
                (safe_cast<::Windows::UI::Xaml::Controls::Button^>(this->BtnShowContent))->Click += ref new ::Windows::UI::Xaml::RoutedEventHandler(this, (void (::C__ContentDialog::MainPage::*)
                    (::Platform::Object^, ::Windows::UI::Xaml::RoutedEventArgs^))&MainPage::BtnShowContent_Click);
            }
            break;
        case 3:
            {
                this->txtshow = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(__target);
            }
            break;
        case 4:
            {
                this->txtshow2 = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(__target);
            }
            break;
        case 5:
            {
                this->txtshow3 = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(__target);
            }
            break;
        case 6:
            {
                this->ConfirmAgeCheckBox = safe_cast<::Windows::UI::Xaml::Controls::CheckBox^>(__target);
                (safe_cast<::Windows::UI::Xaml::Controls::CheckBox^>(this->ConfirmAgeCheckBox))->Checked += ref new ::Windows::UI::Xaml::RoutedEventHandler(this, (void (::C__ContentDialog::MainPage::*)
                    (::Platform::Object^, ::Windows::UI::Xaml::RoutedEventArgs^))&MainPage::ConfirmAgeCheckBox_Checked);
                (safe_cast<::Windows::UI::Xaml::Controls::CheckBox^>(this->ConfirmAgeCheckBox))->Unchecked += ref new ::Windows::UI::Xaml::RoutedEventHandler(this, (void (::C__ContentDialog::MainPage::*)
                    (::Platform::Object^, ::Windows::UI::Xaml::RoutedEventArgs^))&MainPage::ConfirmAgeCheckBox_Unchecked);
            }
            break;
    }
    _contentLoaded = true;
}

::Windows::UI::Xaml::Markup::IComponentConnector^ ::C__ContentDialog::MainPage::GetBindingConnector(int __connectionId, ::Platform::Object^ __target)
{
    __connectionId;         // unreferenced
    __target;               // unreferenced
    return nullptr;
}

