using System;
using System.Reflection;

namespace exerciceArticle
{
	/// <summary>
	/// Classe pour sauvegarder dans un CSV
	/// </summary>
	public class SaveCSV
	{
		public StreamReader StreamReader { get; set; }
		public StreamWriter StreamWriter { get; set; }
        public List<Article> ListesArticles { get; set; }
        private string Fichier = "/Users/alexandre/Projects/briefStock/exerciceArticle/stock.csv"; //A changer selon circonstance

		public SaveCSV()
		{
            ListesArticles = new();
        }

		/// <summary>
		/// Ecrire dans le fichier
		/// </summary>
		/// <param name="ligne">la ligne a ajouter dans le fichier</param>
		public void ecrire(string ligne)
		{
			using (StreamWriter = new StreamWriter(Fichier, true))
			{
				StreamWriter.WriteLine(ligne);
				StreamWriter.Close();
			}
		}

		/// <summary>
		/// Modifie le fichier sur la ligne selectionné
		/// </summary>
		/// <param name="nouvelleLigne">La ligne modifier</param>
		/// <param name="ligneAChanger">la ligne a modifier en nombre</param>
        private void modifierLigne(string nouvelleLigne,  int ligneAChanger)
        {
            string[] arrLine = File.ReadAllLines(Fichier);
            arrLine[ligneAChanger] = nouvelleLigne;
            File.WriteAllLines(Fichier, arrLine);
        }

        private void supprimerLigne(int ligneASupprimer)
        {
            List<string> arrLine = File.ReadAllLines(Fichier).ToList();
            arrLine.RemoveAt(ligneASupprimer);
            File.WriteAllLines(Fichier, arrLine);
        }

        /// <summary>
        /// Test si il existe dans la liste un article avec la même référence
        /// </summary>
        /// <param name="article">objet article</param>
        /// <returns>renvoie vrai ou faux</returns>
        public bool testRef(Article article)
        {
            foreach (Article article1 in ListesArticles)
            {
                if (article1.Reference == article.Reference)
                {
                    Console.WriteLine("Votre article existe déjà");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Permet de transfomer une ligne en Article
        /// </summary>
        /// <param name="ligne">une ligne du fichier en chaine de caractère</param>
        /// <returns></returns>
        private Article stringToArticle(string ligne)
        {
            string[] articleTableau = ligne.Split(';');

            Article article = new();
            article.Nom = articleTableau[0];
            article.Reference = int.Parse(articleTableau[1]);
            article.Prix = decimal.Parse(articleTableau[2]);
            article.Stock = int.Parse(articleTableau[3]);

            return article;
        }

        /// <summary>
        /// Lire le fichier
        /// </summary>
        public void lireStock()
        {
            string ligne = "";
            ListesArticles = new();
            using (StreamReader = new StreamReader(Fichier))
            {
                while ((ligne = StreamReader.ReadLine()) != null)
                {
                    Article article = stringToArticle(ligne);
                    ListesArticles.Add(article);
                }
            }
        }

        /// <summary>
        /// Affiche tous les articles
        /// </summary>
        public void afficherTousLesArticles()
        {
            foreach (Article article in ListesArticles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        /// <summary>
        /// Suprime l'article par référence
        /// </summary>
        /// <param name="reference">la référence en nombre</param>
        public void supprimerParRef(int reference)
        {
            for (int index = 0; index < ListesArticles.Count(); index++)
            {
                if (ListesArticles[index].Reference == reference)
                {
                    ListesArticles.RemoveAt(index);
                    supprimerLigne(index);
                }
            }
        }

        /// <summary>
        /// Modifie un article par référence dans la liste
        /// </summary>
        /// <param name="reference">la référence en nombre</param>
        /// <param name="article">objet article</param>
        public void modifierParRef(int reference, Article article)
        {
            for (int index = 0; index < ListesArticles.Count(); index++)
            {
                if (ListesArticles[index].Reference == reference)
                {
                    ListesArticles[index] = article;
                    modifierLigne(article.AddCsv(), index);
                }
            }
        }

        /// <summary>
        /// Affiche un article par référence de l'article
        /// </summary>
        /// <param name="reference">la référence en nombre</param>
        public void afficheParRef(int reference)
        {
            foreach (Article article in ListesArticles)
            {
                if (article.Reference == reference)
                {
                    Console.WriteLine(article.ToString());
                }
                else
                {
                    Console.WriteLine("Aucun article a cette référence");
                }
            }
        }

        /// <summary>
        /// Affiche un article par nom de l'article
        /// </summary>
        /// <param name="nom">chaine de caractère du nom</param>
        public void afficherParNom(string nom)
        {
            foreach (Article article in ListesArticles)
            {
                if (article.Nom == nom)
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }

        /// <summary>
		/// Affiche les articles compris entre 2 prix
		/// </summary>
		/// <param name="prix1">1er prix en nombre</param>
		/// <param name="prix2">2ème prix en nombre</param>
		public void afficherParPrix(decimal prix1, decimal prix2)
        {
            foreach (Article article in ListesArticles)
            {
                if (article.Prix >= prix1 && article.Prix <= prix2)
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }
    }
}

