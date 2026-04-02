using System;

namespace RoachRace.Data
{
    /// <summary>
    /// Snapshot of a single inventory slot.<br><br>
    /// Typical usage: replicated through networking and rendered by UI models as a value type snapshot.<br>
    /// Context: <see cref="ItemId"/> identifies the authored item, <see cref="Count"/> is the current amount, and a slot is only truly empty when <see cref="ItemId"/> is 0.<br>
    /// </summary>
    [Serializable]
    public struct InventorySlotState
    {
        /// <summary>
        /// Authored item id stored in the slot.<br><br>
        /// A value of 0 represents an empty slot with no item entry.
        /// </summary>
        public ushort ItemId;

        /// <summary>
        /// Current amount stored in the slot.<br><br>
        /// A retained-but-depleted entry may keep ItemId non-zero while Count is 0.
        /// </summary>
        public int Count;

        /// <summary>
        /// Returns true when the slot contains no item entry at all.<br><br>
        /// Typical usage: UI placeholder rendering and slot allocation checks should treat ItemId 0 as empty, even if other systems retain depleted item ids at Count 0.
        /// </summary>
        public bool IsEmpty => ItemId == 0;

        /// <summary>
        /// Returns true when the slot still references an item id, even if the count has reached 0.<br><br>
        /// Typical usage: inventory UI and selection visuals can continue to display retained depleted items.
        /// </summary>
        public bool HasItem => ItemId != 0;

        /// <summary>
        /// Returns true when the slot references an item id but has no remaining count.<br><br>
        /// Typical usage: use/consume logic should treat this as unavailable while still allowing the slot to remain visible when item rules keep depleted entries.
        /// </summary>
        public bool IsDepleted => ItemId != 0 && Count <= 0;

        /// <summary>
        /// Returns a human-readable representation of the slot.<br><br>
        /// Typical usage: diagnostics and error logs.
        /// </summary>
        override public string ToString()
        {
            return IsEmpty ? "Empty" : $"ItemId={ItemId}, Count={Count}";
        }
    }
}
