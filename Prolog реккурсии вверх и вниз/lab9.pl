%var 11
%z 2

max_cifr_up(0, 0):-!.
max_cifr_up(X, M):- Cifr is X mod 10, New_x is X div 10,
max_cifr_up(New_x, New_m), (Cifr > New_m, M is Cifr; M is New_m).
%на ветвлении может происходить backtracking

max_cifr_down(X,M):-max_cifr_down(X,0,M).
max_cifr_down(0, Cur_m, Cur_m):-!.
max_cifr_down(X,Cur_m,M) :- Cifr is X mod 10, New_x is X div 10,
(Cifr > Cur_m, New_cur_m is Cifr; New_cur_m is Cur_m), 
max_cifr_down(New_x,New_cur_m,M).


min_nech_cifr_up(0, 999):-!. %999 будет говорить о том, что нет нечетных цифр 
min_nech_cifr_up(X, M):- Cifr is X mod 10, New_x is X div 10,
min_nech_cifr_up(New_x, New_m), (1 is Cifr mod 2, Cifr < New_m, M is Cifr; M is New_m).


min_nech_cifr_down(X,M) :- min_nech_cifr_down(X,999,M).
min_nech_cifr_down(0, Cur_m, Cur_m):-!.
min_nech_cifr_down(X,Cur_m,M) :- Cifr is X mod 10, New_x is X div 10,
(1 is Cifr mod 2,Cifr < Cur_m, New_cur_m is Cifr; New_cur_m is Cur_m), 
min_nech_cifr_down(New_x,New_cur_m,M).

%НОД двух чисел по алгоритму евклида
%заменяем большее число на меньшее, а меньшее на остаток
nod_down(X,0,X):- !.
nod_down(0,Y,Y):- !.
nod_down(X,Y,R):- X =< Y, Ost is Y mod X, nod_down(Ost,X,R).
nod_down(X,Y,R):- X > Y, nod_down(Y,X,R).  
