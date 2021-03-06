// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

// If we're running in the Unity Editor we need the editors platform.
#if UNITY_EDITOR_WIN
	#define VALVE_CALLBACK_PACK_LARGE
#elif UNITY_EDITOR_OSX
	#define VALVE_CALLBACK_PACK_SMALL

// Otherwise we want the target platform.
#elif UNITY_STANDALONE_WIN || STEAMWORKS_WIN
	#define VALVE_CALLBACK_PACK_LARGE
#elif UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || STEAMWORKS_LIN_OSX
	#define VALVE_CALLBACK_PACK_SMALL

// We do not want to throw a warning when we're building in Unity but for an unsupported platform. So we'll silently let this slip by.
// It would be nice if Unity itself would define 'UNITY' or something like that...
#elif UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_5
	#define VALVE_CALLBACK_PACK_SMALL

// But we do want to be explicit on the Standalone build for XNA/Monogame.
#else
	#define VALVE_CALLBACK_PACK_LARGE
	#warning You need to define STEAMWORKS_WIN, or STEAMWORKS_LIN_OSX. Refer to the readme for more details.
#endif

namespace Steamworks {
	public static class Packsize {
#if VALVE_CALLBACK_PACK_LARGE
		public const int Value = 8;
#elif VALVE_CALLBACK_PACK_SMALL
		public const int value = 4;
#endif

		public static bool Test() {
#if VALVE_CALLBACK_PACK_LARGE
			return false;
#elif VALVE_CALLBACK_PACK_SMALL
			return sentinelSize == 24 && subscribedFilesSize == (1 + 1 + 1 + 50 + 100) * 4;
#endif
		}
	}
}
