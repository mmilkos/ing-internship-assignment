# README
Dla projektu API, jest zapewniony krótki przewodnik. Poniższe ustawienia są zdefiniowane w pliku konfiguracyjnym:

```
{
  "ConnectionStrings": {
    "NBP": "http://api.nbp.pl/api/exchangerates/rates"
  },
  "DefaultValues": {
    "Code": "eur",
    "Days": "20",
    "Table": "a"
  }
}
```

### Ustawienia

* ConnectionStrings - zawiera link do zewnętrznego API, które jest używane jako źródło danych. Aktualnie jest skonfigurowane do korzystania z API Narodowego Banku Polskiego.
  
* DefaultValues - domyślne wartości używane przez API.
  * Code - domyślny kod waluty (EUR).
  * Days - liczba dni z których pobieramy dane.
  * Table - rodzaj tabeli stosowany przez NBP.

### Dokumentacja API

Dokumentacja API jest dostępna po uruchomieniu w Swagger:
https://localhost:44309/swagger/index.html
