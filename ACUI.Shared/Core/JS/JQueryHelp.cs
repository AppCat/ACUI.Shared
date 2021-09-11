using ACUI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// jQuery 帮助类
    /// </summary>
    public static class JQueryHelp
    {
        /// <summary>
        /// 模块
        /// </summary>
        internal static Lazy<Task<IJSObjectReference>> ModuleTask { get; set; }

        static JQueryHelp()
        {
            if (ModuleTask == null)
            {
                ModuleTask = new(() => ACUIShared.JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/ACUI.Shared/jquery/jqueryHelp.js").AsTask()); 
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static async Task<object> Val(this ElementReference element, object value = null)
        {
            return await Method(args: new[] { element, value });
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<object> ValById(this string element, object value = null)
        {
            return await Method(args: new[] { element, value });
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="element"></param>
        public static async Task Click(this ElementReference element)
        {
            await VoidMethod(args: new[] { element });
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static async Task ClickById(this string element)
        {
            await VoidMethod(args: new[] { element });
        }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task<object> Method([CallerMemberName] string method = null, params object[] args)
        {
            var module = await ModuleTask.Value;
            return await module.InvokeAsync<object>(method.ToInitialLower(), args);
        }

        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task VoidMethod([CallerMemberName] string method = null, params object[] args)
        {
            var module = await ModuleTask.Value;
            await module.InvokeVoidAsync(method.ToInitialLower(), args);
        }
    }
}
