# CurrenciesRates
Założenia:

1. API NBP oferuje kursy kupna i sprzedaży walut tylko w tabeli C, dlatego ta zastała użyta w aplikacji
2. Przykład wywołania endpointu {url}/currency-rate?currencyCode={waluta}&date={data}
3. Jeśli zapytanie do API jest o walutę z datą której nie ma w bazie - odpytuję bezpośrednio API NBP, zapisuję te dane w bazie i zwracam dane z API
4. Użyłam bazy danych sqlLite aby aplikacja mogła zostać uruchomiona na środowisku produkcyjnym jednym kliknięciem
Z uwagi na brak zaawanosowanej logiki biznesowej moja palikacja nie posiada warstwy domenowej