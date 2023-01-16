#include <iostream>
#include <vector>
#include <unordered_map> //conteneur permettant de stocker des paires de clés
#include <algorithm>

using namespace std;

// Structure représentant un chantier
struct Chantier {
  int id; // Identifiant unique du chantier
  vector<string> materielsNecessaires; // Liste des matériels nécessaires pour le chantier
  int nombreEmployes; // Nombre d'employés nécessaires pour le chantier
  int dateFin; // Date de fin du chantier
};

// Structure représentant l'emploi du temps
struct EmploiDuTemps {
  vector<Chantier> chantiers; // Liste des chantiers dans l'emploi du temps
};

// Fonction qui vérifie si un chantier est valide pour l'emploi du temps donné
// en prenant en compte les contraintes de disponibilité des matériels et des employés
bool estChantierValide(const Chantier& chantier, const EmploiDuTemps& emploiDuTemps,
                      const unordered_map<string, int>& stockMateriels, int nombreEmployesDisponibles) {
  // Vérifie si le nombre d'employés demandés est disponible
  if (chantier.nombreEmployes > nombreEmployesDisponibles) {
    return false;
  }

  // Vérifie si tous les matériels nécessaires sont disponibles
  for (const string& materiel : chantier.materielsNecessaires) {
    if (stockMateriels.find(materiel) == stockMateriels.end() || 
        stockMateriels.at(materiel) == 0) {
      return false;
    }
  }

  return true;
}

// Fonction qui met à jour l'emploi du temps et les ressources disponibles en fonction d'un chantier
// qui vient d'être ajouté à l'emploi du temps
void mettreAJourEmploiDuTemps(EmploiDuTemps& emploiDuTemps, 
                               unordered_map<string, int>& stockMateriels, int& nombreEmployesDisponibles,
                               const Chantier& chantier) {
  // Ajoute le chantier à l'emploi du temps
  emploiDuTemps.chantiers.push_back(chantier);

  // Met à jour les matériels disponibles en enlevant ceux qui ont été utilisés pour le chantier
  for (const string& materiel : chantier.materielsNecessaires) {
    stockMateriels[materiel]--;
  }

  // Met à jour le nombre d'employés disponibles en enlevant ceux qui ont été affectés au chantier
  nombreEmployesDisponibles -= chantier.nombreEmployes;
}


// Fonction récursive qui gère l'emploi du temps en utilisant l'algorithme de backtracking chronologique : [] permet de faire une fonction de comparaison
bool gererEmploiDuTemps(EmploiDuTemps& emploiDuTemps, vector<Chantier>& chantiersRestants,
                        unordered_map<string, int>& stockMateriels, int nombreEmployesDisponibles) {
  // Si tous les chantiers ont été affectés à l'emploi du temps, c'est que la solution est valide
  if (chantiersRestants.empty()) {
    return true;
  }

  // Trie les chantiers restants par ordre chronologique
  sort(chantiersRestants.begin(), chantiersRestants.end(), 
       [](const Chantier& c1, const Chantier& c2) { return c1.dateFin < c2.dateFin; });

  // Essaye chaque chantier restant dans l'ordre chronologique
  for (int i = 0; i < chantiersRestants.size(); i++) {
    Chantier chantier = chantiersRestants[i];

    // Si le chantier est valide pour l'emploi du temps courant, on le met à jour
    if (estChantierValide(chantier, emploiDuTemps, stockMateriels, nombreEmployesDisponibles)) {
      mettreAJourEmploiDuTemps(emploiDuTemps, stockMateriels, nombreEmployesDisponibles, chantier);

      // Essaye de mettre à jour l'emploi du temps avec les chantiers restants
      vector<Chantier> chantiersRestantsSansChantier = chantiersRestants;
      chantiersRestantsSansChantier.erase(chantiersRestantsSansChantier.begin() + i);
      if (gererEmploiDuTemps(emploiDuTemps, chantiersRestantsSansChantier, stockMateriels, nombreEmployesDisponibles)) {
        return true;
      }

      // Si la solution n'est pas valide, on annule les modifications faites à l'emploi du temps et aux ressources
      emploiDuTemps.chantiers.pop_back();
      for (const string& materiel : chantier.materielsNecessaires) {
        stockMateriels[materiel]++;
      }
      nombreEmployesDisponibles += chantier.nombreEmployes;
    }
  }

  // Si aucune solution valide n'a été trouvée avec les chantiers restants, on retourne false
  return false;
}
int main() {
  // Initialise l'emploi du temps et les ressources de l'entreprise
  EmploiDuTemps emploiDuTemps;
  unordered_map<string, int> stockMateriels = {{"tournevis", 20}, {"marteaux", 15}, {"vis", 20}, {"camion",3},{"échelle",2}};
  int nombreEmployesDisponibles = 60;

  // Initialise la liste des chantiers de l'entreprise
  vector<Chantier> chantiers = {
    {1, {"tournevis", "marteaux"}, 10, 30},
    {2, {"vis"}, 5, 20},
    {3, {"tournevis", "vis", "marteaux"}, 12, 25},
    {4, {"tournevis", "vis"}, 8, 15},
    {5, {"tournevis", "vis", "camion"}, 8, 27}
  };
  // Appelle la fonction récursive pour gérer l'emploi du temps
  bool solutionTrouvee = gererEmploiDuTemps(emploiDuTemps, chantiers, stockMateriels, nombreEmployesDisponibles);

  if (solutionTrouvee) {
    cout << "Emploi du temps trouvé :" << endl;
    for (const Chantier& chantier : emploiDuTemps.chantiers) {
      cout << "Chantier " << chantier.id << ": ";
      cout << "Date de fin = " << chantier.dateFin << ", ";
      cout << "Matériels nécessaires = [";
      for (const string& materiel : chantier.materielsNecessaires) {
        cout << materiel << " ";
      }
      cout << "]" << endl;
    }
  } else {
    cout << "Aucun emploi du temps valide n'a été trouvé car vous manquez soit d'employées ou bien de stocks de matériels !" << endl;
  }

  return 0;
}


