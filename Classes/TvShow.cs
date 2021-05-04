namespace Tvshows
{
    public class TvShow : EntityBase
    {
        private Type Type {get; set;}

        private string Title {get; set;}

        private string Description {get; set;}

        private int Year{get; set;}

        private bool Deleted{get; set;}

        public TvShow(int id, Type type, string title, string description, int year)
        {
            this.Id = id;
            this.Type = type;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Type: "+ this.Type + "\n";
            ret += "Title: "+ this.Title + "\n";
            ret += "Description: "+ this.Description + "\n";
            ret += "Year: "+ this.Year + "\n";
            ret += "Deleted: "+ this.Deleted + "\n";
            return ret;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        internal int returnId()
        {
            return this.Id;
        }

        public void Delete(){
            this.Deleted = true;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }
    }
}