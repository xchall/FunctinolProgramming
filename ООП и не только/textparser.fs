open FParsec

//в тексте будут пробелы, при помощи space не учитываем их
//алгебраический тип
type ParsedValue =
    | Word of string
    | Float of float
    | Symbol of char  //для знаков .,;:!?+-*/=<>()[]{}

//Парсер для слов (без пробелов)
let wordParser : Parser<ParsedValue, unit> = //1ый параметр - тип результата парсинга; 2ой - тип пользовательского состояния (не используем)
    many1Satisfy (fun c -> System.Char.IsLetter c || c = '_') // Буквы и подчёркивание
    |>> Word // комбинатор |>> сохраняет результат в дискриминатор

//Парсер для чисел (отдельно для int не нужно, pfloat их захватывает)
let floatParser : Parser<ParsedValue, unit> =
    pfloat 
    |>> Float

//Парсер для знаков
let symbolParser : Parser<ParsedValue, unit> =
    anyOf ".,;:!?+-*/=<>()[]{}"
    |>> Symbol

//комбинированный парсер 
let valueParser =
    choice [
        attempt floatParser
        wordParser
        symbolParser   
    ]

let parser =
    many (spaces >>. valueParser .>> spaces) .>> eof //many повторяет парсер ноль или более раз

//тестирование
let parseInput input =
    match run parser input with
    | Success(result, _, _) -> 
        printfn "Успешный разбор: %A" result
    | Failure(errorMsg, _, _) -> 
        printfn "Ошибка разбора: %s" errorMsg
        
let examples = [
    "please count; 42 + 3.14 = 45.14, right answer!"
    "x*(y+z) / 2.0;"
    "if x>0 then print(x);"
    "a=1, b=2; a+b=3? yes, it is equal 3"
    "Square of circle = 3.14 * r * r, we know this from school."
]

examples |> List.iter (fun input -> parseInput input)