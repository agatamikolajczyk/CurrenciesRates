# CurrenciesRates
To repozytorium zawiera aplikację napisaną w technologii .NET, która umożliwia pobieranie kursów walut (zakupu i sprzedaży) w stosunku do polskiego złotego (PLN). Aplikacja pobiera dane z Narodowego Banku Polskiego (NBP) i przechowuje je w bazie danych, umożliwiając ich późniejsze zapytania. API zostało zaprojektowane jako gotowe do wdrożenia na środowisku produkcyjnym, z zachowaniem dobrych praktyk programistycznych i wysokiej jakości kodu.

Funkcjonalności  
1. Pobieranie kursów walut dla wybranej waluty (np. EUR, USD).
2. Możliwość zapytania o kursy historyczne na podany dzień.
3. Dane pochodzą z API NBP i są przechowywane w bazie danych.
4. Wykorzystanie najnowszych funkcjonalności .NET.
5. Wbudowane testy jednostkowe zapewniające wysoką jakość kodu.

Wymagania wstępne  
Do uruchomienia kodu wymagana jest minimum wersja .NET 8.0
W aplikacji wykorzystano bazę danych SQLite. Jest to lekka baza danych, która spełnia założenia tego projektu, ponieważ:
Spełnia wymaganie gotowości do wdrożenia na serwer produkcyjny (nie wymaga stawiania i łączenia się z zewnętrznym serwerem bazodanowym)  
Brak wymagań trwałości: Wymagania projektowe nie określają, że baza danych musi być trwała. Ponieważ kursy walut można w dowolnym momencie odtworzyć z API Narodowego Banku Polskiego (NBP), SQLite w pełni wystarcza do obsługi funkcjonalności.
Odtwarzalność danych: Nawet w przypadku utraty danych w SQLite, aplikacja jest w stanie ponownie pobrać kursy z API NBP, co minimalizuje ryzyko.
