using System;
using System.Globalization;
using PCL.Core.App;

namespace PCL.Core.Utils;

public static class RegionUtils
{
    /// <summary>
    /// 获取区域限制状态。社区版已移除地域限制，始终返回 true
    /// </summary>
    public static bool IsRestrictedFeatAllowed => true;
}