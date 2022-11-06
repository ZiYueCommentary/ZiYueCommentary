﻿namespace SCP.Items
{
    public sealed class ItemList
    {
        private ItemList() { }

        public static readonly Item Origami = new("Origami", "origami");
        public static readonly Document Doc079 = new("Document SCP-079", "doc079");
        public static readonly Document Doc106 = new("Document SCP-106", "doc106");
    }

    public class Item
    {
        public readonly string ID;
        protected string DisplayName;

        // id ingore case
        public Item(string displayName, string id)
        {
            DisplayName = displayName;
            ID = id;
            Core.Lists.AddItem(this);
        }

        public virtual string GetDisplayName()
        {
            return DisplayName;
        }

        public virtual InteractionResult Interact()
        {
            return InteractionResult.FAILED;
        }

        public virtual PlaceHolder GetInventoryImage()
        {
            return new();
        }
    }

    public class Document : Item
    {
        public Document(string displayName, string id) : base(displayName, id)
        {
        }

        public override InteractionResult Interact()
        {
            return InteractionResult.SUCCESS;
        }
    }

    public enum InteractionResult
    {
        SUCCESS, FAILED
    }
}