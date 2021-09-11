using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// 组件基础
    /// </summary>
    public abstract class ACComponentBase : ComponentBase, IDisposable
    {
        /// <summary>
        /// 事件回调的工厂
        /// </summary>
        protected static readonly EventCallbackFactory CallbackFactory = new EventCallbackFactory();

        /// <summary>
        /// Semantic 组件基础
        /// </summary>
        protected ACComponentBase()
        {
            ClassMapper.Get(() => this.Class);
        }

        /// <summary>
        /// 类映射
        /// </summary>
        protected Mapper ClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 样式映射
        /// </summary>
        protected Mapper StyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 类
        /// </summary>
        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassMapper.Original = value;
            }
        }
        private string _class;

        /// <summary>
        /// 样式
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                StyleMapper.Original = value;
                this.StateHasChanged();
            }
        }
        private string _style;

        /// <summary>
        /// Id
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [Parameter]
        public int? Tabindex { get; set; }

        /// <summary>
        /// 任意参数
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 是否释放
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// Js运行时
        /// </summary>
        [Inject]
        protected IJSRuntime Js { get; set; }

        /// <summary>
        /// 调用状态改变 / 通知渲染
        /// </summary>
        protected void InvokeStateHasChanged()
        {
            InvokeAsync(() =>
            {
                if (!IsDisposed)
                {
                    StateHasChanged();
                }
            });
        }

        /// <summary>
        /// 调用状态改变异步 / 通知渲染
        /// </summary>
        /// <returns></returns>
        protected async Task InvokeStateHasChangedAsync()
        {
            await InvokeAsync(() =>
            {
                if (!IsDisposed)
                {
                    StateHasChanged();
                }
            });
        }

        /// <summary>
        /// Js调用异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task<T> JsInvokeAsync<T>(string code, params object[] args)
        {
            try
            {
                return await Js.InvokeAsync<T>(code, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Js调用异步
        /// </summary>
        /// <param name="code"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task JsInvokeAsync(string code, params object[] args)
        {
            try
            {
                await Js.InvokeVoidAsync(code, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 设置类
        /// </summary>
        protected virtual void OnSetClass(Mapper classMapper) { }

        /// <summary>
        /// 设置样式
        /// </summary>
        protected virtual void OnSetStyle(Mapper styleMapper) { }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Id ??= $"ac-{Guid.NewGuid().ToString("N")}";
            OnSetClass(ClassMapper);
            OnSetStyle(StyleMapper);
        }

        /// <summary>
        /// 释放
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Static

        /// <summary>
        /// Document 点击
        /// </summary>
        protected static event Action<ClickElement[]> DocumentClick;

        /// <summary>
        /// 处理 document 点击事件
        /// </summary>
        [JSInvokable]
        public static void HandleDocumentClick(ClickElement[] path)
        {
            try
            {
                DocumentClick?.Invoke(path);
            }
            catch (Exception)
            {

            }
        }

        #endregion
    }
}
