#pragma once

namespace WindowsRuntimeComponent1
{
    public ref class Class1 sealed
    {
    public:
        Class1();
	public:
		double LogCalc(double input)
		{
			// Use C++ standard library as usual.
			return std::log(input);
		}
	public:
		int PMDeviceApiGet(UINT index, UCHAR *p, int size, int n)
		{
			/*if (g_hDevice == INVALID_HANDLE_VALUE)
				return 0;*/

			int pn = 0;
			//DMDPARAM_T dmdParam = { DEVICEAPI_CONTROL_GET_MASK & index, n };

			//DeviceIoControl(g_hDevice, (DWORD)IOCTL_DMD_CONTROL, (VOID *)&dmdParam, sizeof(DMDPARAM_T), (LPVOID)p, size, (LPDWORD)&pn, NULL);

			return pn;
		}

    };

}
