using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetHttpsForFreeUI
{
    internal static class ResourceStream
    {
        public const string Error = "error-16.png";
        public const string Ok = "ok-16.png";
        public const string Warning = "warn-16.png";

        public static Bitmap GetImage(string name)
        {
            var stream = Assembly.GetEntryAssembly().GetManifestResourceStream($"GetHttpsForFreeUI.img.{name}");
            return stream == null ? null : new Bitmap(stream);
        }
    }
}
