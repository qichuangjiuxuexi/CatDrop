using System;
using System.Collections.Generic;

public static class BuffFactory
{
    private static Dictionary<BuffType, Func<BuffBase>> factory = new Dictionary<BuffType, Func<BuffBase>>();

    public static void RegisterBuff<T>(BuffType type) where T : BuffBase, new()
    {
        factory[type] = () => new T();
    }

    public static BuffBase CreateBuff(BuffType type)
    {
        if (factory.TryGetValue(type, out var creator))
        {
            return creator();
        }

        return null;
    }
}
