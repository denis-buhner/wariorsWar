using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal class UnitFactory
    {
        private Dictionary<int, Func<Warior>> _creators = new Dictionary<int, Func<Warior>>();

        public void RegisterClass(int id, Func<Warior> creator)
        {
            _creators[id] = creator;
        }

        public Warior CreateWarior(int id)
        {
            if (_creators.ContainsKey(id))
            {
                return _creators[id]();
            }
            else
            {
                throw new ArgumentException(string.Format("index for creating not found"));
            }
        }
    }
}
