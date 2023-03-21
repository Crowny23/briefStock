using System;
namespace exerciceArticle
{
	public class Magasin
	{
		List<Article> ListesArticles { get; set; }

		public Magasin()
		{
			ListesArticles = new();
		}

		public void ajouterArticle(Article article)
		{
			ListesArticles.Add(article);
		}

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
		public void afficherTousLesArticles()
		{
			foreach(Article article in ListesArticles)
			{
				Console.WriteLine(article.ToString());
			}
		}

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

		public void afficherParPrix(int prix1,int prix2)
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

