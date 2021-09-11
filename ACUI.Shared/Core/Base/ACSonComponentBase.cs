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
    public abstract class ACSonComponentBase : ACComponentBase
    {
        /// <summary>
        /// 附加样式
        /// </summary>
        [CascadingParameter(Name = "AdditionStyle")]
        protected string AdditionStyle { get; set; }

        /// <summary>
        /// 作为子组件
        /// </summary>
        [CascadingParameter(Name = "AsSon")]
        protected bool AsSon { get; set; }

        /// <summary>
        /// 使用附加样式
        /// </summary>
        [Parameter]
        public virtual bool UseAdditionStyle { get; set; } = false;

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="styleMapper"></param>
        protected override void OnSetStyle(Mapper styleMapper)
        {
            styleMapper.If(AdditionStyle, () => !string.IsNullOrEmpty(AdditionStyle) && UseAdditionStyle);
        }
    }
}
