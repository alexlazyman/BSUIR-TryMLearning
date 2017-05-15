using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;
using Newtonsoft.Json;

namespace TryMLearning.Web.Bundles
{
    public class AngularJsHtmlCombine : IBundleTransform
    {
        private const string JsContentType = "text/javascript";
        private static readonly Regex RegexBetweenTags = new Regex(@">(?! )\s+", RegexOptions.Compiled);
        private static readonly Regex RegexLineBreaks = new Regex(@"([\n\s])+?(?<= {2,})<", RegexOptions.Compiled);

        public AngularJsHtmlCombine(string modulename)
        {
            ModuleName = modulename;
        }

        public string ModuleName { get; set; }

        public void Process(BundleContext context, BundleResponse response)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (!context.EnableOptimizations)
            {
                response.Files = new List<BundleFile>();
                response.Content = string.Empty;
                return;
            }

            var contentBuilder = new StringBuilder();
            contentBuilder.Append("(function(){'use strict';");
            contentBuilder.AppendFormat("angular.module('{0}').run(['$templateCache',function($templateCache){{", ModuleName);

            foreach (BundleFile file in response.Files)
            {
                string fileId = VirtualPathUtility.ToAbsolute(file.IncludedVirtualPath);
                string filePath = HttpContext.Current.Server.MapPath(file.IncludedVirtualPath);
                string fileContent = File.ReadAllText(filePath).Trim();

                contentBuilder.AppendFormat(
                    "$templateCache.put({0},{1});",
                    JsonConvert.SerializeObject(fileId),
                    JsonConvert.SerializeObject(fileContent));
            }

            contentBuilder.Append("}]);");
            contentBuilder.Append("})();");

            response.Content = contentBuilder.ToString();
            response.ContentType = JsContentType;
        }
    }
}