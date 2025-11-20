using System;

public static class TimeUtil
{
    /// <summary>
    /// 获得Unix时间戳
    /// 即从1970年1月1日午夜, 至今的秒数
    /// </summary>
    public static long GetTimeStamp()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}