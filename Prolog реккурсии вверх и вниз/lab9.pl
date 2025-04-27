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
