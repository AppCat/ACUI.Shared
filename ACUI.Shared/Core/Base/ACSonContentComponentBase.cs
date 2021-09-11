using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// 子组件基础
    /// </summary>
    public abstract class ACSonContentComponentBase : ACSonComponentBase
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
