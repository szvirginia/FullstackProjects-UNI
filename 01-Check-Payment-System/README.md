## 🏦 Csekkbefizetési Rendszer - Munkalap

🏗️ Előkészítés (15 perc)

    [ ] git init (ha még nincs)

    [ ] dotnet new webapi -n BACKEND futtatása a mappában.

    [ ] FRONTEND mappa létrehozása, benne index.html, style.css, app.js.

    [ ] Backend: CORS beállítása a Program.cs-ben (hogy a JS elérje az API-t).

🧠 Backend Fejlesztés (45 perc)

    [ ] Model: Payment osztály létrehozása (Név, Összeg szám, Összeg szöveg, Dátum).

    [ ] Logika: A "Magyar szöveg -> Szám" algoritmus megírása.

        Tipp: Egy szótárban (Dictionary) tárolhatod az alapneveket (egy, kettő... tíz, húsz... ezer).

    [ ] Controller: POST végpont létrehozása, ami:

        Megkapja a befizetést.

        Lefuttatja az algoritmust a szöveges összegen.

        Összehasonlítja a kapott számmal.

        Ha nem egyezik: BadRequest("Hibás tranzakció").

        Ha egyezik: Hozzáadja egy listához és visszaküldi az összes eddigi sikeres befizetést.

🎨 Frontend Fejlesztés (45 perc)

    [ ] HTML: Bootstrap űrlap (inputok: text, number, text, date) és egy üres <tbody> a táblázatnak.

    [ ] JS: fetch() hívás írása a "Befizetés" gombra.

    [ ] JS: A visszakapott lista megjelenítése táblázatban.

    [ ] JS Logic: Megkeresni az utolsó elemet a listában, és a nevéhez egy <span class="badge bg-danger">Legutóbbi</span> elemet fűzni.

🧪 Tesztelés és Finomítás (15 perc)

    [ ] Hibás összegnél piros hibaüzenet megjelenítése.

    [ ] Validálás: ne lehessen üres mezőket elküldeni.

    [ ] Legalább 20 commit meglétének ellenőrzése (git log --oneline).
