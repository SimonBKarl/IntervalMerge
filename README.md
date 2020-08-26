
# Interval Merge - Coding Task 2


## Rahmenbedingungen:
Bitte die Aufgabe selbstständig und allein lösen,
natürlich darf dabei Literatur und / oder das Internet benutzt werden.
Bitte teilen Sie uns Ihre Bearbeitungszeit mit.
Die Lösung hätten wir gern als GitHub Projekt.
Die Programmiersprache ist frei wählbar, wobei eine ‘gewöhnliche’ Sprache bevorzugt wäre.
Das Resultat muss von uns gebaut und ausgeführt werden können. Bitte entsprechende build-scripte oder Makefiles bereitstellen.
Eigene Annahmen und wichtige Implementierungsdetails bitte klar kommentieren.
Eventuelle sinnvolle Zwischenergebnisse dürfen gern als separater Git commit vorliegen.
Genauso wichtig wie das lauffähige Programm ist die Dokumentation (readme und code comments) der Lösungsidee und der einzelnen Programmteile und Tests.


Das Hauptziel ist es das wir erleben wie Sie Software in einem professionellen Umfeld entwickeln. Die gesamte Bearbeitungsdauer sollte max. 1-2 Tage sein.

## Aufgabe:

Implementieren Sie eine Funktion MERGE die eine Liste von Intervallen entgegennimmt und als Ergebnis wiederum eine Liste von Intervallen zurückgibt. Im Ergebnis sollen alle sich überlappenden Intervalle gemerged sein. Alle nicht überlappenden Intervalle bleiben unberührt.

Beispiel:
Input: [25,30] [2,19] [14, 23] [4,8]  Output: [2,23] [25,30]

Wie ist die Laufzeit Ihres Programms ? 
Wie kann die Robustheit sichergestellt werden, vor allem auch mit Hinblick auf sehr große Eingaben ?
Wie verhält sich der Speicherverbrauch ihres Programms ?



## Lösung

### Annahmen
    - Der Input erfolgt als List<Interval>.
    - Der Output soll aufsteigend sortiert sein. (Irrelevant, da implementierungsbedingt ohnehin eine sortierte Liste ausgegben wird.)

### Zu den Fragen
Die Laufzeit des Programms liegt im Schnitt bei O(n log n), im schlimmsten Fall bei O(n²). Dies ist durch die Sortierung des Inputs bedingt, denn die Merge-Operation an sich hat eine Laufzeit von O(n), die vorangehende Sortierung jedoch von O(n log n) - worst-case O(n²). Um auch bei sehr großen Eingaben eine performante Lösung, also O(n), gewährleisten zu können, könnte man voraussetzen, dass die Eingabe als aufsteigend sortierte Liste zu erfolgen hat. Der Speicherverbrauch ist in beiden Fällen O(n).

### Zum Programm
Das Programm stellt mehrer Input-Daten zur Verfügung, der von Ihnen genannte Input wird mit einem simplen [Return] oder einer 0 und dann [Return] verwendet. Mit der Eingabe [1...3] können vorbereitete Testdaten verwendet werden.
Trotz oben genannter Annahme ist ein simpler (nicht auslieferungsfähiger) Parser implementiert, der verwendet wird, wenn die Eingabe mit '[' beginnt. So können auch andere Inputs getestet werden (Ohne dass Sie diese im Code ergänzen müssen.), sollten Sie solche vorbereitet haben.

### Bearbeitungszeit: 2,5h