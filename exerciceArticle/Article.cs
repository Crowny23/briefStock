using System;
namespace exerciceArticle
{
	/// <summary>
	/// Classe de l'Article
	/// </summary>
	public class Article
	{
		public string Nom { get; set; }
		public int Reference { get; set; }
		public decimal Prix { get; set; }
		public int Stock { get; set; }

		public Article()
		{
			Nom = "";
			Reference = 0;
			Prix = 0;
			Stock = 0;
		}

		/// <summary>
		/// Affiche le contenu d'un article
		/// </summary>
		/// <returns>Chaine de caractère des attributs</returns>
        public override string ToString()
        {
            return $"Nom: {Nom}, Référence: {Reference}, Prix: {Prix}€, Stock: {Stock}";
        }

		public string AddCsv()
		{
			return $"{Nom};{Reference};{Prix};{Stock}";
		}
    }
}

