# Cloner le projet :

Dans le bon dossier :

    git clone https://gitlab-ce.iut.u-bordeaux.fr/lpuyastier/club-innovation-projet.git
    cd club-innovation-projet/
    git switch Nom_De_La_Branche

# Sauvegarder le travail sur le serveur distant :

    git add *
    git commit -m "Le message à mettre"
    git push

Si des modifications ont été effectuées à distance, il faut pull avant de push.

# Récupérer le travail effectué sur le serveur distant :

Si aucune modification n'a été faite :

    git pull

Si vous avez des choses non sauvegardées sur votre machine, il faut add puis commit avant de pull.

Si le travail n'est pas important (déplacement d'un objet sur une scène ou autre broutille mineure) :

    git stash
    git pull

# Créer une branche :

Deux options : créer une branche depuis le gitlab (Repository --> Branches --> New Branch)
Ou :

    git switch Branche_A_Extraire
    git branch Nom_De_La_Nouvelle_Branch
    git push

Le git push n'est pas nécessaire, il permet juste de mettre à jour le gitlab afin d'y afficher la nouvelle branche.

# Changer de branche

    git switch Nom_De_La_Branche

# Récupérer le travail sur la branche main :

Étape 1 :

    git rebase main

Étape 2 : 
Prier. 

Si tout se passe bien, le rebase se fera sans difficultées. Sinon, des conflits à résoudre à la main peuvent arriver.

# Fusionner votre branche avec la branche main :

Depuis gitlab (Repository --> Branches --> Merge request)

