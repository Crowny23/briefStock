using System;
namespace exerciceArticle
{
	/// <summary>
	/// classe magasin regroupant tous les articles
	/// </summary>
	public class Magasin
	{
		List<Article> ListesArticles { get; set; }

		public Magasin()
		{
			ListesArticles = new();
		}

		/// <summary>
		/// Ajoute un article dans la liste
		/// </summary>
		/// <param name="article">objet article</param>
		public void ajouterArticle(Article article)
		{
			ListesArticles.Add(article);
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
		/// Affiche tous les articles
		/// </summary>
		public void afficherTousLesArticles()
		{
			foreach(Article article in ListesArticles)
			{
				Console.WriteLine(article.ToString());
			}
		}

		/// <summary>
		/// Affiche un article par référence de l'article
		/// </summary>
		/// <param name="reference">la référence en nombre</param>
		public void afficheParRef(int reference)
		{
			foreach(Article article in ListesArticles)
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
                else
                {
                    Console.WriteLine("Aucun article a ce nom");
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
			for(int index = 0; index < ListesArticles.Count(); index++)
			{
				if (ListesArticles[index].Reference == reference)
				{
					ListesArticles[index] = article;
				}
                else
                {
                    Console.WriteLine("Aucun article a cette référence");
                }
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
                }
                else
                {
                    Console.WriteLine("Aucun article a cette référence");
                }
            }
        }

		/// <summary>
		/// Affiche les articles compris entre 2 prix
		/// </summary>
		/// <param name="prix1">1er prix en nombre</param>
		/// <param name="prix2">2ème prix en nombre</param>
		public void afficherParPrix(decimal prix1,decimal prix2)
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

