using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Inventory
    {
        private int _capacity = 0;
        private List<FantasyWeapon> _items = new List<FantasyWeapon>();

        public int Capacity
        {
            get { return _capacity; }
            set { 
                if (value >= 0) 
                    _capacity = value; }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public List<FantasyWeapon> Items
        {
            get { return _items; }
            private set { _items = value; }
        }

        public Inventory(int capacity, List<FantasyWeapon> items)
        {
            Capacity = capacity;
            Items = items.ToList();//make a clone
        }

        public void AddItem(FantasyWeapon itemToAdd)
        {
            if (Count == Capacity)
                throw new Exception("\"The inventory is full, FOOL!\" - Mr. T.");

            _items.Add(itemToAdd);
            Console.WriteLine($"{itemToAdd} added to the inventory.");
        }

        public void PrintInventory()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine("\nWeapon: ");
                FantasyWeapon fw = _items[i];
                Console.WriteLine($"I have a {fw.Rarity} level {fw.Level} weapon that can do {fw.MaxDamage} of damage. And it costs {fw.Cost} gold." );
                
                if(fw is BowWeapon bow)//downcasting
                    Console.WriteLine($"I have {bow.ArrowCount} arrows. I can have up to {bow.ArrowCapacity} arrows.");
            }
        }

    }
}
