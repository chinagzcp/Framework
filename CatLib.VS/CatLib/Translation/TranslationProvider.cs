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
using CatLib.API.Config;
using CatLib.API.Translation;

namespace CatLib.Translation
{
    /// <summary>
    /// 国际化服务提供者
    /// </summary>
    public sealed class TranslationProvider : IServiceProvider
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
        }

        /// <summary>
        /// 当注册国际化服务时
        /// </summary>
        public void Register()
        {
            App.Singleton<Translator>().Alias<ITranslator>().OnResolving((bind, obj) =>
            {
                var tran = (Translator)obj;
                tran.SetSelector(new Selector());

                var config = App.Make<IConfig>();
                tran.SetLocale(config.SafeGet("translation.default", Languages.Chinese));
                tran.SetFallback(config.SafeGet("translation.fallback", Languages.Chinese));

                return obj;
            });
        }
    }
}
#endif