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

using CatLib.Debugger.WebMonitor.Handler;
using UnityEngine;

namespace CatLib.Debugger.WebMonitorContent
{
    /// <summary>
    /// 罗盘相关监控
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class InputCompassMonitor
    {
        /// <summary>
        /// 罗盘相关监控
        /// </summary>
        /// <param name="monitor">监控</param>
        public InputCompassMonitor([Inject(Required = true)]IMonitor monitor)
        {
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.enabled.cmd", string.Empty, new[] { "tags.input.compass" },
                () =>
                {
                    if (!Input.gyro.enabled)
                    {
                        return "[command.help.clickStart](debug://command/input-compass-enable/true)";
                    }
                    return "[command.help.clickStop](debug://command/input-compass-enable/false)";
                }));
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.enabled", string.Empty, new[] { "tags.input.compass" },
                () => Input.compass.enabled));
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.headingAccuracy", "unit.degree", new[] { "tags.input.compass" },
                () => Input.compass.headingAccuracy));
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.magneticHeading", "unit.degree", new[] { "tags.input.compass" },
                () => Input.compass.magneticHeading));
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.rawVector", "unit.microteslas", new[] { "tags.input.compass" },
                () => Input.compass.rawVector));
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.timestamp", string.Empty, new[] { "tags.input.compass" },
                () => Input.compass.timestamp));
            monitor.Monitor(new OnceRecordMonitorHandler("input.compass.trueHeading", "unit.degree", new[] { "tags.input.compass" },
                () => Input.compass.trueHeading));
        }
    }
}
