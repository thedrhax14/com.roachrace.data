using System;

namespace RoachRace.Data
{
    [Serializable]
    public struct InventorySlotState
    {
        public ushort ItemId;
        public int Count;

        public bool IsEmpty => ItemId == 0 || Count == 0;

        override public string ToString()
        {
            return IsEmpty ? "Empty" : $"ItemId={ItemId}, Count={Count}";
        }
    }
}
