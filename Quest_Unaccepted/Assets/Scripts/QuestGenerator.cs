using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour {

    private string[] mQuestTable = new string[]
    {
        "Prend ma quete !",
        "Veuillez ramasser 2256 bleuets rose dans mon jardin.",
        "Pouvez-vous toucher votre coude avec votre langue s'il vous plaît ?",
        "Rendez-vous dans le volcan madit des entrailles unies pour occire le dragon Agrapoufrechlishunshtru et sauver lady Mary de Saint Antoine, reine des mondes, sauveuse des pauvres et des orphelins et maîtresse des gobelins nyphomanes.",
        "J'ai désespérément besoin que vous alliez récupérer mes pantoufles dans mon placard !",
        "J'ai perdu mon marteau, pouvez-vous aller le récupérer dans l'antre du Troll ? En récompense je vous donnerai un marteau !",
        "Apportez cette lettre de la plus haute importance à ma vieille grand-mère de l'atre côté de la rue.",
        "J'ai perdu mes lentilles, pouvez-vous m'aider à les retrouver dans le gravier de la carrière infinie ?",
        "J'ai besoin de toute urgence de 2,72 litres de bave de lama, dépéchez-vous d'aller m'en chercher !",
        "La danseuse de la taverne est malade, il faut que vous la remplaciez ! D'abord, équipez-vous de ce tutu...",
        "Par pitier, c'est une question de vie ou de mort, aidez moi ! Les toilettes sont bouchées !",
        "Olala, j'ai rendez-vous avec mon petit amis mais j'ai trop peur d'y aller seule, pouvez-vous m'accompagner à travers la moitié du pays pour aller le rejoindre ?",
        "Le village est en danger ! Pour le protéger vous devez tuer 50 sangliers.",
        "Tirez sur mon doigt.",
        "Empêcher le volcan d'exploser et d'ensevelir le pays sous les cendres éternelles !",
        "Je suis bloqué aux toilettes et il n'y a plus de paier toilette...",
        "J'ai besoin de vous pour aller chercher les 19 fèves de Xandar.",
        "Vous devez kidnapper la fille de Liam Neeson à tout prix !",
        "Le côté obscur vous appelle, tuez 10 enfants Jedi.",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Fermez cette fenêtre de quête !",
        "Vite ! Vous devez à tout prix éviter les personnages-non-joueur dans cette salle !",
        "Tutoriel : pour accepter une quête, cliquez sur \"Accepter\".Cliqez sur \"Accepter\" pour continuer.",
        "S'il vous plaît, faîte un beau gâteau au chocolat si délicat pour 4 à 6 personnes.",
        "J'ai besoin de toute urgence que vous me trouviez une animation de kaméhameha !",
        "Je n'aurais pas le temps de finir mon jeu de game jam, pouvez-vous m'aider ?",
        "Allez récuper les boules du voyant, il est de la plus grande importance que vous rameniez les deux !",
        "Pouvez-vous aller prier Chuck Norris pour qu'il revienne parmis les siens ?",
        "Trouvez quatres pommes de pin dans la forêt perdu dont on ignore où elle se trouve, les apporter a voyant dans le quartier dela mendiance pour en faire un parchemin de vérité grâce auquel vous devrez demander à ma femme si oui ou non elle m'a trompé avec le bûcheron."
    };

	public string generateQuest()
    {
        return mQuestTable[Random.Range(0, mQuestTable.Length - 1)];
    }
}
