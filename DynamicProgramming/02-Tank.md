# 8.2 Tank

Nejprve si ze vstupních dat sestrojíme DAG, ve kterém sestrojíme orientovanou
hranu z nabídky `n1` do nabídky `n2`, pokud platí, že `n1.End - n2.Start >= 0`.
Následně ještě přidáme dva pomyslné vrcholy `start` a `end`, kde ze `start`
povede hrana do každého záznamu, který nemá předchůdce a do `end` povede hrana
z každého vrcholu, který nemá potomka. V každém vrcholu si ještě zapamatujeme
množství peněz, které za rezervaci dostaneme.

Následně graf projdeme pomocí BFS. Než ale začneme procházet, připravíme si
pro každý vrchol ještě aktuální součet maximálního ohodnocení cesty ze `start`u
a pointer na předchůdce. Projdeme všechny předchůdce aktuálního vrcholu a
vybereme z nich toho, který má maximální součet ohodnocení cesty. Následně tento
vrchol uložíme jako předchůdce aktuálního vrcholu a do mezisoučtu uložíme
součet předchůdce, ke kterému přičteme množství peněz v aktuálním vrcholu.

Po průchodu všech vrcholů nám v `end` zůstane maximální množství peněz, které
dokážeme za daný časový úsek vydělat. Zároveň dokážeme pomocí pointerů na
předchůdce zrekonstruovat cestu ze `start`u do `end` a tedy i vybrat ty
nejvyhodnější rezervace.