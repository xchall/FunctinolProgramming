open System

//рекурсия вниз
let AryfmProgrOf3 (cur_num:int) (step:int) = 
    let rec progression acc num st = // acc список из трех чисел прогрессии получим (список как раз будем получать в порядке, например [3,2,1], что удобно для этой задачи)
        match List.length acc with 
        | 3 -> acc
        | _ ->
            let newAcc = num :: acc
            let nextNum = num + st
            progression newAcc nextNum st

    progression [] cur_num step

[<EntryPoint>]
let main argv =
    let answer = 
        AryfmProgrOf3 15 4
    Console.WriteLine($"Арифметическая прогрессиия {answer}")
    0
