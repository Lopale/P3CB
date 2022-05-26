using System;
using System.Collections.Generic;
using System.Text;

/* Basé sur le Replay DLC 87 - Coder un Service Locator en CSharp */

    public static class ServiceLocator // Static indique que l'on a pas besoin de l'instancier, pas besoin de new (les membres doivent être static) mais on peut en appeler directement les méthode
    {

        // Dictionnaire pour lister les services
        private static readonly Dictionary<Type, object> listServices = new Dictionary<Type, object>(); /* https://docs.microsoft.com/fr-fr/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0 */
        // readonly permet de ne pas le modifier / remplacer via une nouvelle instance

        public static void RegisterService<T>(T service) // Enregistrer les service
        {
            listServices[typeof(T)] = service;
        }

        public static T GetService<T>() // Récuperer les services
        {
            return (T)listServices[typeof(T)];
        }
        //        

        // Service score
        //ScoreService.cs

        // Service font 

        // Service Taille d'écran

        // Service Controle
    }
