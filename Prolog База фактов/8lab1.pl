man :- man(X), print(X), nl, fail.

children(X):- parent(X, Y), print(Y), nl, fail.
mother(X, Y) :- woman(X), parent(X,Y).
mother(X) :- mother(Y, X), print(Y).

father(X, Y) :- man(X), parent(X,Y).

brother(X,Y) :- man(X), man(Y), X \= Y, (mother(Z,X), mother(Z,Y), father(G,X), father(G,Y)).
brothers(X) :- brother(X,Y), print(Y), nl, fail.

sister(X,Y) :- woman(X), woman(Y), X \= Y, (mother(Z,X), mother(Z,Y), father(G,X), father(G,Y)).
sister(X) :- sister(X,Y), print(Y), nl, fail.

b_and_s(X,Y) :- (woman(X), man(Y); man(X), woman(Y)), X \= Y, (mother(Z,X), mother(Z,Y), father(G,X), father(G,Y)).
b_and_s(X) :- sister(X,Y), print(Y), nl, fail.

b_s(X,Y) :- sister(X,Y); brother(X,Y); b_and_s(X,Y).
b_s(X) :- b_s(X,Y), print(Y), nl, fail.

%var 11
%z 2
son(X,Y) :- man(X), parent(Y, X).
son(X) :- son(Y,X), print(Y),nl,fail.

husband(X,Y) :- man(X), woman(Y), parent(X,Z), parent(Y, Z).
husband(X) :- woman(X), husband(Y,X), print(Y).
