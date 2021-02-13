using System;

namespace DIO.Series
{
    public class Movie : BaseEntity
    {
        //Attributes
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool isRemoved { get; set; }

        //Methods

        public Movie(Genre genre, string title, string description, int year) 
        {
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.isRemoved = false;
        }
        public Movie(int id, Genre genre, string title, string description, int year){
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.isRemoved = false;
        }

        public override string ToString()
        {
            string r = "";
            r += "Gênero: " + this.Genre + Environment.NewLine;
            r += "Título: " + this.Title + Environment.NewLine;
            r += "Descrição: " + this.Description + Environment.NewLine;
            r += "Ano de lançamento: " + this.Year + Environment.NewLine;
            r += "Removido: " + this.isRemoved;
            return r;
        }

        public string returnTitle(){
            return this.Title;
        }

        public int returnId(){
            return this.Id;
        }

        public bool returnRemoved(){
            return this.isRemoved;
        }

        public void Remove(){
            this.isRemoved = true;
        }
    }
}