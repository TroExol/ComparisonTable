using System;
using System.Collections.Generic;

namespace ComparisonTable.Classes
{
    public class SiteItems
    {
        /// <summary>
        /// Делегат при изменении списка предметов
        /// </summary>
        event EventHandler OnSet;
        /// <summary>
        /// Делегат при добавлении в список предметов
        /// </summary>
        event EventHandler OnAdd;
        private List<Item> _items;
        
        public SiteItems(EventHandler onSet, EventHandler onAdd)
        {
            OnSet += onSet;
            OnAdd += onAdd;
        }
        
        /// <summary>
        /// Список предметов
        /// </summary>
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                // Выполнить делегат при изменении списка предметов
                OnSet?.Invoke(this, null);
            }
        }
        
        /// <summary>
        /// Добавление предмета
        /// </summary>
        /// <param name="item">Добавляемый предмет</param>
        public void Add(Item item)
        {
            Items.Add(item);
            OnAdd?.Invoke(this, null);
        }
    }
}