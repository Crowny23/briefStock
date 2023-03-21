using System;
namespace exerciceArticle
{
	public class MagasinCLI
	{
		public bool Exit { get; set; }
        public Magasin Magasin { get; set; }

		public MagasinCLI()
		{
			Exit = true;
            Magasin = new();
		}

		public void menuCLI()
		{
            while (Exit)
            {
                Console.WriteLine("1) Rechercher un article par référence");
                Console.WriteLine("2) Ajouter un article");
                Console.WriteLine("3) Supprimer un article par référence");
                Console.WriteLine("4) Modifier un article par référence");
                Console.WriteLine("5) Rechercher un article par nom");
                Console.WriteLine("6) Rechercher un article par intervalle de prix");
                Console.WriteLine("7) Afficher tous les articles");
                Console.WriteLine("8) Quitter");
                try
                {
                    int saisieUtilisateur = int.Parse(Console.ReadLine());

                    switch (saisieUtilisateur)
                    {
                        case 1:
                            afficherParRef();
                            sortirParTouche();
                            break;
                        case 2:
                            Ajouter:
                                Article article = ajouterArticle();
                            if (Magasin.testRef(article))
                            {
                                goto Ajouter;
                            }
                            Magasin.ajouterArticle(article);
                            break;
                        case 3:
                            supprimerParRef();
                            break;
                        case 4:
                            modifierParRef();
                            break;
                        case 5:
                            afficherParNom();
                            break;
                        case 6:
                            afficherParPrix();
                            break;
                        case 7:
                            afficherToutesLesArticles();
                            sortirParTouche();
                            break;
                        case 8:
                            Exit = false;
                            break;
                        default:
                            break;
                    }
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Article ajouterArticle()
        {
            Article article = new();

            Console.WriteLine("Nom :");
            article.Nom = Console.ReadLine();

            Reference:
                try
                {
                    Console.WriteLine("Référence :");
                    article.Reference = int.Parse(Console.ReadLine());
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Reference;
                }
            Prix:
                try
                {
                    Console.WriteLine("Prix :");
                    article.Prix = int.Parse(Console.ReadLine());
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Prix;
                }

            return article;
        }

        public void afficherToutesLesArticles()
        {
            Magasin.afficherTousLesArticles();
        }

        public void supprimerParRef()
        {
            afficherToutesLesArticles();
            int saisieRef = saisieReference();
            Magasin.supprimerParRef(saisieRef);
        }

        public int saisieReference()
        {
            int saisieRef = 0;
            Reference:
                try
                {
                    Console.WriteLine("Saisissez la référence :");
                    saisieRef = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Reference;
                }
            return saisieRef;
        }

        public string saisieNom()
        {
            Console.WriteLine("Saisissez un nom :");
            string saisieNom = Console.ReadLine();
            return saisieNom;
        }

        public (int, int) saisiePrix()
        {
            int prix1 = 0;
            int prix2 = 0;
            Prix1:
                try
                {
                    Console.WriteLine("Saisissez le premier prix :");
                    prix1 = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Prix1;
                }
            Prix2:
                try
                {
                    Console.WriteLine("Saisissez le deuxième prix :");
                    prix2 = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Prix2;
                }
            if (prix2 < prix1)
            {
                goto Prix1;
            }
            return (prix1, prix2);
        }

        public void afficherParPrix()
        {
            (int prix1, int prix2) = saisiePrix();
            Magasin.afficherParPrix(prix1, prix2);
        }

        public void afficherParRef()
        {
            int saisieRef = saisieReference();
            Magasin.afficheParRef(saisieRef);
        }

        public void afficherParNom()
        {
            string saisie = saisieNom();
            Magasin.afficherParNom(saisie);
        }

        public void modifierParRef()
        {
            afficherToutesLesArticles();
            int saisieRef = saisieReference();
            Article article = ajouterArticle();
            Magasin.modifierParRef(saisieRef, article);
        }

        public void sortirParTouche()
        {
            Console.WriteLine("Appyer sur une touche pour sortir");
            Console.ReadKey();
        }
	}
}

