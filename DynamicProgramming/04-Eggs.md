# 8.4 Eggs

Nejprve si rozebereme triviální případy. Pokud máme jenom jedno vejce a budovu
o `n` patrech, budeme potřebovat až `n` pokusů k tomu, abychom zjistili, kde se
rozbije. Pokud máme budovu, která má 1 patro nebo 0 pater, budeme potřebovat 1,
resp. 0 pokusů.

Následně musíme rozebrat případy, které mohou nastat po hození vejce z 
`i`-tého patra. V prvním případě se vejce rozbije, máme tady o jedno vejce
méně a víme, že není potřeba testovat žádná vyšší patra, budeme tedy zkoušet
znovu s rozdílem, že budeme mít o jedno vejce méně a budeme zkoušet pouze prvních `i-1` pater. V druhém případě se vejce nerozbije, což znamená, že
budeme zkoušet už pouze posledních `n-i` pater(kde `n` je celkový počet pater).
Jelikož musíme počítat s nejhorší možnou variantou, musíme z těchto dvou
případů vzít ten, který trvá více pokusů.

Nyní si ještě musíme rozmyslet to, že se vejce může rozbít na různých patrech,
musíme tedy vyzkoušet, že se rozbilo vejce pro každé patro a ze všech výsledků
nakonec vybrat minimum, protože všechny cesty se doberou ke stejnému výsledku,
ale některým to bude trvat déle než jiným.

Takto jsme vlastně rozebrali rekurzivní algoritmus, který se bude vnořovat,
dokud nenarazí na některý z triviálních případů. Problém tohoto algoritmu je,
že se v něm mnohokrát opakují stejná rekurzivní volání. Tento problém ale
můžeme vyřeřit tak, že si vytvoříme 2D tabulku o velikosti
`[#vajec + 1]x[#pater + 1]`, kterou vlastně můžeme nahradit rekurzivní volání,
jakmile zaplníme všechny indexy odpovídající triviálním případům. Následně už
bude stačit, když budeme tabulku doplňovat postupně od triviálních případů, kde
výsledek dostaneme na indexu `[#vajec][#pater]` po doplnění celé tabulky.