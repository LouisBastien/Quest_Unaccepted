using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkGenerator : MonoBehaviour {

    private string[] mWorkTable = new string[] 
    {
        "Forgeron",
        "Artisan",
        "Coiffeur",
        "Abateur",
        "Apothicaire",
        "Arpenteur",
        "Bourreau",
        "Buvetier",
        "Boursier",
        "cartier",
        "champion",
        "cellérier",
        "courtier",
        "emmancheur",
        "émouleur",
        "fanier",
        "fermaillier",
        "fienseur",
        "fournier",
        "fourbisseur",
        "gravelier",
        "harengier",
        "haubergier",
        "laineur",
        "lunetier",
        "marinier",
        "merrain",
        "nattier",
        "panelier",
        "patinier",
        "physicien",
        "sommelier",
        "succentre",
        "virolier",
        "talemenier",
        "vinetier",
        "platier",
        "regrattier",
        "tassetier",
        "maire",
        "oubloyer",
        "péagier",
        "lormier"
    };

    public string generateWork()
    {
        return (mWorkTable[Random.Range(0, mWorkTable.Length - 1)]);
    }
}
