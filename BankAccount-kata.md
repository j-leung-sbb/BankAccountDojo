# Bank Account Kata – Business Rules & Functionaliteiten

## Basisgedrag (MVP)

- [x] Nieuwe account start met saldo 0
- [x] Geld storten verhoogt saldo
- [x] Meerdere stortingen worden opgeteld
- [x] Geld opnemen verlaagt saldo
- [x] Combinatie van storten en opnemen werkt correct

---

## Basis business rules

- [x] Je mag niet meer opnemen dan je saldo
- [x] Bij overschrijding wordt een exception gegooid
- [x] Exact saldo opnemen resulteert in saldo 0

---

## Configuratie / Variaties

- [x] Account kan ingesteld worden om negatieve balans toe te staan
- [x] Als negatieve balans is toegestaan, mag saldo onder 0 komen

---

## Input validatie (optioneel, volgende stap)

- [x] Negatieve stortingen zijn niet toegestaan
- [x] Negatieve opnames zijn niet toegestaan
- [x] Storting van 0 verandert niets
- [x] Opname van 0 verandert niets

---

## Numerieke nauwkeurigheid

- [x] Decimal bedragen worden correct verwerkt (bijv. 10.50)
- [x] Kleine bedragen (bijv. 0.01) werken correct

---

## Robuust gedrag

- [ ] Meerdere stortingen en opnames door elkaar blijven correct
- [ ] Saldo blijft consistent na veel operaties

---

## Transacties (uitbreiding)

- [x] Nieuwe account heeft geen transacties
- [x] Storting wordt opgeslagen als transactie
- [x] Opname wordt opgeslagen als transactie
- [x] Transacties bevatten bedrag en type (deposit/withdraw)
- [ ] Transacties worden in volgorde bewaard

---

## Statement / Overzicht

- [ ] Account kan een overzicht (statement) geven
- [ ] Statement bevat alle transacties
- [ ] Statement toont huidig saldo
- [ ] Statement toont transacties in juiste volgorde

---

## Verdere uitbreidingen (advanced / optioneel)

- [ ] Overdraft limiet instellen
- [ ] Transfers tussen accounts
- [ ] Account eigenaar / metadata
- [ ] Tijdstempels op transacties
- [ ] Formatting van statement (bijv. printen)

---

## Verdere uitbreidingen (advanced 2.0)

- [ ] Alle mogelijk acties via een API endpoint ontsluiten
- [ ] Maak een endpoint die je huidige balans teruggeeft ofzo
- [ ] Maak een endpoint -> GET -> GetStatement

---

## Dojo tips

- Werk altijd in kleine stappen (red → green → refactor)
- Voeg per test slechts één nieuw concept toe
- Houd implementatie zo simpel mogelijk
- Laat tests het ontwerp sturen
