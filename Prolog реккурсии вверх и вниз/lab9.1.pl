max(X,Y,X) :- X>Y, !.
%max(X,Y,Y). unright
max(_,Y,Y).

max(X,Y,Z,U) :- max(X,Y,V), max(V,Z,U).

max3(X,Y,Z,X) :- X>Y, X>Z, !.
max3(_,Y,Z,Y) :- Y>Z, !.
max3(_,_,Z,Z).

%реккурсия вверх факториал
fact(1,1) :- !.
fact(N,X) :- New_N is N -1, fact(New_N, X1), X is X1*N.

%реккурсия вверх
sum_cifr(0,0) :- !.
sum_cifr(N,S):- Cifr is N mod 10, N1 is N div 10, sum_cifr(N1,S1), S is S1+Cifr.


%реккурсия вниз
sum_cifr_down(N,S):- sum_cifr_down(N,0,S). %для пользователя не нужна вторая переменная
sum_cifr_down(0, Sum, Sum):-!. %дно
sum_cifr_down(N,Cur_sum,Sum) :- Cifr is N mod 10, 
N1 is N div 10, New_cur_sum is Cur_sum + Cifr,
sum_cifr_down(N1,New_cur_sum,Sum).


%сумма элементов списка реккурсия вниз
sum_list(Y,X) :-sum_list(Y,0,X).
sum_list([], Cur_sum, Cur_sum):- !.
sum_list([H|T], Cur_sum, X):- New_cur_sum is Cur_sum + H, 
sum_list(T, New_cur_sum,X).



