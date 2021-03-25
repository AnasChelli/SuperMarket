# SuperMarket
Une des problématiques rencontrées avec le paiement en espèces est le rendu de monnaie : comment rendre une somme donnée de façon optimale, c'est-à-dire avec le nombre minimal de pièces et billets ? C'est un problème qui se pose à chacun de nous quotidiennement, à fortiori aux caisses automatiques.

Dans cet exercice, on vous demande d’essayer de trouver une solution optimale pour rendre la monnaie dans un cas précis : quand une caisse automatique ne contient que des pièces de 2€, des billets de 5€ et de 10€.

Pour simplifier le problème, nous considérerons que toutes ces pièces et billets sont disponibles en quantité illimitée.

Voici quelques exemples de rendu de monnaie :

Monnaie à rendre

Solutions possibles

Solution optimale

1

Impossible

Impossible

6

2 + 2 + 2

2 + 2 + 2

10

2 + 2 + 2 + 2 + 2

5 + 5

10

10

9223372036854775807

...

(10 * 922337203685477580) + 5 + 2


Le rendu de monnaie est exprimé par un objet Monnaie . Cet objet a 3 propriétés : piece2, billet5 et billet10 qui, respectivement, stockent le nombre de pièces de 2€, de billets de 5€ et de billets de 10€.

Par exemple, si on reprend l’exemple n°2 du tableau (6€), on devrait obtenir un objet Monnaie avec :

piece2 vaut 3 (3 pièces de 2€)
billet5 vaut 0 (pas de billet de 5€)
billet10 vaut 0 (pas de billet de 10€)
Implémentez la méthode monnaieOptimale(long s) qui retourne un objet Monnaie contenant les pièces et billets dont la somme vaut s. S’il est impossible de rendre la monnaie (comme dans l’exemple n°1), retournez null.

Pour obtenir un maximum de points votre solution devra toujours rendre la monnaie quand c’est possible et avec le nombre minimal de pièces et billets.

Données : s est toujours un entier (long) strictement positif inférieur ou égal à 9223372036854775807
