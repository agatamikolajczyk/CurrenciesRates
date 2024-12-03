# CurrenciesRates

To repozytorium zawiera aplikację napisaną w technologii .NET, która umożliwia pobieranie kursów walut (zakupu i sprzedaży) w stosunku do polskiego złotego (PLN). Aplikacja pobiera dane z Narodowego Banku Polskiego (NBP) i przechowuje je w bazie danych, umożliwiając ich późniejsze zapytania. API zostało zaprojektowane jako gotowe do wdrożenia na środowisku produkcyjnym, z zachowaniem dobrych praktyk programistycznych i wysokiej jakości kodu.

## Funkcjonalności

1. Pobieranie kursów walut dla wybranej waluty (np. EUR, USD).
2. Możliwość zapytania o kursy historyczne na podany dzień.
3. Dane pochodzą z API NBP i są przechowywane w bazie danych.
4. Wykorzystanie najnowszych funkcjonalności .NET.
5. Wbudowane testy jednostkowe zapewniające wysoką jakość kodu.

## Wymagania wstępne

- Do uruchomienia kodu wymagana jest minimum wersja .NET 8.0.

## Baza danych

W aplikacji wykorzystano bazę danych **SQLite**. Jest to lekka baza danych, która spełnia założenia tego projektu, ponieważ:

- **Spełnia wymaganie gotowości do wdrożenia na serwer produkcyjny**: Nie wymaga stawiania i łączenia się z zewnętrznym serwerem bazodanowym.
- **Brak wymagań trwałości**: Wymagania projektowe nie określają, że baza danych musi być trwała. Ponieważ kursy walut można w dowolnym momencie odtworzyć z API Narodowego Banku Polskiego (NBP), SQLite w pełni wystarcza do obsługi funkcjonalności.
- **Odtwarzalność danych**: Nawet w przypadku utraty danych w SQLite, aplikacja jest w stanie ponownie pobrać kursy z API NBP, co minimalizuje ryzyko.

## Architektura

W projekcie zastosowano **architekturę portów i adapterów (Hexagonal Architecture)**, co pozwala na łatwą wymianę komponentów, takich jak warstwa persystencji danych czy API kursów walut. Dzięki tej architekturze:

- **Modularność**: Można łatwo wymieniać bazy danych lub źródła kursów walut, bez modyfikacji logiki biznesowej aplikacji.
- **Izolacja**: Logika aplikacji jest oddzielona od zewnętrznych komponentów, co ułatwia modyfikację i rozszerzanie systemu.
- **Łatwiejsze testowanie**: Dzięki użyciu interfejsów, testy jednostkowe są prostsze, a zależności (np. baza danych, API) można łatwo mockować.

Architektura ta zwiększa elastyczność, ułatwia testowanie oraz pozwala na łatwą wymianę komponentów w przyszłości.

## Docker

Aplikacja zawiera przygotowany plik `Dockerfile`, który umożliwia łatwą publikację aplikacji na różnych serwerach, w tym na platformach takich jak **Azure**. Plik ten umożliwia zbudowanie obrazu kontenera, który jest gotowy do uruchomienia w środowisku produkcyjnym.
