using System;
namespace exerciceArticle
{
	public class Article
	{
		public string Nom { get; set; }
		public int Reference { get; set; }
		public int Prix { get; set; }

		public Article()
		{
			Nom = "";
			Reference = 0;
			Prix = 0;
		}

        public override string ToString()
        {
            return $"Nom: {Nom}, Référence: {Reference}, Prix: {Prix}€";
        }
    }
}

