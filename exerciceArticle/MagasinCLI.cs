using System;
namespace exerciceArticle
{
    /// <summary>
    /// Affichage CLI du magasin
    /// </summary>
	public class MagasinCLI
	{
		public bool Exit { get; set; }
        //public Magasin Magasin { get; set; }
        public SaveCSV SaveCSV { get; set; }

		public MagasinCLI()
		{
			Exit = true;
            //Magasin = new();
            SaveCSV = new();
		}

        /// <summary>
        /// Menu du CLI
        /// </summary>
		public void menuCLI()
		{
            while (Exit)
            {
                SaveCSV.lireStock();
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
                            if (SaveCSV.testRef(article)) //pour Magasin changer SaveCSV par Magasin
                            {
                                goto Ajouter;
                            }
                            //Magasin.ajouterArticle(article);
                            SaveCSV.ecrire(article.AddCsv());
                            break;
                        case 3:
                            supprimerParRef();
                            break;
                        case 4:
                            modifierParRef();
                            break;
                        case 5:
                            afficherParNom();
                            sortirParTouche();
                            break;
                        case 6:
                            afficherParPrix();
                            sortirParTouche();
                            break;
                        case 7:
                            afficherTousLesArticles();
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

        /// <summary>
        /// Ajoute un article dans le magasin
        /// </summary>
        /// <returns>objet article</returns>
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
                    article.Prix = decimal.Parse(Console.ReadLine());
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Prix;
                }
            Stock:
                try
                {
                    Console.WriteLine("Stock :");
                    article.Stock = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Stock;
                }

            return article;
        }

        /// <summary>
        /// Affiche tous les articles du magasin
        /// </summary>
        public void afficherTousLesArticles()
        {
            //Magasin.afficherTousLesArticles();
            SaveCSV.afficherTousLesArticles();
        }

        /// <summary>
        /// Suprime un article par sa référence
        /// </summary>
        public void supprimerParRef()
        {
            afficherTousLesArticles();
            int saisieRef = saisieReference();
            //Magasin.supprimerParRef(saisieRef);
            SaveCSV.supprimerParRef(saisieRef);
        }

        /// <summary>
        /// Saisir une référence d'article
        /// </summary>
        /// <returns>La référence saisie en nombre</returns>
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

        /// <summary>
        /// Saisir un nom d'article
        /// </summary>
        /// <returns>Le nom saisie en chaine de caractère</returns>
        public string saisieNom()
        {
            Console.WriteLine("Saisissez un nom :");
            string saisieNom = Console.ReadLine();
            return saisieNom;
        }

        /// <summary>
        /// Saisir 2 nombres pour faire l'interval de prix
        /// </summary>
        /// <returns>retourne les 2 prix saisis en nombre</returns>
        public (decimal, decimal) saisiePrix()
        {
            decimal prix1 = 0;
            decimal prix2 = 0;
            Prix1:
                try
                {
                    Console.WriteLine("Saisissez le premier prix :");
                    prix1 = decimal.Parse(Console.ReadLine());
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
                    prix2 = decimal.Parse(Console.ReadLine());
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

        /// <summary>
        /// Affiche les articles compris entre 2 prix
        /// </summary>
        public void afficherParPrix()
        {
            (decimal prix1, decimal prix2) = saisiePrix();
            //Magasin.afficherParPrix(prix1, prix2);
            SaveCSV.afficherParPrix(prix1, prix2);
        }

        /// <summary>
        /// Affiche un article par référence
        /// </summary>
        public void afficherParRef()
        {
            int saisieRef = saisieReference();
            //Magasin.afficheParRef(saisieRef);
            SaveCSV.afficheParRef(saisieRef);
        }

        /// <summary>
        /// Affiche un article par Nom
        /// </summary>
        public void afficherParNom()
        {
            string saisie = saisieNom();
            //Magasin.afficherParNom(saisie);
            SaveCSV.afficherParNom(saisie);
        }

        /// <summary>
        /// Modifie un article par ref
        /// </summary>
        public void modifierParRef()
        {
            afficherTousLesArticles();
            int saisieRef = saisieReference();
            Article article = ajouterArticle();
            //Magasin.modifierParRef(saisieRef, article);
            SaveCSV.modifierParRef(saisieRef, article);
        }

        /// <summary>
        /// Permet de revenir dans le menu
        /// </summary>
        public void sortirParTouche()
        {
            Console.WriteLine("Appyer sur une touche pour sortir");
            Console.ReadKey();
        }
	}
}

