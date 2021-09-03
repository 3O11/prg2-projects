# 8.1 Keys

Úlohu vyřešíme jednoduše s pomocí matice. Velikost matice
bude `[#Počet zubů]x[#Počet možných hloubek zářezů]`.
Začneme v prvním sloupci, který zaplníme ve všech pozicích
zářezů číslem 1, protože se do každého zářezu dostaneme na
počátku právě jedním způsobem. V každém dalším sloupci do
aktuální hodnoty sečteme všechny tři předcházející hodnoty,
pro které platí, že
`|číslo aktuálního zářezu - číslo předcházejícího zářezu| <= 1`.
Jakmile zaplníme poslední sloupec, sečteme v něm všechny
hodnoty. Výsledný součet je počet všech unitkátních klíčů,
které umíme se zadanými pravidly vytvořit.

Řešení můžeme ještě vylepšit tím, že nepoužijeme matici, ale
budeme v paměti držet vždy pouze dva sloupce celé matice.
Toto můžeme udělat proto, že jakmile jsme např. ve třetím
sloupci, hodnoty v prvním již nikdy nepoužijeme.

(Úlohu jsem naimplementoval v soubory Keys.cs)