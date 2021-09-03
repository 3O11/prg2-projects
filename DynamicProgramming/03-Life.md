# 8.3 Life

Mapu města si do paměti uložíme jako graf, kde křižovatky budou vrcholy a ulice
budou hrany. V každém vrcholu si uložíme, kdo je zrovna na tahu a v každé hraně
si uložíme skóre dané ulice pro oba účastníky.

Následně pro každou křižovatku vybereme nejlepší možnou zpětnou hranu pro
účastníka, který na ní rozhoduje. Takto vybrané ulice nám následně vytvoří nový
graf, kde budou pouze nejvýhodnější hrany pro dané hráče. Nakonec z cíle
spustíme vyhledávání nejlepší cesty ke startu na novém grafu. Budeme postupovat
tak, že půjdeme vždy po nejlepší ulici, dokud nedojdeme do startu.