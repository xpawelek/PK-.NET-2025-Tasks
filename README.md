## Wzorzec projektowy **Strategia**

![image](https://github.com/user-attachments/assets/d4a7132e-83be-4d7c-97af-e7cd4f296b16)


Wzorzec **Strategia** to behawioralny wzorzec, który:

- Pozwala zdefiniować rodzinę algorytmów (np. różne sposoby wyznaczania trasy),
- Umieszcza każdy algorytm w osobnej klasie,
- Umożliwia wymienne używanie algorytmów w czasie działania programu – bez zmieniania kodu klasy głównej.

---

### Jak wygląda implementacja?

- Tworzymy przykładowo interfejs strategii (np. "IRouteStrategy") z metodą "BuildRoute(Coordinates from, Coordinates to)".
- Implementujemy różne strategie, np. WalkingStrategy, CarStrategy, PublicTransportStrategy.
- Klasa Navigator deleguje wykonanie do strategii przez interfejs.
- Klient może w każdej chwili zmienić strategię – bez modyfikacji "Navigator".

---

### Jaki problem rozwiązuje implementcja wzorca strategii?

- Eliminacja rozrastającej się klasy, w której każda nowa funkcja zwiększa złożoność.
- Oddzielenie logiki tras od kontekstu (kodu klasy głównej) – łatwiejsze utrzymanie i testowanie.
- Umożliwia niezależny rozwój poszczególnych algorytmów.
- Możliwość łatwego dodania nowych strategii bez konieczności modyfikacji istniejącego kodu.

---

## Schemat UML przykładu.

![image](https://github.com/user-attachments/assets/247560be-8080-4978-8953-6508469ab1a7)

