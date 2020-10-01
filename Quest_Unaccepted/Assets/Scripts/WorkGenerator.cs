using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkGenerator {

    private readonly string[] workTable = new string[] 
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

    public string GenerateWork()
    {
        return (workTable[Random.Range(0, workTable.Length - 1)]);
    }
}
