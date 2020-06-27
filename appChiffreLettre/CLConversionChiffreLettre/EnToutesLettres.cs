using CLConversionChiffreLettre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLConversionChiffreLettre
{
    public class EnToutesLettres
    {
        public enum Monnaie { Euro, Livre, Dollar }
        public static readonly string[] UNITE = { "", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
        public static readonly string[] DIZAINEFR = { "vingt", "trente", "quarante", "cinquante", "soixante", "", "quatre-vingt", "" };
        public static readonly string[] DIZAINEBL = { "vingt", "trente", "quarante", "cinquante", "soixante", "septante", "octante", "nonante" };
        public static readonly string[] COEF = { "cent", "mille", "million", "milliard" };


        public static string NombreEnLettres(int unNombre)
        {
            bool negatif = false;
            if (unNombre < 0)
            {
                negatif = true;
                unNombre *= -1;
            }
            string resultat = "";
            string x = "";
            string y = "";
            string z = "";
            int u, d, c, j, i, k;
            int coef = 0;
            //verification que le chiffre est égal ou non à 0
            if (unNombre == 0)
            {
                resultat = "Zero";
            }
            else
            {
                while (unNombre > 0)
                {
                    //décomposition du nombre par tranche de 1000
                    if (coef > 0 && unNombre % 1000 > 0)
                    {
                        if (resultat == "")
                        {
                            if (coef == 2 && unNombre % 1000 > 1)
                            {
                                resultat = COEF[coef] + "s";
                            }
                            else
                            {
                                resultat = COEF[coef];
                            }
                        }
                        else
                        {
                            if (coef == 2 && unNombre % 1000 > 1)
                            {
                                resultat = COEF[coef] + "s " + resultat;
                            }
                            else
                            {
                                resultat = COEF[coef] + " " + resultat;
                            }
                        }
                    }
                    //Séparation unité dizaine centaine
                    i = unNombre % 1000;
                    u = i % 10;
                    unNombre = unNombre / 10;
                    i /= 10;
                    d = i % 10;
                    i /= 10;
                    unNombre = unNombre / 10;
                    c = i % 10;
                    i /= 10;
                    unNombre = unNombre / 10;
                    k = u;
                    //cas ou le nombre fait partie de la première dizaine
                    if (d == 1)
                    {
                        k += 10;
                        j = -1;
                    }
                    else
                    {
                        j = d - 2;
                    }
                    //cas ou on à soixante dix ou quatre vingt 10
                    if (d == 7 || d == 9)
                    {
                        k += 10;
                        j -= 1;
                    }
                    //(cas ou l'unité est égale à 1 et ou la dizaine est inférieur à 8
                    if (u == 1 && d < 8 && d != 1 && d != 0)
                    {
                        x = DIZAINEFR[j] + " et " + UNITE[k];
                    }
                    //cas 80
                    else if (d == 8 && u == 0)
                    {
                        x = DIZAINEFR[j] + "s";
                    }
                    //cas premiere dizaine
                    else if (j < 0)
                    {
                        x = UNITE[k];
                    }
                    //cas ou on a une unité égal à 0
                    else if (u == 0)
                    {
                        x = DIZAINEFR[j];
                    }
                    else
                    {
                        x = DIZAINEFR[j] + "-" + UNITE[k];
                    }
                    //cas ou seul la centaine à une valeur et la valeur est supérieur à 1
                    if (c > 1 && d == 0 && u == 0)
                    {
                        y = UNITE[c] + " " + COEF[0] + "s";
                    }
                    //cas ou la centaine est supérieur à 1 et les dizaine et/ou unité on une valeur
                    else if (c > 1)
                    {
                        y = UNITE[c] + " " + COEF[0];
                    }
                    //cas ou la centaine est égal à 1
                    else if (c == 1)
                    {
                        y = COEF[0];
                    }
                    //assemblage des valeur lorsque les centaines et les dizaines et/ou unité on une valeur
                    if (y != "" && x != "")
                    {
                        z = y + " " + x;
                    }
                    else
                    {
                        //cas ou il n'y a pas de dizaines et/ou unité
                        if (x == "")
                        {
                            z = y;
                        }
                        //cas ou il n'y a pas de centaine
                        else if (y == "")
                        {
                            z = x;
                        }
                    }
                    //cas our 1000
                    if (coef == 1 && z == "un")
                    {
                        resultat += "";
                    }
                    //cas ou le résultat à déjà une valeur
                    else if (resultat != "" && z != "")
                    {
                        resultat = z + " " + resultat;
                    }
                    else
                    {
                        resultat += z;
                    }
                    //réafectation des variable pour la suite eventuelle du programme
                    coef += 1;
                    x = "";
                    y = "";
                    z = "";
                }

            }
            //cas du négatif
            if (negatif)
            {
                resultat = "moins " + resultat;
            }
            return resultat;

        }
        public static string NombreEnLettres(double unNombre)
        {
            //arrondie de la valeur à 2 chiffre après la virgule
            unNombre = Math.Round(unNombre, 2, MidpointRounding.AwayFromZero);
            string unQualificatif = " centième";
            string uneChaine = Convert.ToString(unNombre);
            //on ajoute la valeur suivante dans le cas ou on n'a pas de chiffre après la virgule afin de ne pas corrompre le programme
            uneChaine += ",0";
            string[] desChaines = uneChaine.Split(',');
            string resultat = "";
            //cas ou l'on n'as qu'un chiffre après la virgule, le qualificatif deviens dixieme au lieu de centieme
            if (desChaines[1].Length == 1)
            {
                unQualificatif = " dixième";
            }
            //conversion des chaine avant et après virgule
            int avantVirgule = Convert.ToInt32(desChaines[0]);
            int apresVirgule = Convert.ToInt32(desChaines[1]);
            //cas ou la valeur est 0
            if (avantVirgule == 0 && apresVirgule == 0)
            {
                resultat = "zéro";
            }
            //cas d'un nombre avec l'entier égal à 0
            else if (avantVirgule == 0)
            {
                resultat = "zéro et " + NombreEnLettres(apresVirgule) + unQualificatif;
                if (apresVirgule > 1)
                {
                    resultat += "s";
                }
            }
            //cas ou l'on à qu'un nombre entier
            else if (apresVirgule == 0)
            {
                resultat = NombreEnLettres(avantVirgule);
            }
            else
            {
                resultat = NombreEnLettres(avantVirgule) + " et " + NombreEnLettres(apresVirgule) + unQualificatif;
                if (apresVirgule > 1)
                {
                    resultat += "s";
                }
            }
            return resultat;
        }
        // valeur en Decimal
        public static string NombreEnLettres(decimal unNombre)
        {
            double unNombreConverti = (double)unNombre;
            string resultat = NombreEnLettres(unNombreConverti);
            return resultat;
        }
        //cas valeur en float
        public static string NombreEnLettres(float unNombre)
        {
            double unNombreConverti = (double)unNombre;
            string resultat = NombreEnLettres(unNombreConverti);
            return resultat;
        }

        public static string NombreEnLettres(double unNombre, Monnaie uneMonnaie)
        {
            //arrondie de la valeur à 2 chiffre après la virgule
            unNombre = Math.Round(unNombre, 2, MidpointRounding.AwayFromZero);
            string resultat;
            string maMonnaie = "";
            string uneSousMonnaie = "";
            string uneChaine = Convert.ToString(unNombre);
            //on ajoute la valeur suivante dans le cas ou on n'a pas de chiffre après la virgule afin de ne pas corrompre le programme
            uneChaine += ",0";
            //séparation des chiffre avant et après la virgule
            string[] desChaines = uneChaine.Split(',');
            //cas ou l'on n'as qu'un chiffre après la virgule, on lui rajoute un 0
            if (desChaines[1].Length == 1)
            {
                desChaines[1] += "0";
            }
            int avantVirgule = Convert.ToInt32(desChaines[0]);
            int apresVirgule = Convert.ToInt32(desChaines[1]);
            //instanciation des monnaie et sous monnaie en fonction de la monnaie choisie
            if (uneMonnaie == Monnaie.Euro)
            {
                maMonnaie = " euro";
                uneSousMonnaie = " centime";
            }
            else if (uneMonnaie == Monnaie.Dollar)
            {
                maMonnaie = " dollar";
                uneSousMonnaie = " cent";
            }
            else if (uneMonnaie == Monnaie.Livre)
            {
                maMonnaie = " livre";
                if (apresVirgule <= 1)
                {
                    uneSousMonnaie = " penny";
                }
                else
                {
                    uneSousMonnaie = " pence";
                }
            }
            //passage de la sous monnaie au pluriel si le chiffre àprès la virgule est supérieur à 1 et que la monnaie n'est pas les livre:
            //un penny, deux pence
            if (apresVirgule > 1 && uneMonnaie != Monnaie.Livre)
            {
                uneSousMonnaie += "s";
            }
            //passage de la monnaie au pluriel quand la valeur avant la virgule est supérieur à 1
            if (avantVirgule > 1)
            {
                maMonnaie += "s";
            }
            //cas ou la valeur est 0
            if (avantVirgule == 0 && apresVirgule == 0)
            {
                resultat = "zéro" + maMonnaie;
            }
            //cas d'un nombre avec l'entier égal à 0
            else if (avantVirgule == 0)
            {
                resultat = "zéro" + maMonnaie + " et " + NombreEnLettres(apresVirgule) + uneSousMonnaie;
            }
            //cas ou l'on à qu'un nombre entier
            else if (apresVirgule == 0)
            {
                resultat = NombreEnLettres(avantVirgule) + maMonnaie;
            }
            else
            {
                resultat = NombreEnLettres(avantVirgule)+ maMonnaie + " et " + NombreEnLettres(apresVirgule) + uneSousMonnaie;
            }
            return resultat;
        }
        // valeur en Decimal
        public static string NombreEnLettres(decimal unNombre, Monnaie uneMonnaie)
        {
            double unNombreConverti = (double)unNombre;
            string resultat = NombreEnLettres(unNombreConverti, uneMonnaie);
            return resultat;
        }
        //cas valeur en float
        public static string NombreEnLettres(float unNombre, Monnaie uneMonnaie)
        {
            double unNombreConverti = (double)unNombre;
            string resultat = NombreEnLettres(unNombreConverti, uneMonnaie);
            return resultat;
        }
    }
}
