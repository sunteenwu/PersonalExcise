#include "pch.h"
#include "Class1.h"

using namespace WindowsRuntimeComponent1;
using namespace Platform;

Class1::Class1()
{
}
//UINT Class1::PMDeviceApiGet(UINT index, UCHAR *p, int size, int n)
//{
//	if (g_hDevice == INVALID_HANDLE_VALUE)
//		return 0;
//
//	int pn = 0;
//	DMDPARAM_T dmdParam = { DEVICEAPI_CONTROL_GET_MASK & index, n };
//
//	DeviceIoControl(g_hDevice, (DWORD)IOCTL_DMD_CONTROL, (VOID *)&dmdParam, sizeof(DMDPARAM_T), (LPVOID)p, size, (LPDWORD)&pn, NULL);
//
//	return pn;
//}
