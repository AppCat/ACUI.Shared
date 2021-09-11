using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// ACUI 共享
    /// </summary>
    public partial class ACUIShared : OwningComponentBase
    {
        /// <summary>
        /// JS 运行时
        /// </summary>
        internal static IJSRuntime JSRuntime { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            JSRuntime = ScopedServices.GetRequiredService<IJSRuntime>();
        }
    }
}
