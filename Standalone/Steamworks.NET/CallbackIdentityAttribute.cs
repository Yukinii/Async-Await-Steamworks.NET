using System;

namespace Steamworks.Steamworks.NET
{
    [AttributeUsage(AttributeTargets.Struct)]
    internal class CallbackIdentityAttribute : Attribute {
        public int Identity { get; set; }
        public CallbackIdentityAttribute(int callbackNum) {
            Identity = callbackNum;
        }
    }
}