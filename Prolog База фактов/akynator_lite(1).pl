:-dynamic high/2.
read_str(A):-get0(X),r_str(X,A,[]).
r_str(10,A,A):-!.
r_str(X,A,B):-append(B,[X],B1),get0(X1),r_str(X1,A,B1).
high_r(X,Y):-	repeat, (high(X,Y) -> (put(32),write(X),nl,write(Y),write("."),nl,
				retract(high(X,Y))) ;X=nil,Y=nil).
pr2:-tell('c:/Prolog/29_1_prolog_F/111.txt'),high_r(X,_),X=nil,told.
pr3:-see('c:/Prolog/29_1_prolog_F/111.txt'),get0(Sym),read_high(Sym),seen.
read_high(-1):-!.
read_high(_):-	read_str(Lang),name(X,Lang),read(Y),asserta(high(X,Y)),
				get0(Sym),read_high(Sym).


% добавили Rust, Java, JavaScript
high_level(ruby,1).
high_level(c_sharp,1).
high_level(python,1).
high_level(c_plu_plus,1).
high_level(f_sharp,1).
high_level(prolog,1).
high_level(c,0).
high_level(asm,0).
high_level(rust,1).
high_level(java,1).
high_level(javascript,1).

decl(ruby,0).
decl(c_sharp,0).
decl(python,0).
decl(c_plu_plus,0).
decl(f_sharp,1).
decl(prolog,1).
decl(c,0).
decl(asm,0).
decl(rust, 0).
decl(java, 0).
decl(java_script, 0).

interpret(ruby,1).
interpret(python,1).
interpret(f_sharp,1).
interpret(prolog,1).
interpret(c_sharp,0).
interpret(c_plu_plus,0).
interpret(c,0).
interpret(asm,0).
interpret(rust,0).
interpret(java,0).
interpret(java_script,1).

oop(ruby,3).
oop(c_sharp,3).
oop(python,2).
oop(c_plu_plus,2).
oop(f_sharp,1).
oop(prolog,1).
oop(c,0).
oop(asm,0).
oop(rust,1).
oop(java,3).
oop(java_script,2).

cross(ruby,1).
cross(python,1).
cross(c_plu_plus,1).
cross(prolog,1).
cross(c,1).
cross(asm,1).
cross(c_sharp,0).
cross(f_sharp,0).
cross(rust,1).
cross(java,1).
cross(java_script,1).

visual(c_sharp,3).
visual(ruby,2).
visual(python,2).
visual(c_plu_plus,2).
visual(f_sharp,2).
visual(prolog,1).
visual(c,0).
visual(asm,0).
visual(rust,0).
visual(java,2).
visual(java_script,2).

mobile(c_sharp,0).
mobile(ruby,0).
mobile(python,0).
mobile(c_plu_plus,0).
mobile(f_sharp,0).
mobile(prolog,0).
mobile(c,0).
mobile(asm,0).
mobile(rust,0).
mobile(java,1).
mobile(java_script,1).


question1(X1):-	write("Is your language high level?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X1).

question2(X2):-	write("Is your language declarative?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X2).

question3(X3):-	write("Is your language interpret?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X3).

question4(X4):-	write("Does your language support OOP?"),nl,
				write("3. It is OOP itself"),nl,
				write("2. yes"),nl,
				write("1. yes, but very hard"),nl,
				write("0. NO"),nl,
				read(X4).

question5(X5):-	write("Is your language crossplatformic?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X5).

question6(X6):-	write("Does your language support visual interface for user?"),nl,
				write("3. It is visual itself"),nl,
				write("2. yes"),nl,
				write("1. yes, but very hard"),nl,
				write("0. NO"),nl,
				read(X6).

question7(X7):-	write("Is your language for mobile phones?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X7).				



pr:-	question1(X1),question2(X2),question3(X3),question4(X4),
		question5(X5),question6(X6),question7(X7),
		high_level(X,X1),decl(X,X2),interpret(X,X3),oop(X,X4),
		cross(X,X5),visual(X,X6),mobile(X,X7),
		write(X).



