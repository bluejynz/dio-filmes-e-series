using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;


namespace DIO.Series
{
    public class ShowRepository : IRepository<Show>
    {
        private List<Show> showList = new List<Show>();
        public void Insert(Show entity)
        {
            showList.Add(entity);
        }

        public List<Show> List()
        {
            return showList;
        }

        public int NextId()
        {
            return showList.Count;
        }

        public void Remove(int id)
        {
            showList[id].Remove();
        }

        public Show returnById(int id)
        {
            return showList[id];
        }

        public void Update(int id, Show entity)
        {
            showList[id] = entity;
        }
    }
}