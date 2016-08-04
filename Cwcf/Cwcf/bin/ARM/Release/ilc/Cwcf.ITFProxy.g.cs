using Mcg.System;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;



namespace __InterfaceProxies
{
	public class ServiceChannelProxy_IService1 : global::System.ServiceModel.Channels.ServiceChannelProxy_P, global::Cwcf.ToDoService.IService1_P
	{
		global::System.Threading.Tasks.Task_P<string> global::Cwcf.ToDoService.IService1_P.GetDataAsync(int value)
		{
			global::System.RuntimeMethodHandle interfaceMethod = global::System.Reflection.DispatchProxyHelpers.GetCorrespondingInterfaceMethodFromMethodImpl();
			global::System.RuntimeTypeHandle interfaceType = typeof(global::Cwcf.ToDoService.IService1_P).TypeHandle;
			global::System.Reflection.MethodBase targetMethodInfo = global::System.Reflection.MethodBase.GetMethodFromHandle(
								interfaceMethod, 
								interfaceType
							);
			object[] callsiteArgs = new object[] {
					value
			};
			global::System.Threading.Tasks.Task_P<string> retval = ((global::System.Threading.Tasks.Task_P<string>)base.Invoke(
								((global::System.Reflection.MethodInfo)targetMethodInfo), 
								callsiteArgs
							));
			return retval;
		}

		global::System.Threading.Tasks.Task_P<global::Cwcf.ToDoService.CompositeType_P> global::Cwcf.ToDoService.IService1_P.GetDataUsingDataContractAsync(global::Cwcf.ToDoService.CompositeType_P composite)
		{
			global::System.RuntimeMethodHandle interfaceMethod = global::System.Reflection.DispatchProxyHelpers.GetCorrespondingInterfaceMethodFromMethodImpl();
			global::System.RuntimeTypeHandle interfaceType = typeof(global::Cwcf.ToDoService.IService1_P).TypeHandle;
			global::System.Reflection.MethodBase targetMethodInfo = global::System.Reflection.MethodBase.GetMethodFromHandle(
								interfaceMethod, 
								interfaceType
							);
			object[] callsiteArgs = new object[] {
					composite
			};
			global::System.Threading.Tasks.Task_P<global::Cwcf.ToDoService.CompositeType_P> retval = ((global::System.Threading.Tasks.Task_P<global::Cwcf.ToDoService.CompositeType_P>)base.Invoke(
								((global::System.Reflection.MethodInfo)targetMethodInfo), 
								callsiteArgs
							));
			return retval;
		}
	}

	[global::System.Runtime.CompilerServices.EagerStaticClassConstruction]
	[global::System.Runtime.CompilerServices.DependencyReductionRoot]
	public static class __DispatchProxyImplementationData
	{
		static global::System.Reflection.DispatchProxyEntry[] s_entryTable = new global::System.Reflection.DispatchProxyEntry[] {
				new global::System.Reflection.DispatchProxyEntry() {
					ProxyClassType = typeof(global::System.ServiceModel.Channels.ServiceChannelProxy_P).TypeHandle,
					InterfaceType = typeof(global::Cwcf.ToDoService.IService1_P).TypeHandle,
					ImplementationClassType = typeof(global::__InterfaceProxies.ServiceChannelProxy_IService1).TypeHandle,
				}
		};
		static __DispatchProxyImplementationData()
		{
			global::System.Reflection.DispatchProxyHelpers.RegisterImplementations(s_entryTable);
		}
	}
}

namespace Cwcf.ToDoService
{
	[global::System.Runtime.InteropServices.McgRedirectedType("Cwcf.ToDoService.IService1, Cwcf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
	public interface IService1_P
	{
		global::System.Threading.Tasks.Task_P<string> GetDataAsync(int value);

		global::System.Threading.Tasks.Task_P<global::Cwcf.ToDoService.CompositeType_P> GetDataUsingDataContractAsync(global::Cwcf.ToDoService.CompositeType_P composite);
	}
}

namespace System.Reflection
{
	[global::System.Runtime.InteropServices.McgRedirectedType("System.Reflection.DispatchProxy, System.Private.Interop, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f" +
		"7f11d50a3a")]
	public class DispatchProxy_P
	{
	}
}

namespace System.ServiceModel.Channels
{
	[global::System.Runtime.InteropServices.McgRedirectedType("System.ServiceModel.Channels.ServiceChannelProxy, System.Private.ServiceModel, Version=4.0.0.0, Culture=neutral," +
		" PublicKeyToken=b03f5f7f11d50a3a")]
	public class ServiceChannelProxy_P : global::System.Reflection.DispatchProxy
	{
		protected override object Invoke(
					global::System.Reflection.MethodInfo targetMethodInfo, 
					object[] args)
		{
			return null;
		}
	}
}

namespace System.Threading.Tasks
{
	[global::System.Runtime.InteropServices.McgRedirectedType("System.Threading.Tasks.Task`1, System.Private.Threading, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f" +
		"7f11d50a3a")]
	public class Task_P<TResult>
	{
	}
}

namespace Cwcf.ToDoService
{
	[global::System.Runtime.InteropServices.McgRedirectedType("Cwcf.ToDoService.CompositeType, Cwcf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
	public class CompositeType_P
	{
	}
}
