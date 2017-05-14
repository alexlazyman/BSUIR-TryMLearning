using System.Web.Optimization;

namespace TryMLearning.Web
{
    public class AngularJsHtmlBundle : Bundle
    {
        public AngularJsHtmlBundle(string virtualPath, string moduleName)
            : base(
                  virtualPath,
                  null,
                  new[] { (IBundleTransform)new AngularJsHtmlCombine(moduleName) })
        {
        }
    }
}