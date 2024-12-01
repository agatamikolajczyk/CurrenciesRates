# CurrenciesRates
Założenia:

1. API NBP oferuje kursy kupna i sprzedaży walut tylko w tabeli C, dlatego ta zastała użyta w aplikacji

2. NBP aktualizuje tabelę A w każdy dzień roboczy między godziną 11:45, a 12:15. Zadanie cykliczne w mojej aplikacji będzie uruchamiane codziennie o 12:15 i będzie pobierać kurs walut z dnia bieżącego
3. Przykład wywołania endpointu {url}/currency-rate?currencyCode={waluta}&date={data}

Z uwagi na brak zaawanosowanej logiki biznesowej moja palikacja nie posiada warstwy domenowej