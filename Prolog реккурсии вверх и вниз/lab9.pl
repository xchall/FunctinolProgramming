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

%z3
% 11 23 35

find_closest_number :- %пишем только его в swi
    read_list_and_num(X, Y),
    find_closest_num(X,Y, Z),
    write_answer(Z).

find_unic_element :-
	read_list(X),
	find_unic_elem(X,Y),
	write_answer(Y).

find_two_min_elems :-
	read_list(X),
	find_two_min(X,Y,Z),
	write_answer_two(Y,Z).

read_list_and_num(X, Y) :-
    write('Enter list: '),
    read(X),
    write('Enter number: '),
    read(Y).

read_list(X) :-
    write('Enter list: '),
    read(X).

write_answer(R) :-
    write('Answer is: '), write(R), nl.
write_answer_two(Y,Z):- 
	write('Answer is: '), write(Y), nl, write(Z).


%35 рекурсия вниз 
find_closest_num(X,Y,Z):- find_closest_num(X,99999,nil,Y, Z).%Dif - разница текущего с Y, Z - результат
find_closest_num([],_,Cur_z,_,Cur_z):- !.
find_closest_num([H|T],Dif,Cur_z,Y,Z):- R is abs(H - Y), 
(R<Dif, New_dif is R, New_z = H, find_closest_num(T,New_dif,New_z,Y,Z); 
New_dif is Dif, find_closest_num(T,New_dif,Cur_z,Y,Z)).

%11
%если уникальный есть, то хотя бы 3 элемента в массиве
find_unic_elem(X,Z) :- find_unic_elem(X,nil,Z).
find_unic_elem([],Cur_Z,Cur_Z):- !.
find_unic_elem([H1|[H2|[H3|T]]],_,Z):- H1 \= H2, H1 \= H3, New_z = H1, find_unic_elem(T,New_z,Z).
find_unic_elem([H1|[H2|[H3|T]]],_,Z):- H2 \= H1, H2 \= H3, New_z = H2, find_unic_elem(T,New_z,Z).
find_unic_elem([H1|[H2|[H3|T]]],_,Z):- H3 \= H1, H3 \= H2, New_z = H3, find_unic_elem(T,New_z,Z).
find_unic_elem([_|[_|[_|T]]],Cur_Z,Z):- find_unic_elem(T,Cur_Z,Z).
find_unic_elem([_|_],Cur_Z,Cur_Z):- !. %второе дно 

%23
find_two_min(List, Min1, Min2) :- find_two_min(List, 999999, 999999, Min1, Min2).
find_two_min([], Min1, Min2, Min1, Min2).
find_two_min([H|T], Cur_min1, Cur_min2, Min1, Min2) :-
    (H < Cur_min1, New_min2 = Cur_min1, New_min1 = H; 
    H < Cur_min2, New_min1 = Cur_min1, New_min2 = H;
    New_min1 = Cur_min1,New_min2 = Cur_min2),
    find_two_min(T, New_min1, New_min2, Min1, Min2).


%z4
%Воронов, Павлов, Левицкий и Сахаров. Один из них танцор, другой художник, третий-певец, а четвертый-писатель
%1 -не танцор, 2 - не художник, 3 - не певец, 4 - не писатель,  Наличие цифры в списке у человека имеет этот смысл
%[3,4] 
%[2,4]
%[3]
%[4]
%find_each_person_profession([3,4], [2,4], [3], [4]):- 

%z5
amount_del_not_three(X,Y):- amount_del_not_three(X,X, 0, Y).
amount_del_not_three(_,0, Cur_y, Cur_y):-!.
amount_del_not_three(X,D, Cur_y, Y):- 0 is X mod D, Ost is D mod 3, 0 \= Ost, New_cur_y is Cur_y+1, New_d is D-1, amount_del_not_three(X, New_d, New_cur_y, Y), !.
amount_del_not_three(X,D, Cur_y, Y):- 0 is X mod D, New_d is D-1, amount_del_not_three(X, New_d, Cur_y, Y), !.
amount_del_not_three(X,D, Cur_y, Y):- New_d is D-1, amount_del_not_three(X, New_d, Cur_y, Y).

%
amount_del(X,Y):- amount_del(X,X, 0, Y). %Проверяем простоту числа по количеству делителей
amount_del(_,0, Cur_y, Cur_y):-!.
amount_del(X,D, Cur_y, Y):- 0 is X mod D, New_cur_y is Cur_y+1, New_d is D-1, amount_del_not_three(X, New_d, New_cur_y, Y), !.
amount_del(X,D, Cur_y, Y):- New_d is D-1, amount_del_not_three(X, New_d, Cur_y, Y).

%реккурсия вниз
sum_cifr_down(N,S):- sum_cifr_down(N,0,S).
sum_cifr_down(0, Sum, Sum):-!. 
sum_cifr_down(N,Cur_sum,Sum) :- Cifr is N mod 10, 
N1 is N div 10, New_cur_sum is Cur_sum + Cifr,
sum_cifr_down(N1,New_cur_sum,Sum).

pr_cifr_down(N,S):- pr_cifr_down(N,1,S). 
pr_cifr_down(0, Pr, Pr):-!. 
pr_cifr_down(N,Cur_pr,Pr) :- Cifr is N mod 10, 
N1 is N div 10, New_cur_pr is Cur_pr * Cifr,
pr_cifr_down(N1,New_cur_pr,Pr).

%взаимно простые значит НОД = 1
sum_del_vzaimnoprost(X,Y):- sum_del_vzaimnoprost(X,X, 0, Y).
sum_del_vzaimnoprost(_,0, Cur_y, Cur_y):-!.
sum_del_vzaimnoprost(X,D, Cur_y, Y):- 0 is X mod D, sum_cifr_down(X,S1), pr_cifr_down(X,S2), nod_down(D,S1,R1), R1 = 1, nod_down(D,S2,R2), R2 > 1, 
write(D), nl, New_cur_y is Cur_y+D, New_d is D-1, sum_del_vzaimnoprost(X, New_d, New_cur_y, Y).
sum_del_vzaimnoprost(X,D, Cur_y, Y):- New_d is D-1, sum_del_vzaimnoprost(X, New_d, Cur_y, Y).