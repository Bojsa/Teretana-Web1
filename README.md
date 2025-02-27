Specifikacija zahteva
Potrebno je realizovati veb aplikaciju za informacioni sistem koji omogućava vođenje evidencije
fitnes centara. Aplikaciju koriste 3 grupe (uloge) korisnika: Posetilac, Trener i Vlasnik. Aplikacija
rukuje sa sledećim entitetima:
Korisnik
● Korisničko ime (jedinstveno)
● Lozinka
● Ime
● Prezime
● Pol
● Email
● Datum rođenja (čuvati u formatu dd/MM/yyyy)
● Uloga (Posetilac, Trener ili Vlasnik)
● Lista grupnih treninga na koje je korisnik prijavljen (ako korisnik ima ulogu Posetioca)
● Lista grupnih treninga na kojima je korisnik angažovan kao trener (ako korisnik ima
ulogu Trenera)
● Fitnes centar gde je korisnik angažovan (ako korisnik ima ulogu Trenera)
● Fitnes centri čiji je korisnik vlasnik (ako korisnik ima ulogu Vlasnika)
Fitnes centar
● Naziv
● Adresa u formatu: ulica i broj, mesto/grad, poštanski broj
● Godina otvaranja fitnes centra
● Vlasnik (veza sa klasom Korisnik)
● Cena mesečne članarine
● Cena godišnje članarine
● Cena jednog treninga
● Cena jednog grupnog treninga
● Cena jednog treninga sa personalnim trenerom
Grupni Trening
● Naziv
● Tip treninga (yoga, les mills tone, body pump itd. )
● Fitnes centar gde se održava trening (veza sa klasom Fitnes centar)
● Trajanje treninga (izraženo u minutima)
● Datum i vreme treninga (čuvati u formatu dd/MM/yyyy HH:mm)
● Maksimalan broj posetilaca
● Spisak posetilaca (lista Korisnika sa ulogom Posetilac koji su se prijavili da pohađaju
trening)
Komentar
● Posetilac koji je ostavio komentar
● Fitnes centar na koji se komentar odnosi
● Tekst komentara
● Ocena (na skali od 1 do 5)
Napomena: Entiteti koji su navedeni su obavezni i obavezno je da sadrže navedene
atribute. Dozvoljeno je dodati još entiteta kao i dopuniti postojeće entitete sa još atributa ako za
to imate potrebe.
Funkcionalnosti za implementaciju
Neprijavljeni korisnik
● Na početnoj strani može da gleda sve Fitnes centre (sortirani po nazivu rastuće) koji
postoje u sistemu u vidu tabele. Slika 1 predstavlja primer takvog tabelarnog prikaza.
Slika 1 - Primer tabelarnog prikaza fitnes centara
● Može da pretražuje fitnes centre po nazivu, adresi i godini otvaranja (za godinu
otvaranja omogućiti definisanje minimalne i maskimalne granice za vršenje pretrage po
godini otvaranja).
● Omogućiti kombinovanu pretragu tako što neprijavljeni korisnik unosi više parametara
pretrage i prikazuju mu se rezultati koji ispunjavaju sve unete parametre.
● Može da sortira fitnes centre po nazivu (opadajuće i rastuće), adresi (opadajuće i
rastuće) i godini otvaranja (opadajuće i rastuće).
● Klikom na dugme detalji prelazi se na stranu gde se vide sve informacije izabranog
fitnes centra (detaljni prikaz).
● Ispod detaljnog prikaza informacija izabranog fitnes centra prikazan je spisak (tabelarni
prikaz) predstojećih grupnih treninga (oni koji će se održati u budućnosti). Za svaki
grupni trening su navedene sve njegove informacije uključujući i datum i vreme
održavanja, maksimalan broj posetilaca i ukupan broj prijavljenih posetilaca do tog
trenutka.
● Ispod spiska svih grupnih treninga vidi sve komentare koje su Posetioci ostavljali za taj
fitnes centar.
● Registracija - registruje se na aplikaciju popunjavajući polja koja su za to predviđena i
nakon toga postaje Posetilac.
● Prijavljivanje na sistem - loguje se na sistem tako što unosi korisničko ime i lozinku, a
ako je prijava uspešna može da izvršava aktivnosti predviđene njegovom ulogom.
Prijavljeni korisnik
● Nakon što se korisnik prijavi, na početnoj strani vidi isti sadržaj (spisak fitnes centara)
kao i neprijavljeni korisnik i može da ih pretraži i sortira isto kao neprijavljeni korisnik.
● U skladu sa ulogom prijavljenog korisnika, sa ove stranice korisnik može otići na druge
stranice koje odgovaraju ulozi tog korisnika.
● Svaki prijavljeni korisnik može da pregleda svoj profil i uređuje ga.
● Prijavljeni korisnik može da radi sve isto što i neprijavljeni.
Spisak funkcionalnosti u zavisnosti od uloge:
Posetilac
● Može da se prijavi za posetu nekog treninga. Izborom jednog od fitnes centara sa
početne strane može videti spisak svih budućih grupnih treninga u tom fitnes centru.
Klikom na dugme pored nekog grupnog treninga može da se prijavi za učestvovanje na
izabranom treningu. Na svaki trening može da se prijavi maksimalno jednom (ne može
više puta da učestvuje u jednom terminu). Ako je prijavljen maksimalan broj učesnika za
neki grupni trening, onda ne može da se prijavi za učestvovanje na tom grupnom
treningu.
● Može da vidi spisak (tabelarni prikaz) svih ranijih grupnih treninga na kojima je
učestvovao.
● Može da pretražuje spisak svih ranijih grupnih treninga na kojima je učestvovao po
nazivu, tipu treninga i nazivu fitnes centra.
● Omogućiti kombinovanu pretragu tako što Posetilac unosi više parametara pretrage i
prikazuju mu se rezultati koji ispunjavaju sve unete parametre.
● Može da sortira spisak svih ranijih grupnih treninga na kojima je učestvovao po nazivu
(rastuće i opadajuće), tipu treninga (rasuće i opadajuće) i datumu i vremenu održavanja
treninga (rastuće i opadajuće).
● Može da ostavi komentar (sa ocenom i tekstom) na fitnes centar koji je ranije posetio
(podrazumeva se da je bio prijavljen na neki grupni trening koji se održao u tom fitnes
centru, tj. grupni trening se održao uz prisustvo Posetioca). Taj komentar biva vidljiv svim
korisnicima ako ga Vlasnik tog fitnes centra odobri.
Trener
● Kreira, modifikuje, pregleda i briše svoje grupne treninge.
○ Brisanje grupnog treninga je logičko.
○ Brisanje grupnog treninga nije dozvoljeno ako se neki Posetilac prijavio da
učestvuje u tom grupnom treningu.
○ Može da modifikuje i briše isključivo grupe treninge koji se još nisu održali, na
kojima je angažovan kao trener i u onom fitnes centru u kom je zaposlen.
○ Za svaki grupni trening koji kreira on je automatski postavjem kao trenier na tom
treningu i taj podatak nije moguće promeniti.
○ Grupni trening ne može da se kreira u prošlosti, već isključivo u budućnosti i to
najmanje 3 dana unapred.
● Može da pregleda sve grupne treninge koje je u prošlosti održao kao trener.
● Kod prikaza svojih grupnih treninga (predstojećih i završenih), može da izabere da za
neki grupni trening vidi spisak svih Posetilaca koji su se prijavili da učestvuju u treningu.
● Može da pretraži sve grupne treninge koje je u prošlosti održao kao trener po nazivu,
tipu treninga i datumu i vremenu održavanja (za datum i vreme održavanja omogućiti
definisanje maksimalne i minimalne granice za vršenje pretrage po godini otvaranja).
● Omogućiti kombinovanu pretragu tako što Trener unosi više parametara pretrage i
prikazuju mu se rezultati koji ispunjavaju sve unete parametre.
● Može da sortira spisak svih ranijih grupnih treninga na kojima je učestvovao po nazivu
(rastuće i opadajuće), tipu treninga (rasuće i opadajuće) i datumu i vremenu održavanja
treninga (rastuće i opadajuće)
Vlasnik
● Učitavaju se programski iz tekstualnog fajla i ne mogu se naknadno dodati
● Registruje nove trenere u svoj fitnes centar (u slučaju da Vlasnik poseduje više fitnes
centara, može da doda trenera kao zaposlenog u jedan od njih, tj. jedan trener može da
radi u tačno jednom fitnes centru)
● Kreira, modifikuje, pregleda i briše svoje fitnes centre.
○ Brisanje fitnes centra je logičko.
○ Brisanje fitnes centra nije dozvoljeno ako postoje grupni treninzi u budućnosti koji
će se održati.
○ Ako se obriše neki fitnes centar, svi treneri koji su zaposleni u tom fitnes centru
gube mogućnost da se prijave u aplikaciju.
● Može da blokira trenera nakon čega ovaj više ne može da se prijavi u aplikaciju.
● Kada Posetilac kreira komentar, Vlasnik može da ga odobri ili odbije.
○ Odobren komentar biva automatski vidljiv svima.
○ Odbijen komentar je vidljiv samo tom Vlasniku.
○ Mogu se odobriti/odbiti isključivo komentari na fitnes centar koji je taj Vlasnik
kreirao.
