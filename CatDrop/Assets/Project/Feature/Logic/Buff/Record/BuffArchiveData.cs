using System;
using System.Collections.Generic;
using AppBase.ArchiveDeath;

[Serializable]
public class BuffArchiveData : BaseArchiveData
{
    public Dictionary<BuffType, BuffData> BuffingItems = new ();
}