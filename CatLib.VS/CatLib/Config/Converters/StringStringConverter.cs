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

using System;
using CatLib.API.Config;

namespace CatLib.Config
{
    /// <summary>
    /// 字符串转换
    /// </summary>
    internal class StringStringConverter : ITypeStringConverter
    {
        /// <summary>
        /// 转换目标类型到字符串
        /// </summary>
        /// <param name="value">要被转换的对象</param>
        /// <returns>转换后的字符串</returns>
        public string ConvertToString(object value)
        {
            return value.ToString();
        }

        /// <summary>
        /// 转换自字符串到目标类型
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="to">目标类型</param>
        /// <returns>转换后的目标对象</returns>
        public object ConvertFromString(string value, Type to)
        {
            return value;
        }
    }
}