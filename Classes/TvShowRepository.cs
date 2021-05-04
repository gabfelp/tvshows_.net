using System;
using System.Collections.Generic;
using Tvshows.Interfaces;

namespace Tvshows
{
    public class TvShowRepository : IRepository<TvShow>
    {
        private List<TvShow> showsList = new List<TvShow>();
        public void Delete(int id)
        {
            showsList[id].Delete();
        }

        public void Insert(TvShow obj)
        {
            showsList.Add(obj);
        }

        public List<TvShow> List()
        {
            return showsList;
        }

        public int NextId()
        {
            return showsList.Count;
        }

        public TvShow ReturnById(int id)
        {
            return showsList[id];
        }

        public void Update(int id, TvShow obj)
        {
            if(obj != null){
                showsList[id] = obj;
            }
        }
    }
}