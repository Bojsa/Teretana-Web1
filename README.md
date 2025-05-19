# 🏋️‍♂️ Fitness Center Management Web App

Web aplikacija za vođenje evidencije fitnes centara, izrađena kao projekat za kurs *Primenjeno softversko inženjerstvo (2021/2022)*.

## ✨ Glavne funkcionalnosti

* Višekorisnička podrška: **Posetilac**, **Trener**, **Vlasnik**
* Prijava na grupne treninge i komentarisanje centara
* Zakazivanje i upravljanje treninzima (Treneri)
* Upravljanje fitnes centrima i korisnicima (Vlasnici)
* Smart pretraga i sortiranje podataka
* Skladištenje svih podataka u **JSON fajlovima**

---

## 👥 Uloge i mogućnosti

### 🔹 Neprijavljeni korisnik

* Prikaz svih fitnes centara u tabelarnom prikazu
* Pretraga po nazivu, adresi i godini otvaranja
* Kombinovana pretraga po više kriterijuma
* Sortiranje po nazivu, adresi i godini otvaranja
* Detaljan prikaz fitnes centra, predstojećih treninga i komentara
* Registracija i prijava u sistem

### 🔸 Posetilac

* Prijava na buduće grupne treninge (jednom po terminu, ako ima mesta)
* Istorija prisustvovanih treninga
* Pretraga i sortiranje istorije po više kriterijuma
* Komentarisanje i ocenjivanje fitnes centara koje je posećivao
* Komentari postaju vidljivi nakon odobrenja vlasnika

### 🔸 Trener

* Kreiranje, izmena i logičko brisanje treninga

  * Nije moguće brisati trening ako postoje prijavljeni posetioci
  * Nije moguće kreirati trening u prošlosti, već minimum 3 dana unapred
* Prikaz svojih prethodnih i budućih treninga
* Uvid u spisak prijavljenih posetilaca za svaki trening
* Pretraga i sortiranje treninga po više parametara

### 🔸 Vlasnik

* Upravljanje sopstvenim fitnes centrima (kreiranje, izmena, logičko brisanje)

  * Nije dozvoljeno brisanje ako postoje predstojeći treninzi
* Dodavanje i blokiranje trenera
* Moderacija komentara (odobravanje/odbijanje)

  * Samo komentari na sopstvene centre

---

## 🧱 Entiteti sistema

### ✅ Korisnik

* Korisničko ime (jedinstveno), lozinka, ime, prezime, pol, email, datum rođenja, uloga
* Dodatni podaci u zavisnosti od uloge (spisak treninga, fitnes centar, vlasništvo)

### ✅ Fitnes centar

* Naziv, adresa, godina otvaranja, vlasnik, cene članarina i treninga

### ✅ Grupni trening

* Naziv, tip, trajanje, datum i vreme, fitnes centar, maksimalan broj posetilaca, lista prijavljenih

### ✅ Komentar

* Posetilac koji komentariše, fitnes centar, tekst komentara, ocena (1–5)

---

## ⚙️ Tehnologije

* **C#**
* **ASP.NET MVC 5**
* **HTML / CSS**
* **JavaScript / jQuery**
* **JSON (za skladištenje podataka)**
* **GitLab (verzionisanje)**

---

## 🚀 Pokretanje projekta

> Aplikacija se pokreće pomoću **IIS Express-a** u Visual Studio okruženju.

1. Kloniraj repozitorijum
2. Otvori rešenje u Visual Studio
3. Pokreni aplikaciju (F5)

---

## 📁 Organizacija koda

```
/Models        → klase entiteta
/Controllers   → MVC kontroleri
/Views         → Razor pogledi
/Data          → JSON fajlovi sa podacima
/Scripts       → JavaScript kod (jQuery)
/Content       → CSS stilovi
```

---

## ✅ Napomene

* Komentari se prikazuju tek nakon odobrenja od strane vlasnika
* Treneri i vlasnici imaju pristup isključivo sopstvenim podacima
* Aplikacija koristi **logičko brisanje** umesto fizičkog

---

## 📸 Slike i video (opciono)

Dodaj slike aplikacije u `screenshots/` folder i ubaci ih ovde, npr:

```md
![Prikaz fitnes centara](screenshots/fitness-centers-table.png)
```

---
