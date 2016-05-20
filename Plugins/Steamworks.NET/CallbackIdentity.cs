// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

using System;
using Steamworks.Steamworks.NET;

namespace Steamworks {
    static class CallbackIdentities {
		public static int GetCallbackIdentity(Type callbackStruct) {
			foreach (CallbackIdentityAttribute attribute in callbackStruct.GetCustomAttributes(typeof(CallbackIdentityAttribute), false)) {
				return attribute.Identity;
			}

			throw new Exception("Callback number not found for struct " + callbackStruct);
		}
	}
}