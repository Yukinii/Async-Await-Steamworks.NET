// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks {
    internal static class InteropHelp {
		public static void TestIfPlatformSupported() {
#if !UNITY_EDITOR && !UNITY_STANDALONE_WIN && !UNITY_STANDALONE_LINUX && !UNITY_STANDALONE_OSX && !STEAMWORKS_WIN && !STEAMWORKS_LIN_OSX
			throw new System.InvalidOperationException("Steamworks functions can only be called on platforms that Steam is available on.");
#endif
		}

		public static void TestIfAvailableClient() {
			TestIfPlatformSupported();
			if (NativeMethods.SteamClient() == IntPtr.Zero) {
				throw new InvalidOperationException("Steamworks is not initialized.");
			}
		}

		public static void TestIfAvailableGameServer() {
			TestIfPlatformSupported();
			if (NativeMethods.SteamClientGameServer() == IntPtr.Zero) {
				throw new InvalidOperationException("Steamworks is not initialized.");
			}
		}
		
		// This continues to exist for both 'out string' and strings returned by Steamworks functions.
		public static string PtrToStringUTF8(IntPtr nativeUtf8) {
			if (nativeUtf8 == IntPtr.Zero) {
				return string.Empty;
			}

			var len = 0;

			while (Marshal.ReadByte(nativeUtf8, len) != 0) {
				++len;
			}

			if (len == 0) {
				return string.Empty;
			}

			var buffer = new byte[len];
			Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
			return Encoding.UTF8.GetString(buffer);
		}

		// This is for 'const char *' arguments which we need to ensure do not get GC'd while Steam is using them.
		// We can't use an ICustomMarshaler because Unity crashes when a string between 96 and 127 characters long is defined/initialized at the top of class scope...
		public class UTF8StringHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid {
			public UTF8StringHandle(string str)
				: base(true) {
				if (str == null) {
					SetHandle(IntPtr.Zero);
					return;
				}

				var strbuf = new byte[Encoding.UTF8.GetByteCount(str) + 1];
				Encoding.UTF8.GetBytes(str, 0, str.Length, strbuf, 0);
				var buffer = Marshal.AllocHGlobal(strbuf.Length);
				Marshal.Copy(strbuf, 0, buffer, strbuf.Length);

				SetHandle(buffer);
			}

			protected override bool ReleaseHandle() {
				if (!IsInvalid) {
					Marshal.FreeHGlobal(handle);
				}
				return true;
			}
		}

		// TODO - Should be IDisposable
		// We can't use an ICustomMarshaler because Unity dies when MarshalManagedToNative() gets called with a generic type.
		public class SteamParamStringArray {
			// The pointer to each AllocHGlobal() string
		    readonly IntPtr[] _Strings;
			// The pointer to the condensed version of _Strings
		    readonly IntPtr _ptrStrings;
			// The pointer to the StructureToPtr version of SteamParamStringArray that will get marshaled
		    readonly IntPtr _pSteamParamStringArray;

			public SteamParamStringArray(IList<string> strings) {
				if (strings == null) {
					_pSteamParamStringArray = IntPtr.Zero;
					return;
				}

				_Strings = new IntPtr[strings.Count];
				for (var i = 0; i < strings.Count; ++i) {
					var strbuf = new byte[Encoding.UTF8.GetByteCount(strings[i]) + 1];
					Encoding.UTF8.GetBytes(strings[i], 0, strings[i].Length, strbuf, 0);
					_Strings[i] = Marshal.AllocHGlobal(strbuf.Length);
					Marshal.Copy(strbuf, 0, _Strings[i], strbuf.Length);
				}

				_ptrStrings = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * _Strings.Length);
				var stringArray = new global::Steamworks.SteamParamStringArray
				{
					_ppStrings = _ptrStrings,
					NumStrings = _Strings.Length
				};
				Marshal.Copy(_Strings, 0, stringArray._ppStrings, _Strings.Length);

				_pSteamParamStringArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamParamStringArray)));
				Marshal.StructureToPtr(stringArray, _pSteamParamStringArray, false);
			}

			~SteamParamStringArray() {
				foreach (var ptr in _Strings) {
					Marshal.FreeHGlobal(ptr);
				}

				if (_ptrStrings != IntPtr.Zero) {
					Marshal.FreeHGlobal(_ptrStrings);
				}

				if (_pSteamParamStringArray != IntPtr.Zero) {
					Marshal.FreeHGlobal(_pSteamParamStringArray);
				}
			}

			public static implicit operator IntPtr(SteamParamStringArray that) => that._pSteamParamStringArray;
		}
	}
	
	// TODO - Should be IDisposable
	// MatchMaking Key-Value Pair Marshaller
}
