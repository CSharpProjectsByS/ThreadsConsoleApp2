# ThreadsConsoleApp2

## Aplikacja ma za zadnie ukazać różnicę pomiędzy wątkiem typu foreground, a background.

### Należy ukazać, że jeżeli wątęk typu foreground się zakończy to wątek typu background zostanie unicestwiony.

Żeby to wykazać tworzymy 2 wątki jeden typu background, drugi typu foreground. Potrzebujemy 2 scenariuszy:

1. Dajemy więcej pracy dla foreground, a mniej dla background. - wtedy background skończy swoją pracę.
2. Dajemy mniej pracy dla foregorund, więcej dla background - background nie ukónczy zadania.

Np: Tą pracą może być np: wyszukiwanie liczb pierwszych z danego zakresu (jakiś w miarę złożony algorytm.
Wielkość zakresu musi być w odpowiedni sposób dopasowana do
scenariusza.
