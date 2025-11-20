using System.Collections.Generic;
using AppBase.ArchiveDeath;

public class BuffRecord : BaseRecord<BuffArchiveData>
{

    public Dictionary<BuffType, BuffData> GetBuffs()
    {
        return ArchiveData.BuffingItems;
    }
    
    public void AddBuff(BuffType type, BuffData data)
    {
        ArchiveData.BuffingItems.TryAdd(type, data);
    }

    public void RemoveBuff(BuffType type)
    {
        ArchiveData.BuffingItems.Remove(type);
    }
}