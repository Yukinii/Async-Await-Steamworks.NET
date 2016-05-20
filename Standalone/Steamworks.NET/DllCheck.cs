using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Steamworks.NET
{
    public class DllCheck {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        extern static int GetModuleFileName(IntPtr hModule, StringBuilder strFullPath, int nSize);

        /// <summary>
        /// This is an optional runtime check to ensure that the dlls are the correct version. Returns false only if the stea_api.dll is found and it's the wrong size or version number.
        /// </summary>
        public static bool Test() => true;

        private static bool CheckSteamAPIDLL() {
#if STEAMWORKS_WIN || (UNITY_EDITOR_WIN && UNITY_STANDALONE) || (!UNITY_EDITOR && UNITY_STANDALONE_WIN)
            string fileName;
            int fileBytes;
            if (IntPtr.Size == 4) {
                fileName = "stea_api.dll";
                fileBytes = Version.SteamApidllSize;
            }
            else {
                fileName = "stea_api64.dll";
                fileBytes = Version.SteamAPI64DllSize;
            }

            var handle = GetModuleHandle(fileName);
            if (handle == IntPtr.Zero) {
                return true;
            }

            var filePath = new StringBuilder(256);
            GetModuleFileName(handle, filePath, filePath.Capacity);
            var file = filePath.ToString();

            // If we can not find the file we'll just skip it and let the DllNotFoundException take care of it.
            if (System.IO.File.Exists(file)) {
                var fInfo = new System.IO.FileInfo(file);
                if (fInfo.Length != fileBytes) {
                    return false;
                }

                if (System.Diagnostics.FileVersionInfo.GetVersionInfo(file).FileVersion != Version.SteamApidllVersion) {
                    return false;
                }
            }
#endif
            return true;
        }
    }
}