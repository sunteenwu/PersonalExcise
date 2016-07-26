//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace C__ContentDialog;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace concurrency;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

MainPage::MainPage()
{
	InitializeComponent(); 
}
  IAsyncOperation<ContentDialogResult> ^ result;
  

void C__ContentDialog::MainPage::BtnShowContent_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	//MyDialog^ dialog = ref new MyDialog;
	//result = termsOfUseContentDialog->ShowAsync();
	// 
	//txtshow->Text = result->GetResults().ToString();
	
	auto task = create_task(termsOfUseContentDialog->ShowAsync());
 
	task.then(
		[](ContentDialogResult result)
	{		 
		// the user has dismissed the dialog, do something else. 
	   result.ToString();
	});
}


void C__ContentDialog::MainPage::ConfirmAgeCheckBox_Checked(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	
}


void C__ContentDialog::MainPage::ConfirmAgeCheckBox_Unchecked(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{

}


void C__ContentDialog::MainPage::TermsOfUseContentDialog_Opened(Windows::UI::Xaml::Controls::ContentDialog^ sender, Windows::UI::Xaml::Controls::ContentDialogOpenedEventArgs^ args)
{

}


void C__ContentDialog::MainPage::termsOfUseContentDialog_PrimaryButtonClick(Windows::UI::Xaml::Controls::ContentDialog^ sender, Windows::UI::Xaml::Controls::ContentDialogButtonClickEventArgs^ args)
{
	/*txtshow2->Text = result->GetResults().ToString();*/
}


void C__ContentDialog::MainPage::termsOfUseContentDialog_SecondaryButtonClick(Windows::UI::Xaml::Controls::ContentDialog^ sender, Windows::UI::Xaml::Controls::ContentDialogButtonClickEventArgs^ args)
{
	/*txtshow3->Text = result->GetResults().ToString();*/
}
