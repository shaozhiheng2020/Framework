﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

#if CATLIB
using System;
using CatLib.API.Routing;
using System.Collections.Generic;

namespace CatLib.Routing
{
    /// <summary>
    /// 路由服务
    /// </summary>
    public sealed class RoutingProvider : IServiceProvider
    {
        /// <summary>
        /// 默认的Scheme
        /// </summary>
        [Config("catlib")]
        public string DefaultScheme { get; set; }

        /// <summary>
        /// 会进行属性路由编译的程序集
        /// </summary>
        [Config]
        public IList<string> CompilerAssembly { get; set; }

        /// <summary>
        /// 执行路由编译，路由编译总是最后进行的
        /// </summary>
        /// <returns>迭代器</returns>
        public void Init()
        {
            var router = App.Make<Router>();
            router.RouterCompiler();
        }

        /// <summary>
        /// 注册路由条目
        /// </summary>
        public void Register()
        {
            App.Singleton<Router>((_, __) =>
            {
                var router = new Router(App.Handler, App.Handler);
                router.SetDefaultScheme(DefaultScheme);
                return router;
            }).Alias<IRouter>();

            RegisterAttrRouteCompiler();
        }

        /// <summary>
        /// 注册属性路由编译器
        /// </summary>
        private void RegisterAttrRouteCompiler()
        {
            App.Bind<AttrRouteCompiler>().OnResolving((_, obj) =>
            {
                var compiler = (AttrRouteCompiler)obj;

                var containList = new List<string>(CompilerAssembly ?? new List<string>())
                {
                    "Assembly-CSharp",
                    "Assembly-CSharp-Editor-firstpass",
                    "Assembly-CSharp-Editor",
                    "CatLib",
                    "CatLib.Unity",
                    "CatLib.Tests"
                };

                compiler.OnStripping(assembly => !containList.Contains(assembly.GetName().Name));

                return obj;
            });
        }
    }
}
#endif