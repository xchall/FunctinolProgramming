% База знаний автомобильных брендов
% Формат: brand(Название, Страна, ГодОснования, Класс, Популярность, Технологии)

% Немецкие марки
brand(mercedes, 1, 1, 1, 1, 1).
brand(bmw, 1, 1, 1, 1, 1).
brand(audi, 1, 1, 1, 1, 1).
brand(porsche, 1, 1, 2, 2, 1).
brand(volkswagen, 1, 1, 3, 1, 2).
brand(opel, 1, 1, 3, 2, 2).

% Японские марки
brand(honda, 2, 2, 3, 1, 1).
brand(mazda, 2, 1, 3, 2, 1).
brand(subaru, 2, 2, 3, 2, 1).
brand(nissan, 2, 1, 3, 1, 2).
brand(toyota, 2, 1, 3, 1, 1).
brand(lexus, 2, 3, 1, 2, 1).
brand(mitsubishi, 2, 1, 3, 2, 2).
brand(suzuki, 2, 1, 4, 2, 2).
brand(infiniti, 2, 3, 1, 3, 1).

% Американские марки
brand(ford, 3, 1, 3, 1, 2).
brand(cadillac, 3, 1, 1, 2, 1).
brand(dodge, 3, 1, 2, 2, 2).
brand(tesla, 3, 4, 1, 1, 1).
brand(jeep, 3, 1, 2, 1, 2).
brand(chevrolet, 3, 1, 3, 1, 2).
brand(ram, 3, 3, 4, 3, 2).

% Итальянские марки
brand(ferrari, 4, 1, 2, 3, 1).
brand(fiat, 4, 1, 3, 2, 2).
brand(maserati, 4, 1, 1, 3, 1).
brand(lamborghini, 4, 2, 2, 3, 1).
brand(pagani, 4, 3, 2, 4, 1).
brand(alfa_romeo, 4, 1, 2, 2, 1).

% Китайские марки
brand(geely, 5, 3, 3, 2, 2).
brand(chery, 5, 3, 3, 2, 2).
brand(haval, 5, 3, 3, 2, 2).
brand(zeekr, 5, 4, 1, 3, 1).
brand(changan, 5, 2, 3, 2, 2).

% Французские марки
brand(citroen, 6, 1, 3, 2, 2).
brand(peugeot, 6, 1, 3, 2, 2).
brand(bugatti, 6, 1, 2, 4, 1).
brand(renault, 6, 1, 3, 2, 2).

% Российские марки
brand(lada, 7, 2, 3, 2, 3).
brand(zil, 7, 1, 4, 3, 3).
brand(aurus, 7, 4, 1, 4, 1).
brand(kamaz, 7, 2, 4, 3, 2).
brand(gaz, 7, 1, 4, 3, 3).

%Другие
brand(hyundai, 8, 2, 3, 1, 1).
brand(kia, 8, 2, 3, 1, 1).
brand(volvo, 8, 1, 3, 2, 1).
brand(koenigsegg, 8, 3, 2, 4, 1).
brand(rolls_royce, 8, 1, 1, 4, 1).
brand(bentley, 8, 1, 1, 3, 1).
brand(land_rover, 8, 2, 2, 2, 1).
brand(jaguar, 8, 1, 1, 2, 1).
brand(mclaren, 8, 3, 2, 3, 1).

% Вопросы для акинатора
question1(Country) :- 
    write('Country:'), nl,
    write('1: Germany, 2: Japan, 3: USA, 4: Italy, 5: China,'), nl,
    write('6: France, 7: Russia, 8: Other country'), nl,
    read(Country).

question2(Era) :- 
    write('The year of the companys foundation:'), nl,
    write('1: Before 1900, 2: 1900-1949, 3: 1950-1999, 4: After 2000'), nl,
    read(Era).

question3(Class) :- 
    write('Car class:'), nl,
    write('1: Premium, 2: Sportcars, 3: Common, 4: Commercial'), nl,
    read(Class).

question4(Popularity) :- 
    write('Popularity:'), nl,
    write('1: Very popular, 2: Average popularity,'), nl,
    write('3: Niche, 4: Very rare'), nl,
    read(Popularity).

question5(Technologies) :- 
    write('Technologies level:'), nl,
    write('1: high-technology, 2: Average level, 3: Simple/old'), nl,
    read(Technologies).

identify_brand :-
    question1(Country),
    question2(Era),
    question3(Class),
    question4(Popularity),
    question5(Technologies),
    brand(Name, Country, Era, Class, Popularity, Technologies),
    write('Possible car brand: '), write(Name), nl,
    fail.