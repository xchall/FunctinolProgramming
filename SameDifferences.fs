open System

//рекурсия вниз
let AryfmProgrOf3 (cur_num:int) (step:int) = 
    let rec progression acc num st = // acc список из трех чисел прогрессии получим (список как раз будем получать в порядке, например [3,2,1], что удобно для этой задачи)
        match List.length acc with 
        | 3 -> 
            acc
        | _ ->
            let newAcc = num :: acc
            let nextNum = num + st
            progression newAcc nextNum st

    progression [] cur_num step

let countXYZ (list:int List) = 
    let squares = List.map (fun x-> x*x) list
    match squares with
    | head :: tail -> head - (List.reduce (fun acc x -> acc + x) tail) 

let FindAnsSameDifferences current_num =
    //fl - нужно, чтобы остановится
    //acc - накапливаем количество решений для current_num
    let rec loop (acc:int) (num:int) (st:int) (fl:int) = //начинаем с шага 1 в прогрессии, с первого эемента = 1
        let progrList = AryfmProgrOf3 num st
        let result =  countXYZ progrList
        //Console.WriteLine($"Арифметическая прогрессиия {progrList}")
        match result with
        | _ when result = current_num -> //нашли одно решение
                                        Console.WriteLine($"{result} = ")
                                        let newAcc = acc + 1
                                        let newNum = num + 1    
                                        loop newAcc newNum 1 0

        | _ when result < current_num -> 
                                        //Console.WriteLine($"<")
                                        if fl = 10000000 then 
                                            Console.WriteLine($"{result} < ")
                                            acc
                                        else
                                            let newStep = st + 1
                                            let newFl = fl+1
                                            loop acc num newStep newFl
        | _ when result > current_num-> 

                                        if fl = 10000000 then 
                                            Console.WriteLine($"{result} > ")
                                            acc //дно рекурсии
                                        else 
                                            //Console.WriteLine($"{num} ")
                                            let newNum = num + 1
                                            let newFl = fl+1
                                            loop acc newNum 1 newFl

    loop 0 2 1 0


[<EntryPoint>]
let main argv =
    let numbersForResearch = [1155..1600]
    let answer = 
            FindAnsSameDifferences 1155
    Console.WriteLine($"{answer}")
    0
