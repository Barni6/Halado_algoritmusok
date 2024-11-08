# Haladó Algoritmusok Projekt

Ez a projekt a **Haladó algoritmusok** kurzus keretében készült, és különféle optimalizációs és adatfeldolgozási feladatokat valósít meg fejlett algoritmusok segítségével. A megoldások célja az adott problémák hatékony és pontos megoldása különböző módszertanokkal.

## Megvalósított Feladatok

### 1. Függvényközelítés Particle Swarm Optimization (PSO) Algoritmussal
- **Feladat**: Lineáris, másodfokú és szinuszfüggvények közelítése egy általános modellhez.
- **Megoldás**:
  - A **PSO algoritmus** a természetben megfigyelt rajviselkedést szimulálja, és evolúciós alapokon működik.
  - A részecskék iteratív módon keresik a legjobb paramétereket, amelyek a célfüggvényt legjobban közelítik.
- **Eredmények**:
  - A program pontos közelítéseket ad lineáris és másodfokú függvények esetén.
  - A szinuszfüggvények esetén Fourier-sor alapú közelítést alkalmaz.

### 2. Képszegmentálás k-means Clustering Algoritmussal
- **Feladat**: Képek homogén színű régiókra bontása k-means clustering segítségével.
- **Megoldás**:
  - A kép minden pixelét a színük alapján klaszterekbe rendezi.
  - Az algoritmus iteratívan frissíti a klaszterközéppontokat, hogy minimalizálja a távolságot a csoportokon belül.
- **Eredmények**:
  - Szegmentált képek, ahol a pixelek 3 vagy 5 különböző csoportba kerülnek.
  - A kimeneti képek jól mutatják a színek alapján létrejött csoportosításokat.

### 3. Travelling Salesman Probléma Genetikus Algoritmussal
- **Feladat**: A legjobb útvonal meghatározása a városok között, minimális teljes távolság mellett.
- **Megoldás**:
  - **Genetikus algoritmus**, amely evolúciós biológiai elvek (keresztezés, mutáció) alapján működik.
  - Az algoritmus iterációk során optimalizálja a megoldást.
- **Eredmények**:
  - Az algoritmus közel optimális útvonalakat talál.
  - Tesztadatok az internetről letöltött városlistákon kerültek alkalmazásra.

## Technológiák

### Nyelv
- **C#**

### Könyvtárak és Eszközök
- **System.Drawing**: Képfeldolgozáshoz.
- **System.IO**: Adatbeolvasáshoz és fájlkezeléshez.

## Használati Útmutató

### Függvényközelítés
1. Nyisd meg a `Program.cs` fájlt.
2. Aktiváld a `#region FunctionApproximation` szekciót.
3. Állítsd be a paramétereket (`numParticles`, `numIterations`, stb.).
4. Futtasd a programot a legjobb paraméterek meghatározásához.

### Képszegmentálás
1. Nyisd meg a `Program.cs` fájlt.
2. Aktiváld a `#region ImageSegmentation` szekciót.
3. Add meg a bemeneti és kimeneti kép útvonalait.
4. Futtasd a programot a szegmentált kép generálásához.

### Travelling Salesman Probléma
1. Nyisd meg a `Program.cs` fájlt.
2. Aktiváld a `#region TravellingSalesman` szekciót.
3. Add meg a távolságmátrix fájl nevét.
4. Futtasd a programot a legjobb útvonal meghatározásához.

## Példa Képernyőképek

### Függvényközelítés PSO Algoritmussal
![Függvényközelítés](images/lin.PNG)
![Függvényközelítés](images/kvad.PNG)
![Függvényközelítés](sin.PNG)

### Képszegmentálás
Bemenet
![Bemenet](images/bem.PNG)
3 klaszter
![Képszegmentálás 3 klaszterrel](images/3.PNG)
5 klaszter
![Képszegmentálás 5 klaszterrel](images/5.PNG)

### Travelling Salesman Probléma

## Megjegyzések

- A kód moduláris szerkezetű, így egyes algoritmusok könnyen adaptálhatók más feladatokra.
- A függvényközelítés vizualizálásához Python alapú eszközök is használhatók.

