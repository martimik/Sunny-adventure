# Sunny Adventure

Tässä dokumentaatiossa käsittelään kurssille ttos0700 - peliohjelmointi tuotettua harjoitustyötä. 
Lopputyön tavoitteena oli luoda yksinkertainen peli, jossa hyödynnetään erilaisia pelimoottorin ominaisuuksia.
Itse pelimoottoriksi valikoitui Unity (v. 2018.3.12f1), jonka sisäänrakennettuihin ominaisuuksiin peli pääasiallisesti nojaa. Pelin sekä dokumentaation tekijä: Mikko Martikainen.

Omien scriptien osuus pelissä jäi suhteellisen vähäiseksi, sillä peliin suunnitellut mekaniikat eivät niitä enempää vaatineet. Hahmon liikkumisessa hyödynsin valmista scriptiä ("CharacterController2D"), jonka functioiden avulla pelaajan liikkumista kontrolloiva scripti kirjoitettiin. Unityn "Update"-funktiossa käyttäjän syöte luetaan, kerrotaan asetetulla runSpeed-muuttujalla ja tulos tallennetaan erilliseen muuttujaan. Unityn "OnFixedUpdate"-funktiossa tämä muuttuja kerrotaan vielä ajalla, jotta liikkuminen on tasaista ja lähetetään controllerin "Move"-funktiolle. Samalla kyseiselle funktiolle syötetään myös tieto siitä, yrittääkö käyttäjä hypätä tai kyykistyä samaan aikaan bool-muuttujien muodossa. Nämä tarkistetaan ja asetetaan "Update"-funktiossa jossa syötettä testataan. Näiden muuttujien avulla hallitaan myös hahmon animaattoria. Mikäli käyttäjän nopeus on suurempi kuin nolla, käyttäjä hyppää tai kyyykistyy käynnistetään kyseistä scenaariota vastaava animaatio. "OnLanding"-funktiossa jota kutsutaan pelaajan osuessa taas maahan hyppäysanimaatio pysäytetään ja funktiossa "OnCrouching" jota kutsutaan pelaajan kyykistyessä käynnistetään kyykistymisanimaatio. Jotta scripti tietäisi mikä on "maata", on haluttujen gameObjectien layeriksi asetettu "Obstacle". 

Tästä scriptistä löytyy myös funktiot esteiden kanssa törmäämiseen, hahmon kuolemiseen, maalin saavuttamiseen ja seuraavan tason lataamista varten. Näissä käytin Unityn funktioita "OnCollisionEnter2D" ja "OnTriggerEnter2D" törmäysten seuraamiseen ja gameObjectien tägejä niiden varmistamiseen. Pelaajan kuollessa partikkelieffekti käynnistetään ja pelaajan positio muutetaan vastaamaan respawnin positiota, jolloin pelaaja siirtyy tason alkuun. Maaliin saavuttaessa tarkistetaan onko tasoja vielä jäljellä ja mikäli näin on, seuraava taso ladataan Unityn SceneManagerin avulla. Seuraavan tason numero tallennetaan "OnDisable"-funktiossa PlayerPrefs-tiedostoon, joka suoritetaan kun scene suljetaan. Vastaavasti seuraavan tason numero tallennetaan muuttujaan "OnEnable"-funktiossa, joka suoritetaan kun scene ladataan. Painikkeita varten on myös omat scriptinsä, joissa tasojen latausta hallitaan.

Pelin optimoinnissa hyödynsin Unityn ominaisuutta asettaa objecteja stattiseksi, jolloin niiden sijaintitiedot voidaan laskea valmiiksi sillä muutosta ei tapahdu. Tälläisiksi objecteiksi asetin kaiken muun paitsi pelaajan, joka on ainoa liikkuva peliobjecti pelissä.

Animaatioiden luomisessa käytettiin Unityn animaattoria, jonka avulla jokaiseen hahmon tilaan luotiin animaatio spritesheetistä löytyvillä kuvilla. Animaatioiden ajamisesta puolestaan vastaa Unityn Animator, joka aikaisemmin käsiteltyjen ehtojen mukaan ajaa niitä. Pelaajan kuolemista varten luotiin myös partikkelieffecti, joka käynnistetään "Death"-funktiossa. Partikkelieffectin oleellisimmat muutokset ovat sen muuttaminen purskeeksi jolloin partikkeleita syntyy vain hetkellisesti, sekä collisionin lisääminen partikkeleihin. Pelistä löytyvien tekstien animoinnissa objectien scaalausta muutetaan ajan kuluessa.

Eniten ongelmia aiheutti grafiikan hyödyntäminen Unityn tilemapin yhteydessä, sillä erikokoisten ja muotoisten kuvien sovittaminen tilemappiin osoittautui hankalaksi ja aikaavieväksi. Lopulta päädyin tilesettiin, joka sisälsi vain neliön muotoisia "palikoita". Toisessa tasossa mahdollisuus kulkea tiettyjen esteiden läpi on tarkoituksenmukaista, eikä virhe. Myös ruohoon kuoleminen tietyissä kohdissa on tarkoituksenmukaista.

Mielestäni lopputyö onnistui hyvin aikaresursseihin nähden. Pelin mekaniikat toimivat halutusti, 
core-loop löytyy, bugit on karsittu pois ja myös grafiikka/musiikki on huomioitu. Pelissä on selkeä taivoite ja toimintaperiaate päästä eteenpäin ja voittaa. Mikäli kehitykseen olisi ollut enemmän aikaa, pelin mekaniikkoja olisi voinut vielä hioa ja lisätä erilaisia esteitä sekä tasoja. 

Lopputyöhön käytetut aikaresurssit: +40h.

Arvosanaehdotus: 4.

Linkit käytettyihin ilmaisiin resursseihin:

* https://opengameart.org/content/bunny-rabbit-lpc-style-for-pixelfarm
* https://assetstore.unity.com/packages/2d/characters/sunny-land-103349?aid=1101lPGj&utm_source=aff
* https://github.com/Brackeys/2D-Character-Controller

Pelissä käytetyn musiikin on luonut Arttu Heinonen, joka antoi oikeuden käyttää tuotostaan projektissa.