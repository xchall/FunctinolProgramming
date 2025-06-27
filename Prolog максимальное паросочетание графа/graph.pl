#проверяем что вершина Vertex не входит в паросочетание Matching
vertex_not_in_matching(Vertex, Matching) :- 
    \+ member((Vertex, _), Matching),
    \+ member((_, Vertex), Matching).

% получаем все вершин графа
all_vertices(Vertices) :-
    findall(V, (edge(V, _); edge(_, V)), Vertices1),
    sort(Vertices1, Vertices). %удаляем дубликаты и сортируем по возрастанию

% Основной предикат для нахождения максимального паросочетания
max_matching(Matching) :-
    findall(M, find_matching([], M), Matchings), 
    max_length(Matchings, Matching). %выбираем самое длинное из найденных matchings

% Рекурсивный поиск всех возможных паросочетаний (реккурсия вниз)
find_matching(Current, Final) :-
    select_edge(Current, U, V),
    find_matching([(U,V)|Current], Final).
find_matching(M, M). % Базовый случай - больше нельзя добавить ребра

% Выбор подходящего ребра
select_edge([], U, V) :- edge(U, V), !.
select_edge(Matching, U, V) :-
    edge(U, V),
    vertex_not_in_matching(U, Matching),
    vertex_not_in_matching(V, Matching).



% Нахождение паросочетания максимальной длины
%1аргумент - список найденных паросочетаний
max_length([H|T], Max) :- 
    length(H, Len),
    find_max(T, Len, H, Max).

%вспомогательная реккурсия вниз
find_max([], _, Max, Max):- !. 
find_max([H|T], CurrentLen, CurrentMax, Max) :-
    length(H, Len),
    (Len > CurrentLen, find_max(T, Len, H, Max);
        find_max(T, CurrentLen, CurrentMax, Max)).

